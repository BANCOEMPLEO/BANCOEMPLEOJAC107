using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Servicio.Interfase;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BANCOEMPLEOJAC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadEconomicaController : ControllerBase
    {
        private readonly IActividadEconomicaServicio _modeloActividad;
        public ActividadEconomicaController(IActividadEconomicaServicio categoriaServicio)
        {
            _modeloActividad = categoriaServicio;
        }

        // GET: api/<ActividadEconomicaController>
        [HttpGet("Lista/{buscar?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var response = new ResponseDTO<List<ActividadEconomicaDTO>>();

            try
            {
                if (buscar == "NA") buscar.Equals(Empty);

                response.EsCorrecto = true;
                response.Resultado = await _modeloActividad.Lista(buscar);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }
        // GET api/<ActividadEconomicaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ActividadEconomicaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ActividadEconomicaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ActividadEconomicaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
