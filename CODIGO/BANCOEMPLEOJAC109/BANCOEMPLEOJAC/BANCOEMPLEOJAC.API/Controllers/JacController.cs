using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Servicio.Contrato;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BANCOEMPLEOJAC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JacController : ControllerBase
    {
        private readonly IJacServicio _jacServicio;
        public JacController(IJacServicio jacServicio)
        {
            _jacServicio = jacServicio;
        }
        [HttpGet("Lista/{buscar?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var response = new ResponseDTO<List<JacDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _jacServicio.Lista(buscar);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("ListaDepartamentos/{buscar?}")]
        public async Task<IActionResult> ListaDepartamentos(string buscar = "NA")
        {
            var response = new ResponseDTO<List<DepartamentoDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _jacServicio.ListaDepartamentos(buscar);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("ListaRegiones/{buscar?}")]
        public async Task<IActionResult> ListaRegiones(string buscar = "NA")
        {
            var response = new ResponseDTO<List<RegionesDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _jacServicio.ListaRegiones(buscar);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("ListaMunicipios/{buscar?}")]
        public async Task<IActionResult> ListaMunicipios(string buscar = "NA")
        {
            var response = new ResponseDTO<List<MunicipioDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _jacServicio.ListaMunicipios(buscar);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("ListaZonaVeredas/{buscar?}")]
        public async Task<IActionResult> ListaZonaVeredas(string buscar = "NA")
        {
            var response = new ResponseDTO<List<ZonaVeredaDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _jacServicio.ListaZonaVeredas(buscar);
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
            var response = new ResponseDTO<JacDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _jacServicio.Obtener(id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] JacDTO modelo)
        {
            var response = new ResponseDTO<JacDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _jacServicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("CrearZonaVereda")]
        public async Task<IActionResult> CrearZonaVereda([FromBody] ZonaVeredaDTO modelo)
        {
            var response = new ResponseDTO<ZonaVeredaDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _jacServicio.CrearZonaVereda(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }


        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] JacDTO modelo)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _jacServicio.Editar(modelo);
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
                response.Resultado = await _jacServicio.Eliminar(id);
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
