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
    public class favorite : ControllerBase
    {
        private readonly planetnineservercontext _context;

        public favorite(planetnineservercontext context)
        {
            _context = context;
        }

        // GET: api/favorite
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Favorite>>> GetFavorite()
        {
          if (_context.Favorite == null)
          {
              return NotFound();
          }
            return await _context.Favorite.ToListAsync();
        }

        // GET: api/favorite/user
        [HttpGet("user")]
        public async Task<ActionResult<IEnumerable<Favorite>>> GetUserFavorites()
        {
            if (_context.Favorite == null)
            {
                return NotFound();
            }

            var userId = Int32.Parse(HttpContext.Request.Cookies["user"]);

            return await _context.Favorite.Where(f => f.UserId == userId).ToListAsync();
        }


        // GET: api/favorite/user/id
        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<Favorite>>> GetSingleUserFavorites(int id)
        {
            if (_context.Favorite == null)
            {
                return NotFound();
            }

            return await _context.Favorite.Where(f => f.UserId == id).ToListAsync();
        }

        // GET: api/favorite/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Favorite>> GetFavorite(int id)
        {
          if (_context.Favorite == null)
          {
              return NotFound();
          }
            var favorite = await _context.Favorite.FindAsync(id);

            if (favorite == null)
            {
                return NotFound();
            }

            return favorite;
        }

        // PUT: api/favorite/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavorite(int id, Favorite favorite)
        {
            if (id != favorite.FavoriteId)
            {
                return BadRequest();
            }

            _context.Entry(favorite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteExists(id))
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

        // POST: api/favorite
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Favorite>> PostFavorite(Favorite favorite)
        {
          if (_context.Favorite == null)
          {
              return Problem("Entity set 'planetnineservercontext.Favorite'  is null.");
          }

            favorite.UserId = Int32.Parse(HttpContext.Request.Cookies["user"]);

            _context.Favorite.Add(favorite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavorite", new { id = favorite.FavoriteId }, favorite);
        }

        // DELETE: api/favorite/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavorite(int id)
        {
            if (_context.Favorite == null)
            {
                return NotFound();
            }
            var favorite = await _context.Favorite.FindAsync(id);
            if (favorite == null)
            {
                return NotFound();
            }

            _context.Favorite.Remove(favorite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavoriteExists(int id)
        {
            return (_context.Favorite?.Any(e => e.FavoriteId == id)).GetValueOrDefault();
        }
    }
}
