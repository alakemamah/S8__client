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
    public class KNNsController : ControllerBase
    {
        private readonly S8__APIContext _context;

        public KNNsController(S8__APIContext context)
        {
            _context = context;
        }

        // GET: api/KNNs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KNN>>> GetKNN()
        {
            return await _context.KNN.ToListAsync();
        }

        // GET: api/KNNs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KNN>> GetKNN(int id)
        {
            var kNN = await _context.KNN.FindAsync(id);

            if (kNN == null)
            {
                return NotFound();
            }

            return kNN;
        }

        // PUT: api/KNNs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<KNN>> PostKNN(KNN kNN)
        {
            _context.KNN.Add(kNN);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKNN", new { id = kNN.ID }, kNN);
        }

        // DELETE: api/KNNs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KNN>> DeleteKNN(int id)
        {
            var kNN = await _context.KNN.FindAsync(id);
            if (kNN == null)
            {
                return NotFound();
            }

            _context.KNN.Remove(kNN);
            await _context.SaveChangesAsync();

            return kNN;
        }

        private bool KNNExists(int id)
        {
            return _context.KNN.Any(e => e.ID == id);
        }
    }
}
