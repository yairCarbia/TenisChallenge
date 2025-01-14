namespace TorneoTenis.DTOs
{
    public class TorneoDTO
    {
        public Guid IdTorneo { get; set; }

        public DateTime Fecha { get; set; }
        public string Ganador { get; set; } = string.Empty;

    }
}
