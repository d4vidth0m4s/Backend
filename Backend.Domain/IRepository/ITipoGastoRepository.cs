using Backend.Domain.Entities;

namespace Backend.Domain.IRepository
{
    public interface ITipoGastoRepository
    {
        Task<int> CreateAsync(TipoGasto entity);
        Task<IEnumerable<TipoGasto>> GetAllAsync();
        Task<bool> UpdateAsync(TipoGasto entity);
        Task<TipoGasto?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
