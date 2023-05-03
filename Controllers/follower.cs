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
    public class follower : ControllerBase
    {
        private readonly planetnineservercontext _context;

        public follower(planetnineservercontext context)
        {
            _context = context;
        }

        // GET: api/follower
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Follower>>> GetFollower()
        {
          if (_context.Follower == null)
          {
              return NotFound();
          }
            return await _context.Follower.ToListAsync();
        }

        // GET: api/follower/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Follower>> GetFollower(int id)
        {
          if (_context.Follower == null)
          {
              return NotFound();
          }
            var follower = await _context.Follower.FindAsync(id);

            if (follower == null)
            {
                return NotFound();
            }

            return follower;
        }

        // PUT: api/follower/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFollower(int id, Follower follower)
        {
            if (id != follower.FollowerId)
            {
                return BadRequest();
            }

            _context.Entry(follower).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FollowerExists(id))
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

        // POST: api/follower
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Follower>> PostFollower(Follower follower)
        {
          if (_context.Follower == null)
          {
              return Problem("Entity set 'planetnineservercontext.Follower'  is null.");
          }
            _context.Follower.Add(follower);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFollower", new { id = follower.FollowerId }, follower);
        }

        // DELETE: api/follower/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFollower(int id)
        {
            if (_context.Follower == null)
            {
                return NotFound();
            }
            var follower = await _context.Follower.FindAsync(id);
            if (follower == null)
            {
                return NotFound();
            }

            _context.Follower.Remove(follower);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FollowerExists(int id)
        {
            return (_context.Follower?.Any(e => e.FollowerId == id)).GetValueOrDefault();
        }
    }
}
