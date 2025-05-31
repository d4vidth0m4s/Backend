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
            _context.Depositos.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<Deposito?> GetByIdAsync(int id)
        {
            return await _context.Depositos.FindAsync(id);
        }

        public async Task<IEnumerable<Deposito>> GetAllAsync()
        {
            return await _context.Depositos.ToListAsync();
        }

        public async Task<bool> UpdateAsync(Deposito entity)
        {
            var existing = await _context.Depositos.FindAsync(entity.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Depositos.FindAsync(id);
            if (entity == null) return false;

            _context.Depositos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
