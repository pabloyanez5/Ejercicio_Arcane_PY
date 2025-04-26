using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonajesApi.Models;

namespace PersonajesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AfiliacionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AfiliacionesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Afiliacion>>> GetAfiliaciones()
        {
            return await _context.Afiliaciones.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Afiliacion>> GetAfiliacion(int id)
        {
            var afiliacion = await _context.Afiliaciones.FindAsync(id);
            if (afiliacion == null)
                return NotFound();

            return afiliacion;
        }

        [HttpPost]
        public async Task<ActionResult<Afiliacion>> PostAfiliacion(Afiliacion afiliacion)
        {
            _context.Afiliaciones.Add(afiliacion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAfiliacion), new { id = afiliacion.Id }, afiliacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAfiliacion(int id, Afiliacion afiliacion)
        {
            if (id != afiliacion.Id)
                return BadRequest();

            _context.Entry(afiliacion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAfiliacion(int id)
        {
            var afiliacion = await _context.Afiliaciones.FindAsync(id);
            if (afiliacion == null)
                return NotFound();

            _context.Afiliaciones.Remove(afiliacion);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
