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
    public class ModelController : ControllerBase
    {
        private readonly S8_APIContext _context;

        public ModelController(S8_APIContext context)
        {
            _context = context;
        }

        // GET: api/Model
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelItem>>> GetModelItem()
        {
            return await _context.ModelItem.ToListAsync();
        }

        // GET: api/Model/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModelItem>> GetModelItem(int id)
        {
            var modelItem = await _context.ModelItem.FindAsync(id);

            if (modelItem == null)
            {
                return NotFound();
            }

            return modelItem;
        }

        // PUT: api/Model/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelItem(int id, ModelItem modelItem)
        {
            if (id != modelItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(modelItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelItemExists(id))
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

        // POST: api/Model
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ModelItem>> PostModelItem(ModelItem modelItem)
        {
            _context.ModelItem.Add(modelItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetModelItem", new { id = modelItem.Id }, modelItem);
            return CreatedAtAction(nameof(GetModelItem), new { id = modelItem.Id }, modelItem);

        }

        // DELETE: api/Model/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelItem(int id)
        {
            var modelItem = await _context.ModelItem.FindAsync(id);
            if (modelItem == null)
            {
                return NotFound();
            }

            _context.ModelItem.Remove(modelItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModelItemExists(int id)
        {
            return _context.ModelItem.Any(e => e.Id == id);
        }
    }
}
