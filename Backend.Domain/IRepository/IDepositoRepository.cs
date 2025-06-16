using Backend.Domain.Entities;
using System.Threading.Tasks;

namespace Backend.Domain.IRepository
{
    public interface IDepositoRepository
    {
        Task<int> CreateAsync(Deposito entity);
        Task<IEnumerable<Deposito>> GetAllAsync(int userId);
        Task<Deposito?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(Deposito entity, int userId);
        Task<bool> DeleteAsync(int id, int userId);

    }
}
