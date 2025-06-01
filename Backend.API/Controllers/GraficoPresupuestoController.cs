using Backend.Application.Interfaz;
using Backend.Domain.Entities.Internal;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraficoPresupuestoController(IGraficoPresupuestoService service) : ControllerBase
    {
        private readonly IGraficoPresupuestoService _service = service;

        [HttpGet]
        public async Task<ActionResult<List<GraficoPresupuestoDto>>> ObtenerReporte(
            [FromQuery] DateTime fechaInicio,
            [FromQuery] DateTime fechaFin)
        {
            var resultado = await _service.ObtenerReporteAsync(fechaInicio, fechaFin);
            return Ok(resultado);
        }
    }
}
