using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Servicio.Contrato;
using BANCOEMPLEOJAC.Servicio.Implementacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BANCOEMPLEOJAC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropuestaEmpleoController : ControllerBase
    {
        private readonly IPropuestaEmpleoServicio _propuestaempleoServicio;
        public PropuestaEmpleoController(IPropuestaEmpleoServicio propuestaEmpleoServicio)
        {
            _propuestaempleoServicio = propuestaEmpleoServicio;
        }

        [HttpGet("Lista/{buscar?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var response = new ResponseDTO<List<PropuestaEmpleoDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _propuestaempleoServicio.Lista(buscar);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("EstadoPorEmpleo/{idEmpleo}")]
        public async Task<IActionResult> EstadoPorEmpleo(int idEmpleo)
        {
            var response = new ResponseDTO<EmpleoEstadoDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _propuestaempleoServicio.EstadoPorEmpleo(idEmpleo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }


        [HttpGet("Catalogo/{categoria?}/{buscar?}")]
        public async Task<IActionResult> Catalogo(int categoria, string buscar = "NA")
        {
            var response = new ResponseDTO<List<PropuestaEmpleoDTO>>();
            
            try
            {
                //if (categoria.ToLower() == "todos") categoria = "";
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _propuestaempleoServicio.PerfilCargo(categoria,buscar);
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
            var response = new ResponseDTO<PropuestaEmpleoDTO>();
            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _propuestaempleoServicio.Obtener(Id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }
        [HttpGet("ObtenerAnterior/{Id:int?}")]
        public async Task<IActionResult> ObtenerAnterior(int Id)
        {
            var response = new ResponseDTO<int?>();
            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _propuestaempleoServicio.ObtenerAnterior(Id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] PropuestaEmpleoDTO modelo)
        {
            var response = new ResponseDTO<PropuestaEmpleoDTO>();
            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _propuestaempleoServicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] PropuestaEmpleoDTO modelo)
        {
            var response = new ResponseDTO<bool>();
            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _propuestaempleoServicio.Editar(modelo);
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
                response.Resultado = await _propuestaempleoServicio.Eliminar(Id);
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
