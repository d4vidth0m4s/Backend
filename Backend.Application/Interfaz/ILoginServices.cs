using Backend.Application.DTOs.Login.Response;
using System.Threading.Tasks;

namespace Backend.Application.Interfaz
{
    public interface Iloginservices
    {
        Task<LoginResponseDto> loginAsync(string username, string password);
    }
}