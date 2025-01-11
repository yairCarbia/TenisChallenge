namespace TorneoTenis.DTOs
{
    public class TorneoDTO
    {
        public string NombreTorneo { get; set; } = string.Empty;    
        public List<RondaDTO> Rondas { get; set; } = new List<RondaDTO>();
        public JugadorDTO? Ganador { get; set; }
    }
}
