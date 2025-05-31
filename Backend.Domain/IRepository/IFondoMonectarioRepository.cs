using Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.IRepository
{
    public interface IFondoMonectarioRepository
    {
        Task<int> CreateAsync(FondoMonectario entity);
        Task<IEnumerable<FondoMonectario>> GetAllAsync();
        Task<FondoMonectario?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(FondoMonectario entity);
        Task<bool> DeleteAsync(int id);


    }
}
