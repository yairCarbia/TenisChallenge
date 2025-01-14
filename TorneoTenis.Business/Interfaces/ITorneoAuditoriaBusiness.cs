using TorneoTenis.DTOs;

namespace TorneoTenis.Business.Interfaces
{
    public interface ITorneoAuditoriaBusiness
    {
        void RegistrarTorneo(TorneoDTO torneo);

        List<TorneoDTO> GetTorneosFinalizados();
    }
}
