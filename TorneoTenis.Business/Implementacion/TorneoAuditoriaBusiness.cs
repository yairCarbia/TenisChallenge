using Newtonsoft.Json;
using TorneoTenis.Business.Interfaces;
using TorneoTenis.DTOs;

namespace TorneoTenis.Business.Implementacion
{
    public class TorneoAuditoriaBusiness : ITorneoAuditoriaBusiness
    {
        private readonly  string _rutaArchivo;
        public TorneoAuditoriaBusiness()
        {
            string rutaBaseProyecto = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\.."));
            _rutaArchivo = Path.Combine(rutaBaseProyecto, @"TorneoTenis.Helpers\Data\Auditoria.json");

        }
        /// <summary>
        /// Se registra un nuevo torneo en el archivo de auditoria. Si el archivo ya existe seagrega el torneo.
        /// </summary>
        /// <param name="torneo">Objeto que representa el torneo a registrar, con su Id, Fecha y Ganador.</param>
        public void RegistrarTorneo(TorneoDTO torneo)
        {
            List<TorneoDTO> torneosExistentes = new List<TorneoDTO>();

           
            
            if (File.Exists(_rutaArchivo))
            {
                // si existe leemos los torneos previos
                var torneos = File.ReadAllText(_rutaArchivo);
                torneosExistentes = JsonConvert.DeserializeObject<List<TorneoDTO>>(torneos) ?? new List<TorneoDTO>();
            }

            torneosExistentes?.Add(torneo);

            var torneosBitacora = JsonConvert.SerializeObject(torneosExistentes, Formatting.Indented);
            File.WriteAllText(_rutaArchivo, torneosBitacora);

        }

        /// <summary>
        /// Se obtienen la lista de torneos finalizados desde el archivo de auditoria.
        /// </summary>
        /// <returns>Una lista de torneos finalizados o una lista vacia si no existen torneos</returns>
        public List<TorneoDTO> GetTorneosFinalizados()
        {
            if (File.Exists(_rutaArchivo)){

               var torneos = File.ReadAllText(_rutaArchivo);
               return JsonConvert.DeserializeObject<List<TorneoDTO>>(torneos) ?? new List<TorneoDTO>();
            }

            return new List<TorneoDTO>();
        }

    }
}
