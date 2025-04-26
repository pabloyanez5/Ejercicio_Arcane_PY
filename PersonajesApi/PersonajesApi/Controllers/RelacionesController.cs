using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonajesApi.Models;

namespace PersonajesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelacionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RelacionesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Relacion>>> GetRelaciones()
        {
            return await _context.Relaciones.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Relacion>> GetRelacion(int id)
        {
            var relacion = await _context.Relaciones.FindAsync(id);
            if (relacion == null)
                return NotFound();

            return relacion;
        }

        [HttpPost]
        public async Task<ActionResult<Relacion>> PostRelacion(Relacion relacion)
        {
            _context.Relaciones.Add(relacion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRelacion), new { id = relacion.Id }, relacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRelacion(int id, Relacion relacion)
        {
            if (id != relacion.Id)
                return BadRequest();

            _context.Entry(relacion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRelacion(int id)
        {
            var relacion = await _context.Relaciones.FindAsync(id);
            if (relacion == null)
                return NotFound();

            _context.Relaciones.Remove(relacion);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
