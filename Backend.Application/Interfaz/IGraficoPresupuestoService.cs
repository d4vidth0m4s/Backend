using Backend.Domain.Entities.Internal;

namespace Backend.Application.Interfaz
{
    public interface IGraficoPresupuestoService
    {
        Task<List<GraficoPresupuestoDto>> ObtenerReporteAsync(DateTime fechaInicio, DateTime fechaFin);
    }
}
