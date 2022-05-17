using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S8_Complet.Data;
using S8_Complet.Models;

namespace S8_Complet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonneesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DonneesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donnees>>> GetData()
        {
          if (_context.Data == null)
          {
              return NotFound();
          }
            return await _context.Data.ToListAsync();
        }

        // GET: api/Data/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Donnees>> GetData(int id)
        {
          if (_context.Data == null)
          {
              return NotFound();
          }
            var data = await _context.Data.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return data;
        }

        // PUT: api/Data/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutData(int id, Donnees data)
        {
            if (id != data.Id)
            {
                return BadRequest();
            }

            _context.Entry(data).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataExists(id))
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

        // POST: api/Data
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Donnees>> PostData(Donnees data)
        {
          if (_context.Data == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Data'  is null.");
          }
            _context.Data.Add(data);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetData", new { id = data.Id }, data);
        }

        // DELETE: api/Data/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteData(int id)
        {
            if (_context.Data == null)
            {
                return NotFound();
            }
            var data = await _context.Data.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            _context.Data.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DataExists(int id)
        {
            return (_context.Data?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
