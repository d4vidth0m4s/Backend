using Backend.Domain.Entities.Internal;

namespace Backend.Application.Interfaz
{
    public interface IMovimientoService
    {
        Task<List<MovimientoDto>> ObtenerMovimientosAsync(DateTime fechaInicio, DateTime fechaFin, int? fondoMonetarioId, string? tipoMovimiento);
    }
}
