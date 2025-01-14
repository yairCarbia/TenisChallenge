using Microsoft.AspNetCore.Mvc;
using TorneoTenis.Business.Interfaces;
using TorneoTenis.DTOs;
using TorneoTenis.Resources;
using System.IO;

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
            catch (FileNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
         
        }

    }
}
