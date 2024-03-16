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
        [HttpGet("Lista/{idUsuario:int}/{buscar?}")]
        public async Task<IActionResult> Lista(int idUsuario, string buscar = "NA")
        {
            var response = new ResponseDTO<List<PerfilCargoDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _perfilCargoServicio.Lista(idUsuario, buscar);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }
        [HttpGet("VerificaPerfilEmpleoBorrar/{idUsuario:int}/{idPerfilCargo:int}")]
        public async Task<IActionResult> VerificaPerfilEmpleoBorrar(int idUsuario, int idPerfilCargo)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _perfilCargoServicio.VerificaPerfilEmpleoBorrar(idUsuario, idPerfilCargo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }
        [HttpGet("ListaTipoContrato/{buscar?}")]
        public async Task<IActionResult> ListaTipoContrato(string buscar = "NA")
        {
            var response = new ResponseDTO<List<TipoContratoDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _perfilCargoServicio.ListaTipoContrato(buscar);
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
