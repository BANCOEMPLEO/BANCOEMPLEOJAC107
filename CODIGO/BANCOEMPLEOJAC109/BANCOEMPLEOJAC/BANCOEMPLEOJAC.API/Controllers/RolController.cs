using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Modelo;
using BANCOEMPLEOJAC.Repositorio.Interfase;
using BANCOEMPLEOJAC.Servicio.Implementacion;
using BANCOEMPLEOJAC.Servicio.Interfase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BANCOEMPLEOJAC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolServicio _rolServicio;
        public RolController(IRolServicio rolServicio)
        {
            _rolServicio = rolServicio;
        }
        [HttpGet("Lista/{UsuarioId:int}/{buscar?}")]
        public async Task<IActionResult> Lista(int UsuarioId, string buscar = "NA")
        {
            var response = new ResponseDTO<List<RolDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _rolServicio.Lista(UsuarioId, buscar);
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
