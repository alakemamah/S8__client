using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S8__API.Data;
using S8__API.Models;

namespace S8__API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogisticRegressionsController : ControllerBase
    {
        private readonly S8__APIContext _context;

        public LogisticRegressionsController(S8__APIContext context)
        {
            _context = context;
        }

        // GET: api/LogisticRegressions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogisticRegression>>> GetLogisticRegression()
        {
            return await _context.LogisticRegression.ToListAsync();
        }

        // GET: api/LogisticRegressions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LogisticRegression>> GetLogisticRegression(int id)
        {
            var logisticRegression = await _context.LogisticRegression.FindAsync(id);

            if (logisticRegression == null)
            {
                return NotFound();
            }

            return logisticRegression;
        }

        // PUT: api/LogisticRegressions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogisticRegression(int id, LogisticRegression logisticRegression)
        {
            if (id != logisticRegression.ID)
            {
                return BadRequest();
            }

            _context.Entry(logisticRegression).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogisticRegressionExists(id))
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

        // POST: api/LogisticRegressions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LogisticRegression>> PostLogisticRegression(LogisticRegression logisticRegression)
        {
            _context.LogisticRegression.Add(logisticRegression);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogisticRegression", new { id = logisticRegression.ID }, logisticRegression);
        }

        // DELETE: api/LogisticRegressions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LogisticRegression>> DeleteLogisticRegression(int id)
        {
            var logisticRegression = await _context.LogisticRegression.FindAsync(id);
            if (logisticRegression == null)
            {
                return NotFound();
            }

            _context.LogisticRegression.Remove(logisticRegression);
            await _context.SaveChangesAsync();

            return logisticRegression;
        }

        private bool LogisticRegressionExists(int id)
        {
            return _context.LogisticRegression.Any(e => e.ID == id);
        }
    }
}
