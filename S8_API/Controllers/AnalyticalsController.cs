using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S8_API.Data;
using S8_API.Models;

namespace S8_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticalsController : ControllerBase
    {
        private readonly S8_APIContext _context;

        public AnalyticalsController(S8_APIContext context)
        {
            _context = context;
        }

        // GET: api/Analyticals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Analytical>>> GetAnalytical()
        {
          if (_context.Analytical == null)
          {
              return NotFound();
          }
            return await _context.Analytical.ToListAsync();
        }

        // GET: api/Analyticals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Analytical>> GetAnalytical(int id)
        {
          if (_context.Analytical == null)
          {
              return NotFound();
          }
            var analytical = await _context.Analytical.FindAsync(id);

            if (analytical == null)
            {
                return NotFound();
            }

            return analytical;
        }

        // PUT: api/Analyticals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalytical(int id, Analytical analytical)
        {
            if (id != analytical.ID)
            {
                return BadRequest();
            }

            _context.Entry(analytical).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalyticalExists(id))
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

        // POST: api/Analyticals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Analytical>> PostAnalytical(Analytical analytical)
        {
          if (_context.Analytical == null)
          {
              return Problem("Entity set 'S8_APIContext.Analytical'  is null.");
          }
            _context.Analytical.Add(analytical);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnalytical", new { id = analytical.ID }, analytical);
        }

        // DELETE: api/Analyticals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnalytical(int id)
        {
            if (_context.Analytical == null)
            {
                return NotFound();
            }
            var analytical = await _context.Analytical.FindAsync(id);
            if (analytical == null)
            {
                return NotFound();
            }

            _context.Analytical.Remove(analytical);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnalyticalExists(int id)
        {
            return (_context.Analytical?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
