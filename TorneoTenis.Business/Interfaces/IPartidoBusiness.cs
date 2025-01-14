using TorneoTenis.DTOs;

namespace TorneoTenis.Business.Interfaces
{
    public interface IPartidoBusiness
    {
  
      
        JugadorDTO SimularPartido(JugadorDTO jugador1, JugadorDTO jugador2);
    }
}
