using Backend.Application.DTOs.TipoGasto.Response;
using Backend.Application.DTOs.TipoGasto.Resquest;

namespace Backend.Application.Interfaz
{
    public interface ITipoGastoServices
    {
        Task<string> CreateAsync(TipoGastoRequestDto dto);
        Task<IEnumerable<TipoGastoResponseDto>> GetAllAsync();
        Task<TipoGastoResponseDto?> GetByIdAsync(string id);
        Task<bool> UpdateAsync(TipoGastoEditRequestDto dto);
        Task<bool> DeleteAsync(string id);
    }
}
