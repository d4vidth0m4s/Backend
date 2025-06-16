using Backend.Application.DTOs.TipoGasto.Response;
using Backend.Application.DTOs.TipoGasto.Resquest;

namespace Backend.Application.Interfaz
{
    public interface ITipoGastoServices
    {
        Task<string> CreateAsync(TipoGastoRequestDto dto, int userId);
        Task<IEnumerable<TipoGastoResponseDto>> GetAllAsync(int userId);
        Task<TipoGastoResponseDto?> GetByIdAsync(string id);
        Task<bool> UpdateAsync(TipoGastoEditRequestDto dto, int userId);
        Task<bool> DeleteAsync(string id, int userId);
    }
}
