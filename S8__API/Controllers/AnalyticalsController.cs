using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S8_8API.Models;
using S8__API.Data;

namespace S8__API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticalsController : ControllerBase
    {
        private readonly S8__APIContext _context;

        public AnalyticalsController(S8__APIContext context)
        {
            _context = context;
        }

        // GET: api/Analyticals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Analytical>>> GetAnalytical()
        {
            return await _context.Analytical.ToListAsync();
        }

        // GET: api/Analyticals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Analytical>> GetAnalytical(int id)
        {
            var analytical = await _context.Analytical.FindAsync(id);

            if (analytical == null)
            {
                return NotFound();
            }

            return analytical;
        }

        // PUT: api/Analyticals/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Analytical>> PostAnalytical(Analytical analytical)
        {
            _context.Analytical.Add(analytical);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnalytical", new { id = analytical.ID }, analytical);
        }

        // DELETE: api/Analyticals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Analytical>> DeleteAnalytical(int id)
        {
            var analytical = await _context.Analytical.FindAsync(id);
            if (analytical == null)
            {
                return NotFound();
            }

            _context.Analytical.Remove(analytical);
            await _context.SaveChangesAsync();

            return analytical;
        }

        private bool AnalyticalExists(int id)
        {
            return _context.Analytical.Any(e => e.ID == id);
        }
    }
}
