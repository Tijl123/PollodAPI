﻿using System;
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
    public class PollGebruikerController : ControllerBase
    {
        private readonly PollContext _context;

        public PollGebruikerController(PollContext context)
        {
            _context = context;
        }

        // GET: api/PollGebruiker
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PollGebruiker>>> GetPollGebruikers()
        {
            return await _context.PollGebruikers.ToListAsync();
        }

        // GET: api/PollGebruiker/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PollGebruiker>> GetPollGebruiker(int id)
        {
            var pollGebruiker = await _context.PollGebruikers.FindAsync(id);

            if (pollGebruiker == null)
            {
                return NotFound();
            }

            return pollGebruiker;
        }

        // PUT: api/PollGebruiker/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPollGebruiker(int id, PollGebruiker pollGebruiker)
        {
            if (id != pollGebruiker.PollGebruikerID)
            {
                return BadRequest();
            }

            _context.Entry(pollGebruiker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PollGebruikerExists(id))
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

        // POST: api/PollGebruiker
        [HttpPost]
        public async Task<ActionResult<PollGebruiker>> PostPollGebruiker(PollGebruiker pollGebruiker)
        {
            _context.PollGebruikers.Add(pollGebruiker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPollGebruiker", new { id = pollGebruiker.PollGebruikerID }, pollGebruiker);
        }

        // DELETE: api/PollGebruiker/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PollGebruiker>> DeletePollGebruiker(int id)
        {
            var pollGebruiker = await _context.PollGebruikers.FindAsync(id);
            if (pollGebruiker == null)
            {
                return NotFound();
            }

            _context.PollGebruikers.Remove(pollGebruiker);
            await _context.SaveChangesAsync();

            return pollGebruiker;
        }

        // GET: api/PollGebruiker/Gebruiker/1
        [HttpGet("Gebruiker/{gebruikerId}")]
        public async Task<ActionResult<IEnumerable<PollGebruiker>>> GetPollGebruikersWhereGebruikerId(int gebruikerId)
        {            
            return await _context.PollGebruikers.Where(p => p.GebruikerID == gebruikerId).ToListAsync();
        }

        private bool PollGebruikerExists(int id)
        {
            return _context.PollGebruikers.Any(e => e.PollGebruikerID == id);
        }
    }
}
