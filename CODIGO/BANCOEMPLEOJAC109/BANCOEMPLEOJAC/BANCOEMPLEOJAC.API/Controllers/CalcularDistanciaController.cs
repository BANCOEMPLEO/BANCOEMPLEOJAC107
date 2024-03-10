using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Servicio.Interfase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BANCOEMPLEOJAC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcularDistanciaController : ControllerBase
    {
        private readonly IDistanciaServicio _distanciaServicio;

        public CalcularDistanciaController(IDistanciaServicio distanciaServicio)
        {
                _distanciaServicio = distanciaServicio;
        }
        [HttpPost("Consultar")]
        public async Task<IActionResult> Consultar([FromBody] DistanciaDTO modelo)
        {
            var response = new ResponseDTO<double>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _distanciaServicio.CalcularDistancia(modelo);
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
