using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Servicio.Interfase;
using BANCOEMPLEOJAC.Utilidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BANCOEMPLEOJAC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServicio _usuarioServicio;
        public UsuarioController(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }
        [HttpGet("Lista/{rol?}/{buscar?}/{UsuarioId:int}")]
        public async Task<IActionResult> Lista(int rol, string buscar = "NA", int UsuarioId = 0)
        {
            var response = new ResponseDTO<List<UsuarioDTO>>();

            var usuario = await _usuarioServicio.Obtener(UsuarioId);
            int RolId = (int)usuario.Rol;
            int JacId = (int)usuario.JacId;

            try
            {
                if(rol == 0) 
                {

                }
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _usuarioServicio.Lista(rol, buscar, RolId, JacId);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }
        [HttpGet("Obtener/{id:int}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var response = new ResponseDTO<UsuarioDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _usuarioServicio.Obtener(id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] UsuarioDTO modelo)
        {
            var response = new ResponseDTO<UsuarioDTO>();

            try
            {
                modelo.Clave = Encrypt.GetSHA256(modelo.Clave); 
                response.EsCorrecto = true;
                response.Resultado = await _usuarioServicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Autorizacion")]
        public async Task<IActionResult> Autorizacion([FromBody] LoginDTO modelo)
        {
            var response = new ResponseDTO<SesionDTO>();

            try
            {
                modelo.Clave = Encrypt.GetSHA256(modelo.Clave);
                response.EsCorrecto = true;
                response.Resultado = await _usuarioServicio.Autorizacion(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] UsuarioEditaDTO modelo)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _usuarioServicio.Editar(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _usuarioServicio.Eliminar(id);
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
