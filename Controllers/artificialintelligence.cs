using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using planetnineserver.Data;
using planetnineserver.Models;

namespace planetnineserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class artificialintelligence : ControllerBase
    {
        private readonly planetnineservercontext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public artificialintelligence(planetnineservercontext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: api/ArtificialIntelligence
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtificialIntelligence>>> GetArtificialIntelligences()
        {
            if (_context.ArtificialIntelligences == null)
            {
                return NotFound();
            }

            return await _context.ArtificialIntelligences.Select(x => new ArtificialIntelligence()
            {
                ArtificialIntelligenceId = x.ArtificialIntelligenceId,
                Name = x.Name,
                Role = x.Role,
                ImageLink = x.ImageLink,
                ImageSource = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.ImageLink)
            }).ToListAsync();
        }

        // GET: api/ArtificialIntelligence/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtificialIntelligence>> GetArtificialIntelligence(int id)
        {
            if (_context.ArtificialIntelligences == null)
            {
                return NotFound();
            }
            var artificialIntelligence = await _context.ArtificialIntelligences.FindAsync(id);

            if (artificialIntelligence == null)
            {
                return NotFound();
            }

            artificialIntelligence.ImageSource = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, artificialIntelligence.ImageLink);

            return artificialIntelligence;
        }

        // GET: api/ArtificialIntelligence/user
        [HttpGet("user")]
        public async Task<ActionResult<IEnumerable<ArtificialIntelligence>>> GetUserArtificialIntelligences()
        {
            if (_context.ArtificialIntelligences == null)
            {
                return NotFound();
            }

            var userId = Int32.Parse(HttpContext.Request.Cookies["user"]);

            return await _context.ArtificialIntelligences.Where(p => p.UserId == userId).Select(x => new ArtificialIntelligence()
            {
                ArtificialIntelligenceId = x.ArtificialIntelligenceId,
                Name = x.Name,
                Role = x.Role,
                ImageLink = x.ImageLink,
                ImageSource = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.ImageLink)
            }).ToListAsync();
        }

        // GET: api/ArtificialIntelligence/5
        [HttpGet("/user/{id}")]
        public async Task<ActionResult<IEnumerable<ArtificialIntelligence>>> GetOtherUserArtificialIntelligence(int id)
        {
            if (_context.ArtificialIntelligences == null)
            {
                return NotFound();
            }
            var artificialIntelligence = await _context.ArtificialIntelligences.FindAsync(id);

            if (artificialIntelligence == null)
            {
                return NotFound();
            }

            return await _context.ArtificialIntelligences.Where(p => p.UserId == id).Select(x => new ArtificialIntelligence()
            {
                ArtificialIntelligenceId = x.ArtificialIntelligenceId,
                Name = x.Name,
                Role = x.Role,
                ImageLink = x.ImageLink,
                ImageSource = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.ImageLink)
            }).ToListAsync();
        }

        // PUT: api/ArtificialIntelligence/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtificialIntelligence(int id, ArtificialIntelligence artificialIntelligence)
        {
            if (id != artificialIntelligence.ArtificialIntelligenceId)
            {
                return BadRequest();
            }

            _context.Entry(artificialIntelligence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtificialIntelligenceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArtificialIntelligence>> PostArtificialIntelligence([FromForm] ArtificialIntelligence artificialIntelligence)
        {
            if (_context.ArtificialIntelligences == null)
            {
                return Problem("Entity set 'planetnineservers.ArtificialIntelligence'  is null.");
            }

            if (artificialIntelligence.ImageFile != null)
            {
                artificialIntelligence.ImageLink = await SaveImage(artificialIntelligence.ImageFile);
            }

            artificialIntelligence.UserId = Int32.Parse(HttpContext.Request.Cookies["user"]);

            _context.ArtificialIntelligences.Add(artificialIntelligence);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtificialIntelligence", new { id = artificialIntelligence.ArtificialIntelligenceId }, artificialIntelligence);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtificialIntelligence(int id)
        {
            if (_context.ArtificialIntelligences == null)
            {
                return NotFound();
            }

            var artificialIntelligence = await _context.ArtificialIntelligences.FindAsync(id);

            if (artificialIntelligence == null)
            {
                return NotFound();
            }

            _context.ArtificialIntelligences.Remove(artificialIntelligence);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtificialIntelligenceExists(int id)
        {
            return (_context.ArtificialIntelligences?.Any(e => e.ArtificialIntelligenceId == id)).GetValueOrDefault();
        }

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }

        [NonAction]
        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }
    }
}