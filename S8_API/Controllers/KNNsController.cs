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
    public class KNNsController : ControllerBase
    {
        private readonly S8_APIContext _context;

        public KNNsController(S8_APIContext context)
        {
            _context = context;
        }

        // GET: api/KNNs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KNN>>> GetKNN()
        {
          if (_context.KNN == null)
          {
              return NotFound();
          }
            return await _context.KNN.ToListAsync();
        }

        // GET: api/KNNs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KNN>> GetKNN(int id)
        {
          if (_context.KNN == null)
          {
              return NotFound();
          }
            var kNN = await _context.KNN.FindAsync(id);

            if (kNN == null)
            {
                return NotFound();
            }

            return kNN;
        }

        // PUT: api/KNNs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKNN(int id, KNN kNN)
        {
            if (id != kNN.ID)
            {
                return BadRequest();
            }

            _context.Entry(kNN).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KNNExists(id))
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

        // POST: api/KNNs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KNN>> PostKNN(KNN kNN)
        {
          if (_context.KNN == null)
          {
              return Problem("Entity set 'S8_APIContext.KNN'  is null.");
          }
            _context.KNN.Add(kNN);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKNN", new { id = kNN.ID }, kNN);
        }

        // DELETE: api/KNNs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKNN(int id)
        {
            if (_context.KNN == null)
            {
                return NotFound();
            }
            var kNN = await _context.KNN.FindAsync(id);
            if (kNN == null)
            {
                return NotFound();
            }

            _context.KNN.Remove(kNN);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KNNExists(int id)
        {
            return (_context.KNN?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
