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
    public class DonneesController : ControllerBase
    {
        private readonly S8_APIContext _context;

        public DonneesController(S8_APIContext context)
        {
            _context = context;
        }

        // GET: api/Donnees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donnees>>> GetDonnees()
        {
          if (_context.Donnees == null)
          {
              return NotFound();
          }
            return await _context.Donnees.ToListAsync();
        }

        // GET: api/Donnees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Donnees>> GetDonnees(int id)
        {
          if (_context.Donnees == null)
          {
              return NotFound();
          }
            var donnees = await _context.Donnees.FindAsync(id);

            if (donnees == null)
            {
                return NotFound();
            }

            return donnees;
        }

        // PUT: api/Donnees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonnees(int id, Donnees donnees)
        {
            if (id != donnees.Id)
            {
                return BadRequest();
            }

            _context.Entry(donnees).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonneesExists(id))
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

        // POST: api/Donnees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Donnees>> PostDonnees(Donnees donnees)
        {
          if (_context.Donnees == null)
          {
              return Problem("Entity set 'S8_APIContext.Donnees'  is null.");
          }
            _context.Donnees.Add(donnees);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDonnees", new { id = donnees.Id }, donnees);
        }

        // DELETE: api/Donnees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonnees(int id)
        {
            if (_context.Donnees == null)
            {
                return NotFound();
            }
            var donnees = await _context.Donnees.FindAsync(id);
            if (donnees == null)
            {
                return NotFound();
            }

            _context.Donnees.Remove(donnees);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DonneesExists(int id)
        {
            return (_context.Donnees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
