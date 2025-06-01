using Backend.Domain.Entities.Internal;

namespace Backend.Domain.IRepository
{
    public interface IGraficoPresupuestoRepository
    {
        Task<List<GraficoPresupuestoDto>> ObtenerReporteAsync(DateTime fechaInicio, DateTime fechaFin);
    }
}
