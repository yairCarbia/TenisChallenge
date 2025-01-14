using TorneoTenis.DTOs;

namespace TorneoTenis.Business.Interfaces
{
    public interface ITorneoBusiness
    {
   
        JugadorDTO IniciarTorneo();

        List<TorneoDTO> TorneosFinalizados(TorneoFiltroDTO filtro);

    }
}
