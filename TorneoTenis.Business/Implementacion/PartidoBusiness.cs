using TorneoTenis.Business.Interfaces;
using TorneoTenis.DTOs;
using TorneoTenis.Helpers;
using TorneoTenis.Resources;

namespace TorneoTenis.Business.Implementacion
{
    public class PartidoBusiness : IPartidoBusiness
    {

        /// <summary>
        /// Simula un partido entre dos jugadores, determinando al ganador con base en habilidad, fuerza, velocidad y suerte.
        /// </summary>
        /// <param name="jugadorUno">Primer jugador.</param>
        /// <param name="jugadorDos">Segundo jugador.</param>
        /// <returns>El jugador ganador del enfrentamiento</returns>
        public JugadorDTO SimularPartido(JugadorDTO jugadorUno, JugadorDTO jugadorDos)
        {
            if (jugadorUno == null || jugadorDos == null)
                throw new ArgumentNullException(Messages.MESSAGES_ERROR_SE_REQUIEREN_2_JUGADORES);
            //la habilidad tiene un peso mayor.
            const double PONDERACION_HABILIDAD = 0.5; 
            //la fuerza tiene un peso signifcativo.
            const double PONDERACION_FUERZA = 0.3;   
            //la velocidad tiene un peso normal
            const double PONDERACION_VELOCIDAD = 0.15;
            //la suerte tiene un menor peso
            const double PONDERACION_SUERTE = 0.05;  

            Random random = new Random();

            double puntajeUno =
                (jugadorUno.NivelHabilidad * PONDERACION_HABILIDAD) +
                (jugadorUno.Fuerza * PONDERACION_FUERZA) +
                (jugadorUno.VelocidadDesplazamiento * PONDERACION_VELOCIDAD) +
                (random.NextDouble() * 10 * PONDERACION_SUERTE); 

            double puntajeDos =
                (jugadorDos.NivelHabilidad * PONDERACION_HABILIDAD) +
                (jugadorDos.Fuerza * PONDERACION_FUERZA) +
                (jugadorDos.VelocidadDesplazamiento * PONDERACION_VELOCIDAD) +
                (random.NextDouble() * 10 * PONDERACION_SUERTE); 

            return puntajeUno >= puntajeDos ? jugadorUno : jugadorDos;
        }


    }
}
