using Microsoft.EntityFrameworkCore;

namespace PersonajesApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet para cada entidad del proyecto
        public DbSet<Personaje> Personajes { get; set; }
        public DbSet<Organizacion> Organizaciones { get; set; }
        public DbSet<Afiliacion> Afiliaciones { get; set; }
        public DbSet<Relacion> Relaciones { get; set; }
    }
}
