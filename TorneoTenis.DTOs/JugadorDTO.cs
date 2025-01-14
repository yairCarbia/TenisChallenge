namespace TorneoTenis.DTOs
{
    public class JugadorDTO
    {
        public Guid IdJugador { get; set; }
        public string Nombre { get; set; } = null!;
        public string Genero { get; set; } = null!;
        public int NivelHabilidad { get; set; }
        public int Fuerza { get; set; }
        public int VelocidadDesplazamiento { get; set; }
    }
}
