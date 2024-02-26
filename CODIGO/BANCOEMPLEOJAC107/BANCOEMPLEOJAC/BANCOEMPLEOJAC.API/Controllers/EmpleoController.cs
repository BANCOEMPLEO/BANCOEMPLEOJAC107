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
        [HttpGet("Lista/{idUsuario?}/{buscar?}")]
        public async Task<IActionResult> Lista(string idUsuario, string buscar = "NA")
        {
            var response = new ResponseDTO<List<EmpleoDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _empleoServicio.Lista(idUsuario, buscar);
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

        [HttpPut("Activar")]
        public async Task<IActionResult> Activar([FromBody] EmpleoDTO modelo)
        {
            var response = new ResponseDTO<bool>();
            try
            {

                response.Resultado = await _empleoServicio.Activar(modelo);
                response.EsCorrecto = true;
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("Desactivar")]
        public async Task<IActionResult> Desactivar([FromBody] EmpleoDTO modelo)
        {
            var response = new ResponseDTO<bool>();
            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _empleoServicio.Desactivar(modelo);
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
