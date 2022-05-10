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
    public class ParamValueIController : ControllerBase
    {
        private readonly S8_APIContext _context;

        public ParamValueIController(S8_APIContext context)
        {
            _context = context;
        }

        // GET: api/ParamValueI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParamValueItem>>> GetParamValueItem()
        {
            return await _context.ParamValueItem.ToListAsync();
        }

        // GET: api/ParamValueI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParamValueItem>> GetParamValueItem(int id)
        {
            var paramValueItem = await _context.ParamValueItem.FindAsync(id);

            if (paramValueItem == null)
            {
                return NotFound();
            }

            return paramValueItem;
        }

        // PUT: api/ParamValueI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParamValueItem(int id, ParamValueItem paramValueItem)
        {
            if (id != paramValueItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(paramValueItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParamValueItemExists(id))
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

        // POST: api/ParamValueI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParamValueItem>> PostParamValueItem(ParamValueItem paramValueItem)
        {
            _context.ParamValueItem.Add(paramValueItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParamValueItem", new { id = paramValueItem.Id }, paramValueItem);
        }

        // DELETE: api/ParamValueI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParamValueItem(int id)
        {
            var paramValueItem = await _context.ParamValueItem.FindAsync(id);
            if (paramValueItem == null)
            {
                return NotFound();
            }

            _context.ParamValueItem.Remove(paramValueItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParamValueItemExists(int id)
        {
            return _context.ParamValueItem.Any(e => e.Id == id);
        }
    }
}
