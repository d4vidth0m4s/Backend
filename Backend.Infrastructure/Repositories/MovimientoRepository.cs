using Backend.Domain.Entities.Internal;
using Backend.Domain.IRepository;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories
{
    public class MovimientoRepository(ApplicationDbContext context) : IMovimientoRepository
    {
        private readonly ApplicationDbContext _context = context;
        
        public async Task<List<MovimientoDto>> ObtenerMovimientosAsync(DateTime fechaInicio, DateTime fechaFin, int? fondoMonetarioId, string? tipoMovimiento)
        {
            var depositosQuery = _context.Depositos
                .Include(d => d.FondoMonetario)
                .Where(d => d.Fecha >= fechaInicio && d.Fecha <= fechaFin);

            if (fondoMonetarioId.HasValue)
                depositosQuery = depositosQuery.Where(d => d.FondoMonetarioId == fondoMonetarioId.Value);

            var depositos = await depositosQuery
                .Select(d => new MovimientoDto
                {
                    Fecha = d.Fecha,
                    Tipo = "Deposito",
                    FondoMonetarioId = d.FondoMonetarioId,
                    FondoMonetario = d.FondoMonetario!.Nombre,
                    Monto = d.Monto,
                    Descripcion = d.Observacion ?? ""
                }).ToListAsync();

            var gastosQuery = _context.RegistroGastos
                .Include(g => g.FondoMonetario)
                .Where(g => g.Fecha >= fechaInicio && g.Fecha <= fechaFin);

            if (fondoMonetarioId.HasValue)
                gastosQuery = gastosQuery.Where(g => g.FondoMonetarioId == fondoMonetarioId.Value);

            var gastos = await gastosQuery
                .Select(g => new MovimientoDto
                {
                    Fecha = g.Fecha,
                    Tipo = "Gasto",
                    FondoMonetarioId = g.FondoMonetarioId,
                    FondoMonetario = g.FondoMonetario!.Nombre,
                    Monto = g.Total,
                    Descripcion = (g.Comercio ?? "") + " - " + (g.TipoDoc ?? "")
                }).ToListAsync();

            var movimientos = depositos.Concat(gastos).ToList();

            if (!string.IsNullOrEmpty(tipoMovimiento))
            {
                movimientos = [.. movimientos.Where(m => m.Tipo!.Equals(tipoMovimiento, StringComparison.OrdinalIgnoreCase))];
            }

            return [.. movimientos.OrderBy(m => m.Fecha)];
        }
    }
}
