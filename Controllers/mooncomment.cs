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
    public class mooncomment : ControllerBase
    {
        private readonly planetnineservercontext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public mooncomment(planetnineservercontext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: api/Comment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoonComment>>> GetComments()
        {
            if (_context.MoonComment == null)
            {
                return NotFound();
            }

            return await _context.MoonComment.Select(x => new MoonComment()
            {
                MoonCommentId = x.MoonCommentId,
                CommentValue = x.CommentValue,
                DateCreated = x.DateCreated,
                UserId = x.UserId,
                MediaLink = x.MediaLink,
                MoonId = x.MoonId,
                ImageSource = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.MediaLink)
            }).ToListAsync();
        }

        // GET: api/Comment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MoonComment>> GetComment(int id)
        {
            if (_context.MoonComment == null)
            {
                return NotFound();
            }

            var mooncomment = await _context.MoonComment.FindAsync(id);

            if (mooncomment == null)
            {
                return NotFound();
            }

            mooncomment.ImageSource = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, mooncomment.MediaLink);

            return mooncomment;
        }

        // GET: api/Comment/5
        [HttpGet("moon/{id}")]
        public async Task<ActionResult<IEnumerable<MoonComment>>> GetPostComments(int id)
        {
            if (_context.MoonComment == null)
            {
                return NotFound();
            }

            return await _context.MoonComment.Select(x => new MoonComment()
            {
                MoonCommentId = x.MoonCommentId,
                CommentValue = x.CommentValue,
                DateCreated = x.DateCreated,
                UserId = x.UserId,
                MediaLink = x.MediaLink,
                MoonId = x.MoonId,
                ImageSource = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.MediaLink)
            }).Where(c => c.MoonId == id).ToListAsync();
        }

        // PUT: api/Comment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, MoonComment mooncomment)
        {
            if (id != mooncomment.MoonCommentId)
            {
                return BadRequest();
            }

            _context.Entry(mooncomment).State = EntityState.Modified;

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
        public async Task<ActionResult<MoonComment>> PostComment([FromForm] MoonComment mooncomment)
        {
            if (_context.MoonComment == null)
            {
                return Problem("Entity set 'PlanetNineDatabaseContext.Comments'  is null.");
            }

            if (mooncomment.ImageFile != null)
            {
                mooncomment.MediaLink = await SaveImage(mooncomment.ImageFile);
            }

            mooncomment.UserId = Int32.Parse(HttpContext.Request.Cookies["user"]);

            _context.MoonComment.Add(mooncomment);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComment", new { id = mooncomment.MoonCommentId }, mooncomment);
        }

        // DELETE: api/Comment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            if (_context.MoonComment == null)
            {
                return NotFound();
            }
            var planetcomment = await _context.MoonComment.FindAsync(id);
            if (planetcomment == null)
            {
                return NotFound();
            }

            _context.MoonComment.Remove(planetcomment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentExists(int id)
        {
            return (_context.MoonComment?.Any(e => e.MoonCommentId == id)).GetValueOrDefault();
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
