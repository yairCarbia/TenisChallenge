using Microsoft.AspNetCore.Mvc;
using TorneoTenis.Business.Interfaces;
using TorneoTenis.DTOs;

namespace TorneoTenis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TorneoController : ControllerBase
    {
        private readonly ITorneoBusiness _torneoBusiness;

        public TorneoController(ITorneoBusiness torneoBusiness)
        {
            _torneoBusiness = torneoBusiness;
        }

        [HttpGet("IniciarTorneo")]
        public ActionResult<JugadorDTO> IniciarTorneo()
        {
            try
            {
                var ganador = _torneoBusiness.IniciarTorneo();
                return Ok(ganador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("TorneoFinalizados")]
        public ActionResult<List<TorneoDTO>> TorneoFinalizados([FromQuery] TorneoFiltroDTO filtro)
        {
            try
            {
                var torneos = _torneoBusiness.TorneosFinalizados(filtro);
                return Ok(torneos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
