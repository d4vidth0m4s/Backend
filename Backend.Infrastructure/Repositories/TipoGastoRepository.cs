using Backend.Domain.Entities;
using Backend.Domain.IRepository;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories
{
    public class TipoGastoRepository(ApplicationDbContext context): ITipoGastoRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<int> CreateAsync(TipoGasto entity)
        {
            _context.TipoGastos.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<TipoGasto?> GetByIdAsync(int id)
        {
            return await _context.TipoGastos.FindAsync(id);
        }

        public async Task<IEnumerable<TipoGasto>> GetAllAsync()
        {
            return await _context.TipoGastos.ToListAsync();
        }

        public async Task<bool> UpdateAsync(TipoGasto entity)
        {
            var existing = await _context.TipoGastos.FindAsync(entity.Id);
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
