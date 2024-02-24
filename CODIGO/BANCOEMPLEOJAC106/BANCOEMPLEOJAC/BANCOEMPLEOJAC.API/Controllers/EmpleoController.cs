using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Servicio.Contrato;
using BANCOEMPLEOJAC.Servicio.Implementacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BANCOEMPLEOJAC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleoController : ControllerBase
    {
        private readonly IEmpleoServicio _empleoServicio;
        public EmpleoController(IEmpleoServicio empleoServicio)
        {
            _empleoServicio = empleoServicio;
        }
        [HttpGet("Lista/{buscar?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var response = new ResponseDTO<List<EmpleoDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _empleoServicio.Lista(buscar);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("Catalogo/{categoria?}/{buscar?}")]
        public async Task<IActionResult> Catalogo(string categoria, string buscar = "NA")
        {
            var response = new ResponseDTO<List<EmpleoDTO>>();

            try
            {
                if (categoria.ToLower() == "todos") categoria = "";
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _empleoServicio.Catalogo(categoria,buscar);
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
            var response = new ResponseDTO<EmpleoDTO>();
            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _empleoServicio.Obtener(Id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] EmpleoDTO modelo)
        {
            var response = new ResponseDTO<EmpleoDTO>();
            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _empleoServicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] EmpleoDTO modelo)
        {
            var response = new ResponseDTO<bool>();
            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _empleoServicio.Editar(modelo);
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
                response.Resultado = await _empleoServicio.Eliminar(Id);
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
