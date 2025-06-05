using Backend.Application.DTOs.Login.Response;

namespace Backend.Application.Interfaz
{
    public interface ILoginServices
    {
       

       
    }

    public interface Iloginservices
    {
         Task<LoginResponseDto> loginAsync(string username, string password);
    }
}
