using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using planetnineserver.Data;
using planetnineserver.Models;

namespace planetnineserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class moon : ControllerBase
    {
        private readonly planetnineservercontext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public moon(planetnineservercontext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: api/moon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Moon>>> GetMoon()
        {
          if (_context.Moon == null)
          {
              return NotFound();
          }
            return await _context.Moon.ToListAsync();
        }

        // GET: api/moon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Moon>> GetMoon(int id)
        {
          if (_context.Moon == null)
          {
              return NotFound();
          }
            var moon = await _context.Moon.FindAsync(id);

            if (moon == null)
            {
                return NotFound();
            }

            return moon;
        }

        [HttpGet("user")]
        public async Task<ActionResult<IEnumerable<Moon>>> GetUserMoon()
        {
            if (_context.Moon == null)
            {
                return NotFound();
            }

            var userId = Int32.Parse(HttpContext.Request.Cookies["user"]);

            return await _context.Moon.Where(p => p.UserId == userId).Select(x => new Moon()
            {
                MoonId = x.MoonId,
                MoonName = x.MoonName,
                MoonMass = x.MoonMass,
                Perihelion = x.Perihelion,
                Aphelion = x.Aphelion,
                Gravity = x.Gravity,
                UserId = x.UserId,
                ImageLink = x.ImageLink,
                Temperature = x.Temperature,
                ImageSource = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.ImageLink)
            }).ToListAsync();
        }

        // GET: api/moon/5
        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<Moon>>> GetOtherUserMoon(int id)
        {
            if (_context.Moon == null)
            {
                return NotFound();
            }

            return await _context.Moon.Where(p => p.UserId == id).Select(x => new Moon()
                {
                    MoonId = x.MoonId,
                    MoonName = x.MoonName,
                    MoonMass = x.MoonMass,
                    Perihelion = x.Perihelion,
                    Aphelion = x.Aphelion,
                    Gravity = x.Gravity,
                    UserId = x.UserId,
                    ImageLink = x.ImageLink,
                    Temperature = x.Temperature,
                    ImageSource = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.ImageLink)
                }).ToListAsync();
        }

        // PUT: api/moon/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoon([FromForm] int id, Moon moon)
        {
            if (id != moon.MoonId)
            {
                return BadRequest();
            }

            _context.Entry(moon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoonExists(id))
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

        // POST: api/moon
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Moon>> PostMoon([FromForm] Moon moon)
        {
          if (_context.Moon == null)
          {
              return Problem("Entity set 'planetnineservercontext.Moon'  is null.");
          }

            if (moon.ImageFile != null)
            {
                moon.ImageLink = await SaveImage(moon.ImageFile);
            }

            _context.Moon.Add(moon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMoon", new { id = moon.MoonId }, moon);
        }

        // DELETE: api/moon/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoon(int id)
        {
            if (_context.Moon == null)
            {
                return NotFound();
            }
            var moon = await _context.Moon.FindAsync(id);
            if (moon == null)
            {
                return NotFound();
            }

            _context.Moon.Remove(moon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MoonExists(int id)
        {
            return (_context.Moon?.Any(e => e.MoonId == id)).GetValueOrDefault();
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
