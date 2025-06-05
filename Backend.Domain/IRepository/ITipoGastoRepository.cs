using Backend.Domain.Entities;

namespace Backend.Domain.IRepository
{
    public interface ITipoGastoRepository
    {
        Task<string> CreateAsync(TipoGasto entity);
        Task<IEnumerable<TipoGasto>> GetAllAsync();
        Task<bool> UpdateAsync(TipoGasto entity);
        Task<TipoGasto?> GetByIdAsync(string id);
        Task<bool> DeleteAsync(string id);
    }
}
