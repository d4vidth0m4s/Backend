using Backend.Application.DTOs.Deposito.Response;
using Backend.Application.DTOs.Deposito.Resquest;

namespace Backend.Application.Interfaz
{
    public interface IDepositoServices
    {
        Task<int> CreateAsync(DepositoRequestDto dto, int userId);
        Task<IEnumerable<DepositoResponseDto>> GetAllAsync(int userId);
        Task<DepositoResponseDto?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(DepositoEditRequestDto dto, int userId);
        Task<bool> DeleteAsync(int id, int userId);
    }
}
