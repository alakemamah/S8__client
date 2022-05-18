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
    public class RandomForestsController : ControllerBase
    {
        private readonly S8__APIContext _context;

        public RandomForestsController(S8__APIContext context)
        {
            _context = context;
        }

        // GET: api/RandomForests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RandomForest>>> GetRandomForest()
        {
            return await _context.RandomForest.ToListAsync();
        }

        // GET: api/RandomForests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RandomForest>> GetRandomForest(int id)
        {
            var randomForest = await _context.RandomForest.FindAsync(id);

            if (randomForest == null)
            {
                return NotFound();
            }

            return randomForest;
        }

        // PUT: api/RandomForests/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRandomForest(int id, RandomForest randomForest)
        {
            if (id != randomForest.ID)
            {
                return BadRequest();
            }

            _context.Entry(randomForest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RandomForestExists(id))
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

        // POST: api/RandomForests
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RandomForest>> PostRandomForest(RandomForest randomForest)
        {
            _context.RandomForest.Add(randomForest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRandomForest", new { id = randomForest.ID }, randomForest);
        }

        // DELETE: api/RandomForests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RandomForest>> DeleteRandomForest(int id)
        {
            var randomForest = await _context.RandomForest.FindAsync(id);
            if (randomForest == null)
            {
                return NotFound();
            }

            _context.RandomForest.Remove(randomForest);
            await _context.SaveChangesAsync();

            return randomForest;
        }

        private bool RandomForestExists(int id)
        {
            return _context.RandomForest.Any(e => e.ID == id);
        }
    }
}
