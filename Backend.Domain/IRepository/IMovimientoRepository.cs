using Backend.Domain.Entities.Internal;

namespace Backend.Domain.IRepository
{
    public interface IMovimientoRepository
    {
        Task<List<MovimientoDto>> ObtenerMovimientosAsync(DateTime fechaInicio, DateTime fechaFin, int? fondoMonetarioId, string? tipoMovimiento);
    }
}
