using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Modelo;
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

        // VOY : PONIENDO LISTADO CONTRATOS POR USUARO : 11/MAR/2024 4:07AM

        //[HttpGet("Listar/{UserId:int}/{buscar?}")]
        //public async Task<List<ContratoDTO>> Listar(int? UserId, string? buscar = "NA")
        //{
        //    var response = new ResponseDTO<List<ContratoDTO>>();
        //    try
        //    {
        //        if (UserId == 0) { }
        //        if (buscar == "NA") buscar = "";

        //        response.EsCorrecto = true;
        //        response.Resultado = await _contratoServicio.Listar(UserId, buscar);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.EsCorrecto = false;
        //        response.Mensaje = ex.Message;
        //    }
        //    return response.Resultado;
        //}

        [HttpGet("Catalogo/{UserId}/{categoria?}/{buscar?}")]
        public async Task<IActionResult> Catalogo(int UserId, int categoria, string buscar = "NA")
        {
            var response = new ResponseDTO<List<ContratoDTO>>();

            try
            {
                //if (categoria.ToLower() == "todos") categoria = "";
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _contratoServicio.PerfilCargo(UserId, categoria, buscar);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
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
