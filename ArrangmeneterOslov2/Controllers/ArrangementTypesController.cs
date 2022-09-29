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
    public class ArrangementTypesController : ControllerBase
    {
        private readonly ArrangementContext _context;

        public ArrangementTypesController(ArrangementContext context)
        {
            _context = context;
        }

        // GET: api/ArrangementTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArrangementType>>> GetArrangementType()
        {
            return await _context.ArrangementType.ToListAsync();
        }

        // GET: api/ArrangementTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArrangementType>> GetArrangementType(int id)
        {
            var arrangementType = await _context.ArrangementType.FindAsync(id);

            if (arrangementType == null)
            {
                return NotFound();
            }

            return arrangementType;
        }

        // PUT: api/ArrangementTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArrangementType(int id, ArrangementType arrangementType)
        {
            if (id != arrangementType.Id)
            {
                return BadRequest();
            }

            _context.Entry(arrangementType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArrangementTypeExists(id))
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

        // POST: api/ArrangementTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArrangementType>> PostArrangementType(ArrangementType arrangementType)
        {
            _context.ArrangementType.Add(arrangementType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArrangementType", new { id = arrangementType.Id }, arrangementType);
        }

        // DELETE: api/ArrangementTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArrangementType(int id)
        {
            var arrangementType = await _context.ArrangementType.FindAsync(id);
            if (arrangementType == null)
            {
                return NotFound();
            }

            _context.ArrangementType.Remove(arrangementType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArrangementTypeExists(int id)
        {
            return _context.ArrangementType.Any(e => e.Id == id);
        }
    }
}
