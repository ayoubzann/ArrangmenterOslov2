using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArrangmeneterOslov2.Models;

namespace ArrangmeneterOslov2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArrangementsController : ControllerBase
    {
        private readonly ArrangementContext _context;

        public ArrangementsController(ArrangementContext context)
        {
            _context = context;
        }

        // GET: api/Arrangements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Arrangement>>> GetArrangement()
        {
            return await _context.Arrangement.ToListAsync();
        }

        // GET: api/Arrangements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Arrangement>> GetArrangement(int id)
        {
            var arrangement = await _context.Arrangement.FindAsync(id);

            if (arrangement == null)
            {
                return NotFound();
            }

            return arrangement;
        }

        // PUT: api/Arrangements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArrangement(int id, Arrangement arrangement)
        {
            if (id != arrangement.Id)
            {
                return BadRequest();
            }

            _context.Entry(arrangement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArrangementExists(id))
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

        // POST: api/Arrangements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Arrangement>> PostArrangement(Arrangement arrangement)
        {
            _context.Arrangement.Add(arrangement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArrangement", new { id = arrangement.Id }, arrangement);
        }

        // DELETE: api/Arrangements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArrangement(int id)
        {
            var arrangement = await _context.Arrangement.FindAsync(id);
            if (arrangement == null)
            {
                return NotFound();
            }

            _context.Arrangement.Remove(arrangement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArrangementExists(int id)
        {
            return _context.Arrangement.Any(e => e.Id == id);
        }
    }
}
