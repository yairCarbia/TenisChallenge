using TorneoTenis.DTOs;

namespace TorneoTenis.Business.Interfaces
{
    public interface IPartidoBusiness
    {
  
        /// <summary>
        /// Simula un partido entre dos jugadores y determina al ganador.
        /// </summary>
        /// <param name="jugador1">Primer jugador.</param>
        /// <param name="jugador2">Segundo jugador.</param>
        /// <returns>El jugador ganador del partido.</returns>
        JugadorDTO SimularPartido(JugadorDTO jugador1, JugadorDTO jugador2);
    }
}
