using Backend.Domain.Entities.Internal;
using Backend.Domain.IRepository;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories
{
    public class GraficoPresupuestoRepository(ApplicationDbContext context) : IGraficoPresupuestoRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<GraficoPresupuestoDto>> ObtenerReporteAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            var presupuestos = await _context.Presupuestos
                .Include(p => p.TipoGasto)
                .ToListAsync();

            var gastos = await _context.RegistroGastos
                .Include(g => g.TipoGasto)
                .Where(g => g.Fecha >= fechaInicio && g.Fecha <= fechaFin)
                .ToListAsync();

            var reporte = presupuestos
                .GroupBy(p => p.TipoGasto.Descripcion)
                .Select(grupo =>
                {
                    var tipoGasto = grupo.Key;
                    var presupuestoTotal = grupo.Sum(p => p.Monto);
                    var ejecutadoTotal = gastos
                        .Where(g => g.TipoGasto.Descripcion == tipoGasto)
                        .Sum(g => g.Total);

                    return new GraficoPresupuestoDto
                    {
                        TipoGasto = tipoGasto,
                        Presupuesto = presupuestoTotal,
                        Ejecutado = ejecutadoTotal
                    };
                }).ToList();

            return reporte;
        }
    }
}
