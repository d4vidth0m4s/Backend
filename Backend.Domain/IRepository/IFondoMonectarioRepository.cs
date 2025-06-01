using Backend.Domain.Entities;

namespace Backend.Domain.IRepository
{
    public interface IFondoMonectarioRepository
    {
        Task<int> CreateAsync(FondoMonetario entity);
        Task<IEnumerable<FondoMonetario>> GetAllAsync();
        Task<FondoMonetario?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(FondoMonetario entity);
        Task<bool> DeleteAsync(int id);


    }
}
