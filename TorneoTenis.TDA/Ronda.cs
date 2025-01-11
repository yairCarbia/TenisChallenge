namespace TorneoTenis.TDA
{
    public class Ronda
    {
        /// <summary>
        /// Identificador único de la ronda.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Lista de partidos en la ronda.
        /// </summary>
        public List<Partido> Partidos { get; set; }

        public Ronda(List<Partido> partidos)
        {
            Id = Guid.NewGuid();
            Partidos = partidos ?? new List<Partido>();
        }



    }
}
