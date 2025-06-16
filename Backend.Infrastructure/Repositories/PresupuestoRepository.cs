using Backend.Domain.Entities;
using Backend.Domain.IRepository;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories
{
    public class PresupuestoRepository(ApplicationDbContext context) :IPresupuestoRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<int> CreateAsync(Presupuesto entity)
        {
            var tipoGasto = await _context.TipoGastos
                           .FirstOrDefaultAsync(t => t.Id == entity.TipoGastoId && t.UserId == entity.UserId)
                           ?? throw new UnauthorizedAccessException("El tipo de gasto no pertenece al usuario.");

            _context.Presupuestos.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<Presupuesto?> GetByIdAsync(int id)
        {
            return await _context.Presupuestos
                          .Include(p => p.TipoGasto)
                          .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Presupuesto>> GetAllAsync(int userId)
        {
            return await _context.Presupuestos
                         .Where(t => t.UserId == userId)
                         .Include(p => p.TipoGasto)
                         .ToListAsync();
        }

        public async Task<bool> UpdateAsync(Presupuesto entity, int userId)
        {
            var existing = await _context.Presupuestos.FindAsync(entity.Id);

            if (existing == null) return false;
            if(existing.UserId != userId) return false;
            entity.FechaCreacion = existing.FechaCreacion;
            _context.Entry(existing).CurrentValues.SetValues(entity);
            existing.UserId = userId;  
            
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id, int userId)
        {
            var entity = await _context.Presupuestos.FindAsync(id);
            if (entity == null) return false;
            if (entity.UserId != userId) return false;
            _context.Presupuestos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
