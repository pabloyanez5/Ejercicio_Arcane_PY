namespace PersonajesApi.Models
{
    public class Afiliacion
    {
        public int Id { get; set; }
        public int PersonajeId { get; set; }
        public int OrganizacionId { get; set; }

        // Relación con Personaje
        public Personaje Personaje { get; set; }

        // Relación con Organizacion
        public Organizacion Organizacion { get; set; }
    }
}
