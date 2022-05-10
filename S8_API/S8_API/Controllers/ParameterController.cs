#nullable disable
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
    public class ParameterController : ControllerBase
    {
        private readonly S8_APIContext _context;

        public ParameterController(S8_APIContext context)
        {
            _context = context;
        }

        // GET: api/Parameter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParameterItem>>> GetParameterItem()
        {
            return await _context.ParameterItem.ToListAsync();
        }

        // GET: api/Parameter/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParameterItem>> GetParameterItem(int id)
        {
            var parameterItem = await _context.ParameterItem.FindAsync(id);

            if (parameterItem == null)
            {
                return NotFound();
            }

            return parameterItem;
        }

        // PUT: api/Parameter/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParameterItem(int id, ParameterItem parameterItem)
        {
            if (id != parameterItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(parameterItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParameterItemExists(id))
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

        // POST: api/Parameter
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParameterItem>> PostParameterItem(ParameterItem parameterItem)
        {
            _context.ParameterItem.Add(parameterItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParameterItem", new { id = parameterItem.Id }, parameterItem);
        }

        // DELETE: api/Parameter/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParameterItem(int id)
        {
            var parameterItem = await _context.ParameterItem.FindAsync(id);
            if (parameterItem == null)
            {
                return NotFound();
            }

            _context.ParameterItem.Remove(parameterItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParameterItemExists(int id)
        {
            return _context.ParameterItem.Any(e => e.Id == id);
        }
    }
}
