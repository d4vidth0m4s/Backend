using Backend.Domain.Entities;
using Backend.Domain.IRepository;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories
{
    public class RegistroGastoRepository(ApplicationDbContext context) : IRegistroGastoReoisitory
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<int> CreateAsync(RegistroGasto entity)
        {
            _context.RegistroGastos.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }
        public async Task<int> CreateDetailAsync(RegistroGastoDetalles entity)
        {
            _context.RegistroGastoDetalles.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<RegistroGasto?> GetByIdAsync(int id)
        {
            return await _context.RegistroGastos
                .Include(r => r.Detalles)
                .Include(r => r.FondoMonetario)
                .Include(r => r.TipoGasto)
                .FirstOrDefaultAsync(r => r.Id == id);
        }


        public async Task<IEnumerable<RegistroGasto>> GetAllAsync()
        {
            return await _context.RegistroGastos
                .Include(r => r.Detalles)
                .Include(r => r.FondoMonetario)
                .Include(r => r.TipoGasto)
                .ToListAsync();
        }



        public async Task<bool> UpdateAsync(RegistroGasto entity)
        {
            var existing = await _context.RegistroGastos.FindAsync(entity.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.RegistroGastos.FindAsync(id);
            if (entity == null) return false;

            _context.RegistroGastos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
