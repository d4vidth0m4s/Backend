using Backend.Application.DTOs.Presupuesto.Response;
using Backend.Application.DTOs.Presupuesto.Resquest;
using Backend.Application.DTOs.TipoGasto.Resquest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Interfaz
{
    public interface IPresupuestosServices
    {
        Task<int> CreateAsync(PresupuestoRequestDto dto);
        Task<IEnumerable<PresupuestoResponseDto>> GetAllAsync();
        Task<PresupuestoResponseDto?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(PresupuestoEditRequestDto dto);
        Task<bool> DeleteAsync(int id);


    }
}
