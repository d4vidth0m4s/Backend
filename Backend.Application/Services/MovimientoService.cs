using Backend.Application.Interfaz;
using Backend.Domain.Entities.Internal;
using Backend.Domain.IRepository;

namespace Backend.Application.Services
{
    public class MovimientoService(IMovimientoRepository movimientoRepository) : IMovimientoService
    {
        private readonly IMovimientoRepository _movimientoRepository = movimientoRepository;

        public async Task<List<MovimientoDto>> ObtenerMovimientosAsync(DateTime fechaInicio, DateTime fechaFin, int? fondoMonetarioId, string? tipoMovimiento)
        {
            return await _movimientoRepository.ObtenerMovimientosAsync(fechaInicio, fechaFin, fondoMonetarioId, tipoMovimiento);
        }
    }
}
