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
    public class DatasetController : ControllerBase
    {
        private readonly S8_APIContext _context;

        public DatasetController(S8_APIContext context)
        {
            _context = context;
        }

        // GET: api/Dataset
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DatasetItem>>> GetDatasetItem()
        {
            return await _context.DatasetItem.ToListAsync();
        }

        // GET: api/Dataset/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DatasetItem>> GetDatasetItem(int id)
        {
            var datasetItem = await _context.DatasetItem.FindAsync(id);

            if (datasetItem == null)
            {
                return NotFound();
            }

            return datasetItem;
        }

        // PUT: api/Dataset/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDatasetItem(int id, DatasetItem datasetItem)
        {
            if (id != datasetItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(datasetItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DatasetItemExists(id))
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

        // POST: api/Dataset
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DatasetItem>> PostDatasetItem(DatasetItem datasetItem)
        {
            _context.DatasetItem.Add(datasetItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetDatasetItem", new { id = datasetItem.Id }, datasetItem);
            return CreatedAtAction(nameof(GetDatasetItem), new { id = datasetItem.Id }, datasetItem);

        }

        // DELETE: api/Dataset/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDatasetItem(int id)
        {
            var datasetItem = await _context.DatasetItem.FindAsync(id);
            if (datasetItem == null)
            {
                return NotFound();
            }

            _context.DatasetItem.Remove(datasetItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DatasetItemExists(int id)
        {
            return _context.DatasetItem.Any(e => e.Id == id);
        }
    }
}
