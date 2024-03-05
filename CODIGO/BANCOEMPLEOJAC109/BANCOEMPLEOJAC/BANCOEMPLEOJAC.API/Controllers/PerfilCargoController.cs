using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Servicio.Interfase;
using BANCOEMPLEOJAC.Servicio.Implementacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BANCOEMPLEOJAC.API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class PerfilCargoController : ControllerBase
    {
        private readonly IPerfilCargoServicio _perfilCargoServicio;
        public PerfilCargoController(IPerfilCargoServicio perfilCargoServicio)
        {
            _perfilCargoServicio = perfilCargoServicio;
        }
        [HttpGet("Lista/{buscar?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var response = new ResponseDTO<List<PerfilCargoDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _perfilCargoServicio.Lista(buscar);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("Obtener/{Id:int?}")]
        public async Task<IActionResult> Obtener(int Id)
        {
            var response = new ResponseDTO<PerfilCargoDTO>();

            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _perfilCargoServicio.Obtener(Id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] PerfilCargoDTO modelo)
        {
            var response = new ResponseDTO<PerfilCargoDTO>();

            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _perfilCargoServicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] PerfilCargoDTO modelo)
        {
            var response = new ResponseDTO<bool>();

            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _perfilCargoServicio.Editar(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("Eliminar/{Id:int}")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            var response = new ResponseDTO<bool>();

            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _perfilCargoServicio.Eliminar(Id);
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
