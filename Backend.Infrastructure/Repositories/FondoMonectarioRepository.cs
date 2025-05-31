using Backend.Domain.Entities;
using Backend.Domain.IRepository;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Backend.Infrastructure.Repositories
{
    public class FondoMonectarioRepository(ApplicationDbContext context) : IFondoMonectarioRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<int> CreateAsync(FondoMonectario entity)
        {
            _context.FondoMonectarios.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<FondoMonectario?> GetByIdAsync(int id)
        {
            return await _context.FondoMonectarios.FindAsync(id);
        }

        public async Task<IEnumerable<FondoMonectario>> GetAllAsync()
        {
            return await _context.FondoMonectarios.ToListAsync();
        }

        public async Task<bool> UpdateAsync(FondoMonectario entity)
        {
            var existing = await _context.FondoMonectarios.FindAsync(entity.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.FondoMonectarios.FindAsync(id);
            if (entity == null) return false;

            _context.FondoMonectarios.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
