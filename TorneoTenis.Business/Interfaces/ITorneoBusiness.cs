using TorneoTenis.DTOs;

namespace TorneoTenis.Business.Interfaces
{
    public interface ITorneoBusiness
    {
        /// <summary>
        /// Inicia el torneo partir de una lista de jugadores.
        /// </summary>
        /// <param name="jugadores">Lista de jugadores participantes.</param>
        /// <returns>Jugador ganador del torneo.</returns>
        JugadorDTO IniciarTorneo();
      
    }
}
