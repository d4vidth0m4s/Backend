using Backend.Application.DTOs.TipoGasto.Response;
using Backend.Application.DTOs.TipoGasto.Resquest;

namespace Backend.Application.Interfaz
{
    public interface ITipoGastoServices
    {
        Task<int> CreateAsync(TipoGastoRequestDto dto);
        Task<IEnumerable<TipoGastoResponseDto>> GetAllAsync();
        Task<TipoGastoResponseDto?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(TipoGastoEditRequestDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
