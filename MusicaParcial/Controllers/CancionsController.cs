using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicaParcial.Models;

namespace MusicaParcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CancionsController : ControllerBase
    {
        private readonly DätaContext _context;

        public CancionsController(DätaContext context)
        {
            _context = context;
        }

        // GET: api/Cancions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cancion>>> GetCancion()
        {
            return await _context.Cancion.ToListAsync();
        }

        // GET: api/Cancions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cancion>> GetCancion(string id)
        {
            var cancion = await _context.Cancion.FindAsync(id);

            if (cancion == null)
            {
                return NotFound();
            }

            return cancion;
        }

        // PUT: api/Cancions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCancion(string id, Cancion cancion)
        {
            if (id != cancion.Nombre)
            {
                return BadRequest();
            }

            _context.Entry(cancion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CancionExists(id))
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

        // POST: api/Cancions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cancion>> PostCancion(Cancion cancion)
        {
            _context.Cancion.Add(cancion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CancionExists(cancion.Nombre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCancion", new { id = cancion.Nombre }, cancion);
        }

        // DELETE: api/Cancions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCancion(string id)
        {
            var cancion = await _context.Cancion.FindAsync(id);
            if (cancion == null)
            {
                return NotFound();
            }

            _context.Cancion.Remove(cancion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CancionExists(string id)
        {
            return _context.Cancion.Any(e => e.Nombre == id);
        }
    }
}
