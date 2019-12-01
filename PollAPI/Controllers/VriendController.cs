using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PollAPI.Models;

namespace PollAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VriendController : ControllerBase
    {
        private readonly PollContext _context;

        public VriendController(PollContext context)
        {
            _context = context;
        }

        // GET: api/Vriend
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vriend>>> GetVrienden()
        {
            return await _context.Vrienden.ToListAsync();
        }

        // GET: api/Vriend/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vriend>> GetVriend(int id)
        {
            var vriend = await _context.Vrienden.FindAsync(id);

            if (vriend == null)
            {
                return NotFound();
            }

            return vriend;
        }

        // PUT: api/Vriend/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVriend(int id, Vriend vriend)
        {
            if (id != vriend.VriendID)
            {
                return BadRequest();
            }

            _context.Entry(vriend).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VriendExists(id))
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

        // POST: api/Vriend
        [HttpPost]
        public async Task<ActionResult<Vriend>> PostVriend(Vriend vriend)
        {
            _context.Vrienden.Add(vriend);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVriend", new { id = vriend.VriendID }, vriend);
        }

        // DELETE: api/Vriend/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vriend>> DeleteVriend(int id)
        {
            var vriend = await _context.Vrienden.FindAsync(id);
            if (vriend == null)
            {
                return NotFound();
            }

            _context.Vrienden.Remove(vriend);
            await _context.SaveChangesAsync();

            return vriend;
        }

        // GET: api/Vriend/Ontvanger/1
        [HttpGet("Ontvanger/{ontvangerId}")]
        public async Task<ActionResult<IEnumerable<Vriend>>> GetVriendenWhereOntvangerId(int ontvangerId)
        {
            return await _context.Vrienden.Where(v => v.OntvangerID == ontvangerId).ToListAsync();
        }

        // GET: api/Vriend/Verzender/1
        [HttpGet("Verzender/{verzenderId}")]
        public async Task<ActionResult<IEnumerable<Vriend>>> GetVriendenWhereVerzenderId(int verzenderId)
        {
            return await _context.Vrienden.Where(v => v.VerzenderID == verzenderId).ToListAsync();
        }

        private bool VriendExists(int id)
        {
            return _context.Vrienden.Any(e => e.VriendID == id);
        }
    }
}
