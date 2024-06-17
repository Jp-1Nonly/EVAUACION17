
using ApiPeaje.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPeaje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeajeController : ControllerBase
    {
        private readonly ApplicationdDbContext _context;

        public PeajeController(ApplicationdDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Peaje>>> GetPeajes()
        {
            return await _context.peajes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Peaje>> GetPeaje(int id)
        {
            var peaje = await _context.peajes.FindAsync(id);

            if (peaje == null)
            {
                return NotFound();
            }

            return peaje;
        }

        [HttpPost]
        public async Task<ActionResult<Peaje>> PostPeaje(Peaje peaje)
        {
            _context.peajes.Add(peaje);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPeaje", new { id = peaje.PeajeId }, peaje);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeaje(int id, Peaje peaje)
        {
            if (id != peaje.PeajeId)
            {
                return BadRequest();
            }

            _context.Entry(peaje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeajeExists(id))
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
        public async Task<IActionResult> DeletePeaje(int id)
        {
            var peaje = await _context.peajes.FindAsync(id);
            if (peaje == null)
            {
                return NotFound();
            }

            _context.peajes.Remove(peaje);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PeajeExists(int id)
        {
            return _context.peajes.Any(e => e.PeajeId == id);
        }
    }
}
