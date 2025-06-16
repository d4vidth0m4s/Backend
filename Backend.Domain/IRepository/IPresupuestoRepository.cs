    using Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.IRepository
{
    public interface IPresupuestoRepository
    {
        Task<int> CreateAsync(Presupuesto entity);
        Task<IEnumerable<Presupuesto>> GetAllAsync(int userId);
        Task<bool> UpdateAsync(Presupuesto entity, int userId);
        Task<Presupuesto?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id, int userId);
    }
}
