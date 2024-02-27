using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Servicio.Interfase;
using BANCOEMPLEOJAC.Utilidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BANCOEMPLEOJAC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioCorreoController : ControllerBase
    {
        private readonly IEnvioCorreoServicio _enviocorreoServicio;
        public EnvioCorreoController(IEnvioCorreoServicio enviocorreoServicio)
        {
            _enviocorreoServicio = enviocorreoServicio;
        }

        [HttpPost("Enviar")]
        public async Task<IActionResult> Enviar([FromBody] MensajeCorreoDTO modelo)
        {
            var response = new ResponseDTO<MensajeCorreoDTO>();

            try
            {
                //modelo.Para = "";
                response.EsCorrecto = true;
               // response.Resultado = (bool)await _enviocorreoServicio.Enviar(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

    }
}
