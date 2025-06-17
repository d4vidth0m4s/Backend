using Backend.Domain.Entities;

namespace Backend.Domain.IRepository
{
    public interface IFondoMonectarioRepository
    {
        Task<int> CreateAsync(FondoMonetario entity);
        Task<IEnumerable<FondoMonetario>> GetAllAsync(int userId);
        Task<FondoMonetario?> GetByIdAsync(int id, int userId);
        Task<bool> UpdateAsync(FondoMonetario entity, int userId);
        Task<bool> DeleteAsync(int id, int userId);


    }
}
