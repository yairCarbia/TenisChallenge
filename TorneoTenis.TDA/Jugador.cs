namespace TorneoTenis.TDA
{
    namespace TorneoTenis.DTOs
    {
        namespace TorneoTenis.TDA
        {
            public class Jugador
            {
                /// <summary>
                /// Identificador unico del jugador en el torneo.
                /// </summary>
                public Guid IdJugador { get; set; }

                /// <summary>
                /// Nombre del jugador.
                /// </summary>
                public string Nombre { get; set; }

                /// <summary>
                /// Apellido del jugador.
                /// </summary>
                public string Apellido { get; set; }

                /// <summary>
                /// Genero del jugador.
                /// </summary>
                public string Genero { get; set; }

                /// <summary>
                /// Nivel de habilidad del jugador (0-100).
                /// </summary>
                public int NivelHabilidad { get; set; }

                /// <summary>
                /// Fuerza fisica del jugador.
                /// </summary>
                public int Fuerza { get; set; }

                /// <summary>
                /// Velocidad de desplazamiento del jugador.
                /// </summary>
                public int Velocidad { get; set; }

                /// <summary>
                /// Constructor para inicializar un jugador.
                /// </summary>
                /// <param name="nombre">Nombre del jugador.</param>
                /// <param name="apellido">Apellido del jugador.</param>
                /// <param name="genero">Género del jugador.</param>
                /// <param name="nivelHabilidad">Nivel de habilidad del jugador (0-100).</param>
                /// <param name="fuerza">Fuerza fisica del jugador.</param>
                /// <param name="velocidad">Velocidad del jugador.</param>
                public Jugador(string nombre, string apellido, string genero, int nivelHabilidad, int fuerza, int velocidad)
                {
                    IdJugador = Guid.NewGuid();
                    Nombre = nombre;
                    Apellido = apellido;
                    Genero = genero;
                    NivelHabilidad = nivelHabilidad;
                    Fuerza = fuerza;
                    Velocidad = velocidad;
                }

                /// <summary>
                /// Calcula un puntaje total para el jugador considerando habilidad, fuerza, velocidad y suerte.
                /// </summary>
                /// <returns>Puntaje total del jugador para determinar el ganador.</returns>
                public int CalcularPuntaje()
                {
                    Random random = new Random();
                    int suerte = random.Next(0, 21);
                    return NivelHabilidad + Fuerza + Velocidad + suerte;
                }
            }
        }

    }

}
