using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonajesApi.Models;

namespace PersonajesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PersonajesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personaje>>> GetPersonajes()
        {
            return await _context.Personajes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personaje>> GetPersonaje(int id)
        {
            var personaje = await _context.Personajes.FindAsync(id);
            if (personaje == null)
                return NotFound();

            return personaje;
        }

        [HttpPost]
        public async Task<ActionResult<Personaje>> PostPersonaje(Personaje personaje)
        {
            _context.Personajes.Add(personaje);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPersonaje), new { id = personaje.Id }, personaje);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonaje(int id, Personaje personaje)
        {
            if (id != personaje.Id)
                return BadRequest();

            _context.Entry(personaje).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonaje(int id)
        {
            var personaje = await _context.Personajes.FindAsync(id);
            if (personaje == null)
                return NotFound();

            _context.Personajes.Remove(personaje);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
