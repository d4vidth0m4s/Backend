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

        public async Task<IEnumerable<Presupuesto>> GetAllAsync()
        {
            return await _context.Presupuestos
                         .Include(p => p.TipoGasto)
                         .ToListAsync();
        }

        public async Task<bool> UpdateAsync(Presupuesto entity)
        {
            var existing = await _context.Presupuestos.FindAsync(entity.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.TipoGastos.FindAsync(id);
            if (entity == null) return false;

            _context.TipoGastos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
