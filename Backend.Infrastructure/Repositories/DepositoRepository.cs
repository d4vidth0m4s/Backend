using Backend.Domain.Entities;
using Backend.Domain.IRepository;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories
{
    public class DepositoRepository(ApplicationDbContext context) : IDepositoRepository
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<int> CreateAsync(Deposito entity)
        {
            var fondoMonetarioId = await _context.FondoMonectarios
                                   .FirstOrDefaultAsync(t => t.Id == entity.FondoMonetarioId && t.UserId == entity.UserId)
                                   ?? throw new UnauthorizedAccessException("El fondo monetario no pertenece al usuario.");

            _context.Depositos.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<Deposito?> GetByIdAsync(int id)
        {
            return await _context.Depositos
                        .Include(d => d.FondoMonetario)
                        .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Deposito>> GetAllAsync(int userId)
        {
            return await _context.Depositos
                 .Where(d => d.UserId == userId)
                 .Include(d => d.FondoMonetario)
                 .ToListAsync();
        }

        public async Task<bool> UpdateAsync(Deposito entity, int userId)
        {
            var existing = await _context.Depositos.FindAsync(entity.Id);

            if (existing == null) return false;
            if (existing.UserId != userId) return false;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            existing.UserId = userId;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id,int userId)
        {
            var entity = await _context.Depositos.FindAsync(id);
            if (entity == null) return false;
            if (entity.UserId != userId) return false;
            _context.Depositos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
