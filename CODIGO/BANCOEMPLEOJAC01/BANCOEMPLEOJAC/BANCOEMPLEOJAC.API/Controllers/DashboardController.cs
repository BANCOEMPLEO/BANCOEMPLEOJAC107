using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using BANCOEMPLEOJAC.Servicio.Contrato;
using BANCOEMPLEOJAC.DTO;
using BANCOEMPLEOJAC.Servicio.Implementacion;


namespace BANCOEMPLEOJAC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDasboardServicio _dashboardServicio;
        public DashboardController(IDasboardServicio dashboardServicio)
        {
            _dashboardServicio = dashboardServicio;
        }

        [HttpGet("Resumen")]
        public IActionResult Resumen()
        {
            var response = new ResponseDTO<DashboardDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = _dashboardServicio.Resumen();
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
