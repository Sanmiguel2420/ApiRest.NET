using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiRestNET.Contexto;
using ApiRestNET.Models;

namespace ApiRestNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CochesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CochesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Coches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coche>>> Getcoches()
        {
            return await _context.coches.ToListAsync();
        }

        // GET: api/Coches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coche>> GetCoche(int id)
        {
            var coche = await _context.coches.FindAsync(id);

            if (coche == null)
            {
                return NotFound();
            }

            return coche;
        }

        // PUT: api/Coches/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoche(int id, Coche coche)
        {
            if (id != coche.Id)
            {
                return BadRequest();
            }

            _context.Entry(coche).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CocheExists(id))
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

        // POST: api/Coches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Coche>> PostCoche(Coche coche)
        {
            _context.coches.Add(coche);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoche", new { id = coche.Id }, coche);
        }

        // DELETE: api/Coches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoche(int id)
        {
            var coche = await _context.coches.FindAsync(id);
            if (coche == null)
            {
                return NotFound();
            }

            _context.coches.Remove(coche);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CocheExists(int id)
        {
            return _context.coches.Any(e => e.Id == id);
        }
    }
}
