using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Servicio.Contrato;
using BANCOEMPLEOJAC.Servicio.Implementacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BANCOEMPLEOJAC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropuestaServicioController : ControllerBase
    {
        private readonly IPropuestaServicioServicio _propuestaservicioServicio;
        public PropuestaServicioController(IPropuestaServicioServicio propuestaServicioServicio)
        {
            _propuestaservicioServicio = propuestaServicioServicio;
        }
        [HttpGet("Lista/{buscar?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var response = new ResponseDTO<List<PropuestaServicioDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _propuestaservicioServicio.Lista(buscar);
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
            var response = new ResponseDTO<List<PropuestaServicioDTO>>();

            try
            {
                //var consulta = _modeloRepositorio.Consultar();
                //if (buscar != null)
                //    consulta = consulta.Where(c => c.Nombre.Contains(buscar) || c.Caracteristicas.Contains(buscar));
                //if (categoria > 0)
                //    consulta = consulta.Where(c => c.CategoriaId == categoria);

                //if (categoria.ToLower() == "todos") categoria = "";
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _propuestaservicioServicio.Categoria(categoria,buscar);
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
            var response = new ResponseDTO<PropuestaServicioDTO>();
            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _propuestaservicioServicio.Obtener(Id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] PropuestaServicioDTO modelo)
        {
            var response = new ResponseDTO<PropuestaServicioDTO>();
            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _propuestaservicioServicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] PropuestaServicioDTO modelo)
        {
            var response = new ResponseDTO<bool>();
            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _propuestaservicioServicio.Editar(modelo);
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
                response.Resultado = await _propuestaservicioServicio.Eliminar(Id);
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
