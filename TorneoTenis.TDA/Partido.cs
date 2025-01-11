using TorneoTenis.TDA.TorneoTenis.DTOs.TorneoTenis.TDA;

namespace TorneoTenis.TDA
{

    public class Partido
    {
        /// <summary>
        /// Identificador único del partido.
        /// </summary>
        public Guid IdPartido { get; set; }

        /// <summary>
        /// Jugador 1 en el partido.
        /// </summary>
        public Jugador Jugador1 { get; set; }

        /// <summary>
        /// Jugador 2 en el partido.
        /// </summary>
        public Jugador Jugador2 { get; set; }

        public Partido(Jugador jugador1, Jugador jugador2)
        {
            IdPartido = Guid.NewGuid();
            Jugador1 = jugador1;
            Jugador2 = jugador2;
        }
    }


}
