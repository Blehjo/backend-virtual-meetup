using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using planetnineserver.Data;
using planetnineserver.Models;

namespace planetnineserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class messagecomment : ControllerBase
    {
        private readonly planetnineservercontext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public messagecomment(planetnineservercontext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: api/MessageComment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageComment>>> GetMessageComments()
        {
          if (_context.MessageComment == null)
          {
              return NotFound();
          }
            return await _context.MessageComment.Select(x => new MessageComment() {
                MessageCommentId = x.MessageCommentId,
                MessageValue = x.MessageValue,
                DateCreated = x.DateCreated,
                MediaLink = x.MediaLink,
                ImageSource = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.MediaLink)}).ToListAsync();
        }

        // GET: api/MessageComment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MessageComment>>> GetMessageComment(int id)
        {
            if (_context.MessageComment == null)
            {
                return NotFound();
            }

            var messageComment = await _context.MessageComment.FindAsync(id);

            if (messageComment == null)
            {
                return NotFound();
            }

            messageComment.ImageSource = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, messageComment.MediaLink);

            return await _context.MessageComment.Where(m => m.MessageId == id).Select(x => new MessageComment()
            {
                MessageCommentId = x.MessageCommentId,
                MessageValue = x.MessageValue,
                DateCreated = x.DateCreated,
                MediaLink = x.MediaLink,
                ImageSource = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.MediaLink)
            }).ToListAsync();
        }

        // PUT: api/MessageComment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessageComment(int id, MessageComment messageComment)
        {
            if (id != messageComment.MessageCommentId)
            {
                return BadRequest();
            }

            _context.Entry(messageComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageCommentExists(id))
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

        // POST: api/MessageComment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MessageComment>> PostMessageComment([FromForm] MessageComment messageComment)
        {
            if (_context.MessageComment == null)
            {
                return Problem("Entity set 'planetnineservercontext.MessageComment'  is null.");
            }

            if (messageComment.ImageFile != null)
            {
                messageComment.MediaLink = await SaveImage(messageComment.ImageFile);
            }

            _context.MessageComment.Add(messageComment);
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessageComment", new { id = messageComment.MessageCommentId }, messageComment);
        }

        // DELETE: api/MessageComment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessageComment(int id)
        {
            if (_context.MessageComment == null)
            {
                return NotFound();
            }
            var messageComment = await _context.MessageComment.FindAsync(id);
            if (messageComment == null)
            {
                return NotFound();
            }

            _context.MessageComment.Remove(messageComment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MessageCommentExists(int id)
        {
            return (_context.MessageComment?.Any(e => e.MessageCommentId == id)).GetValueOrDefault();
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
