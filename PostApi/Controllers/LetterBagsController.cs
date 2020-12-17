using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostApi.Models;

namespace PostApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LetterBagsController : ControllerBase
    {
        private readonly PO_DBContext _context;

        public LetterBagsController(PO_DBContext context)
        {
            _context = context;
        }

        // GET: api/LetterBags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LetterBag>>> GetLetterBags()
        {
            return await _context.LetterBags.ToListAsync();
        }

        // GET: api/LetterBags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LetterBag>> GetLetterBag(int id)
        {
            var letterBag = await _context.LetterBags.FindAsync(id);

            if (letterBag == null)
            {
                return NotFound();
            }

            return letterBag;
        }

        // PUT: api/LetterBags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLetterBag(int id, LetterBag letterBag)
        {
            if (id != letterBag.LbagId)
            {
                return BadRequest();
            }

            _context.Entry(letterBag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LetterBagExists(id))
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

        // POST: api/LetterBags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LetterBag>> PostLetterBag(LetterBag letterBag)
        {
            _context.LetterBags.Add(letterBag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLetterBag", new { id = letterBag.LbagId }, letterBag);
        }

        // DELETE: api/LetterBags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLetterBag(int id)
        {
            var letterBag = await _context.LetterBags.FindAsync(id);
            if (letterBag == null)
            {
                return NotFound();
            }

            _context.LetterBags.Remove(letterBag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LetterBagExists(int id)
        {
            return _context.LetterBags.Any(e => e.LbagId == id);
        }
    }
}
