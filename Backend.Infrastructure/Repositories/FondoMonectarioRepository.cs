using Backend.Domain.Entities;
using Backend.Domain.IRepository;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Backend.Infrastructure.Repositories
{
    public class FondoMonectarioRepository(ApplicationDbContext context) : IFondoMonectarioRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<int> CreateAsync(FondoMonetario entity)
        {
            _context.FondoMonectarios.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<FondoMonetario?> GetByIdAsync(int id, int userId)
        {
            return await _context.FondoMonectarios.FirstOrDefaultAsync(f => f.Id == id && f.UserId == userId);
        }

        public async Task<IEnumerable<FondoMonetario>> GetAllAsync(int userId)
        {
            return await _context.FondoMonectarios
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(FondoMonetario entity, int userId)
        {
            var existing = await _context.FondoMonectarios.FindAsync(entity.Id);
            if (existing == null) return false;

            if (existing.UserId != userId) return false;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            existing.UserId = userId;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id, int userId)
        {
            var entity = await _context.FondoMonectarios.FindAsync(id);
            if (entity == null) return false;
            if (entity.UserId != userId) return false;
            _context.FondoMonectarios.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
