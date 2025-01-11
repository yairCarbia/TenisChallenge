using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorneoTenis.TDA.TorneoTenis.DTOs.TorneoTenis.TDA;

namespace TorneoTenis.TDA
{
    public class Torneo
    {
        /// <summary>
        /// Identificador único del torneo.
        /// </summary>
        public Guid IdTorneo { get; set; }

        /// <summary>
        /// Nombre del torneo.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Lista de rondas jugadas en el torneo.
        /// </summary>
        public List<Ronda> Rondas { get; set; }

        /// <summary>
        /// Lista inicial de jugadores en el torneo.
        /// </summary>
        public List<Jugador> Jugadores { get; set; }

        /// <summary>
        /// Ganador del torneo.
        /// </summary>
        public Jugador? Ganador { get; set; }

        public Torneo(string nombre, List<Jugador> jugadores)
        {
            IdTorneo = Guid.NewGuid();
            Nombre = nombre;
            Jugadores = jugadores ?? new List<Jugador>();
            Rondas = new List<Ronda>();
            Ganador = null;
        }
    }


}
