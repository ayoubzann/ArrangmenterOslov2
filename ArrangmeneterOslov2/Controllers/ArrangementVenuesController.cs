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
    public class ArrangementVenuesController : ControllerBase
    {
        private readonly ArrangementContext _context;

        public ArrangementVenuesController(ArrangementContext context)
        {
            _context = context;
        }

        // GET: api/ArrangementVenues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArrangementVenue>>> GetArrangementVenue()
        {
            return await _context.ArrangementVenue.ToListAsync();
        }

        // GET: api/ArrangementVenues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArrangementVenue>> GetArrangementVenue(int id)
        {
            var arrangementVenue = await _context.ArrangementVenue.FindAsync(id);

            if (arrangementVenue == null)
            {
                return NotFound();
            }

            return arrangementVenue;
        }

        // PUT: api/ArrangementVenues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArrangementVenue(int id, ArrangementVenue arrangementVenue)
        {
            if (id != arrangementVenue.Id)
            {
                return BadRequest();
            }

            _context.Entry(arrangementVenue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArrangementVenueExists(id))
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

        // POST: api/ArrangementVenues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArrangementVenue>> PostArrangementVenue(ArrangementVenue arrangementVenue)
        {
            _context.ArrangementVenue.Add(arrangementVenue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArrangementVenue", new { id = arrangementVenue.Id }, arrangementVenue);
        }

        // DELETE: api/ArrangementVenues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArrangementVenue(int id)
        {
            var arrangementVenue = await _context.ArrangementVenue.FindAsync(id);
            if (arrangementVenue == null)
            {
                return NotFound();
            }

            _context.ArrangementVenue.Remove(arrangementVenue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArrangementVenueExists(int id)
        {
            return _context.ArrangementVenue.Any(e => e.Id == id);
        }
    }
}
