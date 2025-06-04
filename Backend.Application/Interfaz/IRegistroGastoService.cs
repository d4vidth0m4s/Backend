using Backend.Application.DTOs.RegistroGasto.Response;
using Backend.Application.DTOs.RegistroGasto.Resquest;
using Backend.Application.DTOs.TipoGasto.Response;
using Backend.Application.DTOs.TipoGasto.Resquest;

namespace Backend.Application.Interfaz
{
    public interface IRegistroGastoService
    {
        Task<int> CreateAsync(RegistroGastoRequestDto dto);
        Task<IEnumerable<RegistroGastoResponseDto>> GetAllAsync();
        Task<RegistroGastoResponseDto?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(RegistroGastoEditRequestDto dto);
        Task<bool> DeleteAsync(int id);


    }
}
