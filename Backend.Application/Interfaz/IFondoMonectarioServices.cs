using Backend.Application.DTOs.FondoMonectario.Response;
using Backend.Application.DTOs.FondoMonectario.Resquest;
using Backend.Application.DTOs.TipoGasto.Response;
using Backend.Application.DTOs.TipoGasto.Resquest;
using Backend.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Interfaz
{
    public interface IFondoMonectarioServices
    {
        Task<int> CreateAsync(FondoMonectarioRequestDto dto);
        Task<IEnumerable<FondoMonectarioResponseDto>> GetAllAsync();
        Task<FondoMonectarioResponseDto?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(FondoMonectarioEditRequestDto dto);
        Task<bool> DeleteAsync(int id);

    }
}
