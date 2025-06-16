using Backend.Domain.Entities;
using Backend.Domain.IRepository;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories
{
    public class TipoGastoRepository(ApplicationDbContext context): ITipoGastoRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<string> CreateAsync(TipoGasto entity)
        {
            _context.TipoGastos.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;   
        }

        public async Task<TipoGasto?> GetByIdAsync(string id)
        {
            return await _context.TipoGastos.FindAsync(id);
        }

        public async Task<IEnumerable<TipoGasto>> GetAllAsync(int userId)
        {
            return await _context.TipoGastos
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(TipoGasto entity, int userId)
        {
            var existing = await _context.TipoGastos.FindAsync(entity.Id);
            if (existing == null) return false;

            
            if (existing.UserId != userId) return false;

            existing.Descripcion = entity.Descripcion; 
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(string id, int userId)
        {
            var entity = await _context.TipoGastos.FindAsync(id);
            if (entity == null) return false;
            if (entity.UserId != userId) return false;
            _context.TipoGastos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
