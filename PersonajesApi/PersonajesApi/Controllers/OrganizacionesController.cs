using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonajesApi.Models;

namespace PersonajesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizacionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrganizacionesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organizacion>>> GetOrganizaciones()
        {
            return await _context.Organizaciones.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Organizacion>> GetOrganizacion(int id)
        {
            var org = await _context.Organizaciones.FindAsync(id);
            if (org == null)
                return NotFound();

            return org;
        }

        [HttpPost]
        public async Task<ActionResult<Organizacion>> PostOrganizacion(Organizacion org)
        {
            _context.Organizaciones.Add(org);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOrganizacion), new { id = org.Id }, org);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizacion(int id, Organizacion org)
        {
            if (id != org.Id)
                return BadRequest();

            _context.Entry(org).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizacion(int id)
        {
            var org = await _context.Organizaciones.FindAsync(id);
            if (org == null)
                return NotFound();

            _context.Organizaciones.Remove(org);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
