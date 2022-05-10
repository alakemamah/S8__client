#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S8_API.Models;
using S8_API.Data;

namespace S8_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly S8_APIContext _context;

        public AnalysisController(S8_APIContext context)
        {
            _context = context;
        }

        // GET: api/Analysis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalysisItem>>> GetAnalysisItem()
        {
            return await _context.AnalysisItem.ToListAsync();
        }

        // GET: api/Analysis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnalysisItem>> GetAnalysisItem(int id)
        {
            var analysisItem = await _context.AnalysisItem.FindAsync(id);

            if (analysisItem == null)
            {
                return NotFound();
            }

            return analysisItem;
        }

        // PUT: api/Analysis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalysisItem(int id, AnalysisItem analysisItem)
        {
            if (id != analysisItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(analysisItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalysisItemExists(id))
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

        // POST: api/Analysis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnalysisItem>> PostAnalysisItem(AnalysisItem analysisItem)
        {
            _context.AnalysisItem.Add(analysisItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnalysisItem", new { id = analysisItem.Id }, analysisItem);
        }

        // DELETE: api/Analysis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnalysisItem(int id)
        {
            var analysisItem = await _context.AnalysisItem.FindAsync(id);
            if (analysisItem == null)
            {
                return NotFound();
            }

            _context.AnalysisItem.Remove(analysisItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnalysisItemExists(int id)
        {
            return _context.AnalysisItem.Any(e => e.Id == id);
        }
    }
}
