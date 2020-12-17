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
    public class ParcelBagsController : ControllerBase
    {
        private readonly PO_DBContext _context;

        public ParcelBagsController(PO_DBContext context)
        {
            _context = context;
        }

        // GET: api/ParcelBags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParcelBag>>> GetParcelBags()
        {
            return await _context.ParcelBags.ToListAsync();
        }

        // GET: api/ParcelBags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParcelBag>> GetParcelBag(int id)
        {
            var parcelBag = await _context.ParcelBags.FindAsync(id);

            if (parcelBag == null)
            {
                return NotFound();
            }

            return parcelBag;
        }

        // PUT: api/ParcelBags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParcelBag(int id, ParcelBag parcelBag)
        {
            if (id != parcelBag.PbagId)
            {
                return BadRequest();
            }

            _context.Entry(parcelBag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParcelBagExists(id))
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

        // POST: api/ParcelBags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParcelBag>> PostParcelBag(ParcelBag parcelBag)
        {
            _context.ParcelBags.Add(parcelBag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParcelBag", new { id = parcelBag.PbagId }, parcelBag);
        }

        // DELETE: api/ParcelBags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParcelBag(int id)
        {
            var parcelBag = await _context.ParcelBags.FindAsync(id);
            if (parcelBag == null)
            {
                return NotFound();
            }

            _context.ParcelBags.Remove(parcelBag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParcelBagExists(int id)
        {
            return _context.ParcelBags.Any(e => e.PbagId == id);
        }
    }
}
