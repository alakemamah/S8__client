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
    public class ResultController : ControllerBase
    {
        private readonly S8_APIContext _context;

        public ResultController(S8_APIContext context)
        {
            _context = context;
        }

        // GET: api/Result
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResultItem>>> GetResultItem()
        {
            return await _context.ResultItem.ToListAsync();
        }

        // GET: api/Result/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResultItem>> GetResultItem(int id)
        {
            var resultItem = await _context.ResultItem.FindAsync(id);

            if (resultItem == null)
            {
                return NotFound();
            }

            return resultItem;
        }

        // PUT: api/Result/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResultItem(int id, ResultItem resultItem)
        {
            if (id != resultItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(resultItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResultItemExists(id))
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

        // POST: api/Result
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResultItem>> PostResultItem(ResultItem resultItem)
        {
            _context.ResultItem.Add(resultItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResultItem", new { id = resultItem.Id }, resultItem);
        }

        // DELETE: api/Result/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResultItem(int id)
        {
            var resultItem = await _context.ResultItem.FindAsync(id);
            if (resultItem == null)
            {
                return NotFound();
            }

            _context.ResultItem.Remove(resultItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResultItemExists(int id)
        {
            return _context.ResultItem.Any(e => e.Id == id);
        }
    }
}
