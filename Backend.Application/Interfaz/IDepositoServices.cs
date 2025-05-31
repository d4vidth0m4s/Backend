using Backend.Application.DTOs.Deposito.Response;
using Backend.Application.DTOs.Deposito.Resquest;

namespace Backend.Application.Interfaz
{
    public interface IDepositoServices
    {
        Task<int> CreateAsync(DepositoRequestDto dto);
        Task<IEnumerable<DepositoResponseDto>> GetAllAsync();
        Task<DepositoResponseDto?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(DepositoEditRequestDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
