using Backend.Application.Interfaz;
using Backend.Domain.Entities.Internal;
using Backend.Domain.IRepository;

namespace Backend.Application.Services
{
    public class GraficoPresupuestoService(IGraficoPresupuestoRepository repository) : IGraficoPresupuestoService
    {
        private readonly IGraficoPresupuestoRepository _repository = repository;

        public async Task<List<GraficoPresupuestoDto>> ObtenerReporteAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _repository.ObtenerReporteAsync(fechaInicio, fechaFin);
        }
    }
}
