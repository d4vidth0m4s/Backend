using Backend.Application.DTOs.FondoMonectario.Response;
using Backend.Application.DTOs.FondoMonectario.Resquest;


namespace Backend.Application.Interfaz
{
    public interface IFondoMonectarioServices
    {
        Task<int> CreateAsync(FondoMonectarioRequestDto dto, int userId);
        Task<IEnumerable<FondoMonectarioResponseDto>> GetAllAsync(int userId);
        Task<FondoMonectarioResponseDto?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(FondoMonectarioEditRequestDto dto, int userId);
        Task<bool> DeleteAsync(int id, int userId);

    }
}
