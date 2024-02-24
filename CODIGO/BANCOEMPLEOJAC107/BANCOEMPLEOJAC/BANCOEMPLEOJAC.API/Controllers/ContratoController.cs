using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Servicio.Contrato;
using BANCOEMPLEOJAC.Servicio.Implementacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BANCOEMPLEOJAC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private readonly IContratoServicio _contratoServicio;
        public ContratoController(IContratoServicio contratoServicio)
        {
            _contratoServicio = contratoServicio;
        }

        [HttpPost("RegistrarEmpleo")]
        public async Task<IActionResult> RegistrarEmpleo([FromBody] ContratoDTO modelo)
        {
            var response = new ResponseDTO<ContratoDTO>();
            try
            {

                response.EsCorrecto = true;
                var tipo = "Empleo";
                response.Resultado = await _contratoServicio.Registrar(tipo, modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("RegistrarServicio")]
        public async Task<IActionResult> RegistrarServicio([FromBody] ContratoDTO modelo)
        {
            var response = new ResponseDTO<ContratoDTO>();
            try
            {

                response.EsCorrecto = true;
                var tipo = "Servicio";
                response.Resultado = await _contratoServicio.Registrar(tipo, modelo);
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
