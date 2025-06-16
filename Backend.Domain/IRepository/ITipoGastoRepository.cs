using Backend.Domain.Entities;

namespace Backend.Domain.IRepository
{
    public interface ITipoGastoRepository
    {
        Task<string> CreateAsync(TipoGasto entity);
        Task<IEnumerable<TipoGasto>> GetAllAsync(int userId);
        Task<bool> UpdateAsync(TipoGasto entity, int userId);
        Task<TipoGasto?> GetByIdAsync(string id);
        Task<bool> DeleteAsync(string id, int userId);
    }
}
