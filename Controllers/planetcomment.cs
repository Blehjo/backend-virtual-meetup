using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using planetnineserver.Data;
using planetnineserver.Models;

namespace planetnineserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class planetcomment : ControllerBase
    {
        private readonly planetnineservercontext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public planetcomment(planetnineservercontext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: api/Comment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanetComment>>> GetComments()
        {
            if (_context.PlanetComment == null)
            {
                return NotFound();
            }

            return await _context.PlanetComment.Select(x => new PlanetComment()
            {
                PlanetCommentId = x.PlanetCommentId,
                CommentValue = x.CommentValue,
                DateCreated = x.DateCreated,
                UserId = x.UserId,
                MediaLink = x.MediaLink,
                PlanetId = x.PlanetId,
                ImageSource = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.MediaLink)
            }).ToListAsync();
        }

        // GET: api/Comment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlanetComment>> GetComment(int id)
        {
            if (_context.PlanetComment == null)
            {
                return NotFound();
            }

            var planetcomment = await _context.PlanetComment.FindAsync(id);

            if (planetcomment == null)
            {
                return NotFound();
            }

            planetcomment.ImageSource = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, planetcomment.MediaLink);

            return planetcomment;
        }

        // GET: api/Comment/5
        [HttpGet("planet/{id}")]
        public async Task<ActionResult<IEnumerable<PlanetComment>>> GetPostComments(int id)
        {
            if (_context.PlanetComment == null)
            {
                return NotFound();
            }

            return await _context.PlanetComment.Select(x => new PlanetComment()
            {
                PlanetCommentId = x.PlanetCommentId,
                CommentValue = x.CommentValue,
                DateCreated = x.DateCreated,
                UserId = x.UserId,
                MediaLink = x.MediaLink,
                PlanetId = x.PlanetId,
                ImageSource = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.MediaLink)
            }).Where(c => c.PlanetId == id).ToListAsync();
        }

        // PUT: api/Comment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, PlanetComment planetcomment)
        {
            if (id != planetcomment.PlanetCommentId)
            {
                return BadRequest();
            }

            _context.Entry(planetcomment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
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

        // POST: api/Comment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlanetComment>> PostComment([FromForm] PlanetComment planetcomment)
        {
            if (_context.PlanetComment == null)
            {
                return Problem("Entity set 'PlanetNineDatabaseContext.Comments'  is null.");
            }

            if (planetcomment.ImageFile != null)
            {
                planetcomment.MediaLink = await SaveImage(planetcomment.ImageFile);
            }

            planetcomment.UserId = Int32.Parse(HttpContext.Request.Cookies["user"]);

            _context.PlanetComment.Add(planetcomment);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComment", new { id = planetcomment.PlanetCommentId }, planetcomment);
        }

        // DELETE: api/Comment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            if (_context.MoonComment == null)
            {
                return NotFound();
            }
            var planetcomment = await _context.PlanetComment.FindAsync(id);
            if (planetcomment == null)
            {
                return NotFound();
            }

            _context.PlanetComment.Remove(planetcomment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentExists(int id)
        {
            return (_context.PlanetComment?.Any(e => e.PlanetCommentId == id)).GetValueOrDefault();
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
