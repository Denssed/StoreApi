using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApi.Data;
using StoreApi.Entities;


namespace StoreApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BatchController : Controller
    {
        private readonly AppDbContext _context;

        public BatchController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/batch
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Batch>>> GetBatches()
        {
            foreach (var header in Request.Headers)
            {
                Console.WriteLine($"{header.Key}: {header.Value}");
            }

            return await _context.Batches.ToListAsync();
        }

        // GET: api/batch/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Batch>> GetBatch(int id)
        {
            var batch = await _context.Batches.FindAsync(id);
            if (batch == null)
            {
                return NotFound();
            }
            return Ok(batch);
        }

        // POST: api/batch
        [HttpPost]
        public async Task<ActionResult<Batch>> PostBatch(Batch batch)
        {
            _context.Batches.Add(batch);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetBatch", new { id = batch.IdBatch }, batch);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBatch(int id, Batch batch)
        {
            if (id != batch.IdBatch)
            {
                return BadRequest();
            }
            _context.Entry(batch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatchExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBatch(int id)
        {
            var batch = await _context.Batches.FindAsync(id);
            if (batch == null)
            {
                return NotFound();
            }
            _context.Batches.Remove(batch);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool BatchExists(int id)
        {
            return _context.Batches.Any(e => e.IdBatch == id);
        }
    }
}
