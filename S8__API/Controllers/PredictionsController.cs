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
    public class PredictionsController : ControllerBase
    {
        private readonly S8__APIContext _context;

        public PredictionsController(S8__APIContext context)
        {
            _context = context;
        }

        // GET: api/Predictions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prediction>>> GetPrediction()
        {
            return await _context.Prediction.ToListAsync();
        }

        // GET: api/Predictions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prediction>> GetPrediction(int id)
        {
            var prediction = await _context.Prediction.FindAsync(id);

            if (prediction == null)
            {
                return NotFound();
            }

            return prediction;
        }

        // PUT: api/Predictions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrediction(int id, Prediction prediction)
        {
            if (id != prediction.ID)
            {
                return BadRequest();
            }

            _context.Entry(prediction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PredictionExists(id))
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

        // POST: api/Predictions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Prediction>> PostPrediction(Prediction prediction)
        {
            _context.Prediction.Add(prediction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrediction", new { id = prediction.ID }, prediction);
        }

        // DELETE: api/Predictions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Prediction>> DeletePrediction(int id)
        {
            var prediction = await _context.Prediction.FindAsync(id);
            if (prediction == null)
            {
                return NotFound();
            }

            _context.Prediction.Remove(prediction);
            await _context.SaveChangesAsync();

            return prediction;
        }

        private bool PredictionExists(int id)
        {
            return _context.Prediction.Any(e => e.ID == id);
        }
    }
}
