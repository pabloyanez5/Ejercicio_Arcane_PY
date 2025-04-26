namespace PersonajesApi.Models
{
    public class Relacion
    {
        public int Id { get; set; }
        public int PersonajeId1 { get; set; }
        public int PersonajeId2 { get; set; }
        public string Tipo { get; set; }

        // Relación con los personajes
        public Personaje Personaje1 { get; set; }
        public Personaje Personaje2 { get; set; }
    }
}
