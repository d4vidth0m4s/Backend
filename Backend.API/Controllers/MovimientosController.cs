using Backend.Application.Interfaz;
using Backend.Domain.Entities.Internal;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosController(IMovimientoService movimientoService) : ControllerBase
    {
        private readonly IMovimientoService _movimientoService = movimientoService;

        [HttpGet]
        public async Task<ActionResult<List<MovimientoDto>>> ObtenerMovimientos(
            [FromQuery] DateTime fechaInicio,
            [FromQuery] DateTime fechaFin,
            [FromQuery] int? fondoMonetarioId,
            [FromQuery] string? tipoMovimiento)
        {
            var movimientos = await _movimientoService.ObtenerMovimientosAsync(fechaInicio, fechaFin, fondoMonetarioId, tipoMovimiento);
            return Ok(movimientos);
        }
    }
}
