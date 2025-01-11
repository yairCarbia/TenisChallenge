namespace TorneoTenis.DTOs
{

    public class PartidoDTO
    {
        public int IdPartido { get; set; }
        public JugadorDTO Jugador1 { get; set; }
        public JugadorDTO Jugador2 { get; set; }
        public JugadorDTO Ganador { get; set; }
        public string Resultado { get; set; } 
    }

}
