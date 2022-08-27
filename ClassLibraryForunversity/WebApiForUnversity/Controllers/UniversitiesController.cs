using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassLibraryForunversity.Model;
using ClassLibraryForunversity.unversitycontext;

namespace WebApiForUnversity.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UniversitiesController : ControllerBase
    {
        private readonly UnversityDbContext _context;

        public UniversitiesController(UnversityDbContext context)
        {
            _context = context;
        }

        // GET: api/Universities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<University>>> GetUniversitys()
        {
          if (_context.Universitys == null)
          {
              return NotFound();
          }
            return await _context.Universitys.ToListAsync();
        }

        // GET: api/Universities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<University>> GetUniversity(int id)
        {
          if (_context.Universitys == null)
          {
              return NotFound();
          }
            var university = await _context.Universitys.FindAsync(id);

            if (university == null)
            {
                return NotFound();
            }

            return university;
        }

        // PUT: api/Universities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUniversity(int id, University university)
        {
            if (id != university.Id)
            {
                return BadRequest();
            }

            _context.Entry(university).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniversityExists(id))
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

        // POST: api/Universities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<University>> PostUniversity(University university)
        {
          if (_context.Universitys == null)
          {
              return Problem("Entity set 'UnversityDbContext.Universitys'  is null.");
          }
            _context.Universitys.Add(university);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUniversity", new { id = university.Id }, university);
        }

        // DELETE: api/Universities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUniversity(int id)
        {
            if (_context.Universitys == null)
            {
                return NotFound();
            }
            var university = await _context.Universitys.FindAsync(id);
            if (university == null)
            {
                return NotFound();
            }

            _context.Universitys.Remove(university);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UniversityExists(int id)
        {
            return (_context.Universitys?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
