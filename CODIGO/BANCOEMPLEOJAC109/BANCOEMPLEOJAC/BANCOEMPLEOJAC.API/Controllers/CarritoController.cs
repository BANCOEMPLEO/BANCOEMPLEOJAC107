using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Servicio.Interfase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BANCOEMPLEOJAC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoServicio _modeloCarrito;
        public CarritoController(ICarritoServicio carritoServicio)
        {
            _modeloCarrito = carritoServicio;
        }
        [HttpGet("Lista/{buscar?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var response = new ResponseDTO<List<CarritoDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                //response.Resultado = await _modeloCarrito.Lista(buscar);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        //[HttpGet("Obtener/{Id:int?}")]
        //public async Task<IActionResult> Obtener(int Id)
        //{
        //    var response = new ResponseDTO<CarritoDTO>();

        //    try
        //    {

        //        response.EsCorrecto = true;
        //        response.Resultado = await _modeloCarrito.Obtener(Id);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.EsCorrecto = false;
        //        response.Mensaje = ex.Message;
        //    }
        //    return Ok(response);
        //}

        //[HttpPost("Crear")]
        //public async Task<IActionResult> Crear([FromBody] CarritoDTO modelo)
        //{
        //    var response = new ResponseDTO<CarritoDTO>();

        //    try
        //    {
        //        response.EsCorrecto = true;
        //        response.Resultado = await _modeloCarrito.Crear(modelo);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.EsCorrecto = false;
        //        response.Mensaje = ex.Message;
        //    }
        //    return Ok(response);
        //}

        //[HttpPut("Actualizar")]
        //public async Task<IActionResult> Actualizar([FromBody] CarritoDTO modelo)
        //{
        //    var response = new ResponseDTO<CarritoDTO>();

        //    try
        //    {
        //        response.EsCorrecto = true;
        //        response.Resultado = await _modeloCarrito.Actualizar(modelo);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.EsCorrecto = false;
        //        response.Mensaje = ex.Message;
        //    }
        //    return Ok(response);
        //}

        //[HttpDelete("Eliminar/{Id:int?}")]
        //public async Task<IActionResult> Eliminar(int Id)
        //{
        //    var response = new ResponseDTO<CarritoDTO>();

        //    try
        //    {
        //        response.Mensaje = "Error";
        //    }
        //}
    }
}
