using TorneoTenis.Business.Interfaces;
using TorneoTenis.DTOs;
using TorneoTenis.Helpers;
using TorneoTenis.Resources;
using TorneoTenis.TDA.TorneoTenis.DTOs.TorneoTenis.TDA;

namespace TorneoTenis.Business.Implementacion
{
    public class TorneoBusiness : ITorneoBusiness
    {
        private readonly IPartidoBusiness _partidoBusiness;
        private JugadorDTO _ganador;
        public TorneoBusiness(IPartidoBusiness partidoBusiness)
        {
            _partidoBusiness = partidoBusiness;
        }

        #region Funciones Principales del TORNEO.
        /// <summary>
        /// Inicia el torneo de tenis y devuelve el ganador de la misma.
        /// </summary>
        /// <returns></returns>
        public JugadorDTO IniciarTorneo()
        {
            List<JugadorDTO> jugadores = InicializarDatosDelTorneo();
            return SimularTorneo(jugadores);
        }
        /// <summary>
        /// Simula el torneo de eliminación directa y devuelve al ganador.
        /// </summary>
        /// <param name="jugadores">Lista de jugadores</param>
        /// <returns>El ganador del torneo.</returns>
        private JugadorDTO SimularTorneo(List<JugadorDTO> jugadores)
        {
            //mientra existan mas de 1 jugador.
            while (jugadores.Count > 1)
            {
                List<JugadorDTO> ganadoresDeLaRonda = new List<JugadorDTO>();
                
                //ordenamos de forma aleatoria la lista de jugadores.
                jugadores = jugadores.OrderBy(_ => Guid.NewGuid()).ToList();

                PasaDeRondaAutomatico(jugadores, ganadoresDeLaRonda);
                
                jugadores = GenerarEnfrentamientosDeLaRonda(jugadores, ganadoresDeLaRonda);
            }

            return jugadores.First();
        }
        /// <summary>
        /// Se procede a generar los enfrentamientos entre los jugadores de la ronda correspondiente.
        /// </summary>
        /// <param name="jugadoresCompitiendo">Lista de jugadores</param>
        /// <param name="ganadoresDeLaRonda">Lista de jugadores ganadores de la ronda</param>
        /// <returns>Lista de jugadores ganadores de la ronda</returns>
        private List<JugadorDTO> GenerarEnfrentamientosDeLaRonda(List<JugadorDTO> jugadoresCompitiendo, List<JugadorDTO> ganadoresDeLaRonda)
        {
            //se simula los partidos de aquellos que se encuentren compitiendo.
            for (int i = 0; i < jugadoresCompitiendo.Count; i += 2)
            {
                var jugadorUno = jugadoresCompitiendo[i];
                var jugadorDos = jugadoresCompitiendo[i + 1];

                JugadorDTO ganador = _partidoBusiness.SimularPartido(jugadorUno, jugadorDos);
                ganadoresDeLaRonda.Add(ganador);
            }
            //solo pasan a la siguiente ronda los ganadores.
            jugadoresCompitiendo = ganadoresDeLaRonda;
            return jugadoresCompitiendo;
        }


        /// <summary>
        /// Si hay un numero impar de jugadores uno pasa automanticamente.
        /// </summary>
        /// <param name="jugadoresCompitiendo">Lista de jugadores</param>
        /// <param name="ganadoresDeLaRonda">Lista de jugadores ganadores de la ronda</param>
        private static void PasaDeRondaAutomatico(List<JugadorDTO> jugadoresCompitiendo, List<JugadorDTO> ganadoresDeLaRonda)
        {
            //Si son impares
            if (jugadoresCompitiendo.Count % 2 != 0)
            {
                //El jugador pasa de ronda.
                ganadoresDeLaRonda.Add(jugadoresCompitiendo.Last());
                jugadoresCompitiendo.RemoveAt(jugadoresCompitiendo.Count - 1);
            }
        }
        #endregion
        #region Inicializacion de datos.
        /// <summary>
        /// Inicializa los datos necesarios para el torneo, cargando los jugadores y validandolos.
        /// </summary>
        private static List<JugadorDTO> InicializarDatosDelTorneo()
        {
            List<Jugador> jugadores = GetJugadoresJson();

            ValidarListadoJugadores(jugadores);

            return MapJugadoresDTO(jugadores);
        }
        /// <summary>
        /// Carga la lista de jugadores desde un archivo JSON.
        /// </summary>
        private static List<Jugador> GetJugadoresJson()
        {
            string rutaBaseProyecto = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\"));

            string rutaArchivo = Path.Combine(rutaBaseProyecto, @"TorneoTenis.Helpers\Data\jugadores.json");

            if (!System.IO.File.Exists(rutaArchivo))
            {
                throw new FileNotFoundException(Messages.MESSAGES_ERROR_NO_SE_ENCONTRO_EL_ARCHIVO_JSON.Format(rutaArchivo));
            }

            var jugadores = JsonHelper.GetJugadoresFromJson(rutaArchivo);
            return jugadores;
        }
        #endregion
        #region Mappear Jugador a JugadorDTO
        /// <summary>
        /// Convierte una lista de jugadores a su DTO.
        /// </summary>
        /// <param name="jugadores">Lista de jugadores a transformar en JugadorDTO</param>
        private static List<JugadorDTO> MapJugadoresDTO(List<Jugador> jugadores)
        {
            return jugadores.Select(j => new JugadorDTO
            {
                IdJugador = j.IdJugador,
                Nombre = j.Nombre,
                Genero = j.Genero,
                NivelHabilidad = j.NivelHabilidad,
                Fuerza = j.Fuerza,
                VelocidadDesplazamiento = j.VelocidadDesplazamiento
            }).ToList();
        }
        #endregion
        #region Validaciones
        /// <summary>
        /// Valida que la lista de jugadores sea válida para el torneo.
        /// </summary>
        /// <param name="jugadores">Lista de jugadores a validar.</param>
        private static void ValidarListadoJugadores(List<Jugador> jugadores)
        {
            if (jugadores == null || jugadores.Count == 0) throw new InvalidOperationException(Messages.MESSAGES_ERROR_LISTA_JUGADORES_VACIA);
            if (jugadores.Count.EsPotenciaDeDos()) throw new InvalidOperationException(Messages.MESSAGES_ERROR_CANTIDAD_JUGADORES_POTENCIA_DE_2);
        }
        #endregion
    }
}
