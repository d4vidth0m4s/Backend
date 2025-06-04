using Backend.Domain.Entities;

namespace Backend.Domain.IRepository
{
    public interface IRegistroGastoReoisitory
    {
        Task<int> CreateAsync(RegistroGasto entity);
        Task<int> CreateDetailAsync(RegistroGastoDetalles entity);
        Task<IEnumerable<RegistroGasto>> GetAllAsync();
        Task<RegistroGasto?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(RegistroGasto entity);
        
        Task<bool> DeleteAsync(int id);

    }
}
