
using Backend.Domain.Entities;


namespace Backend.Domain.IRepository
{
    public interface ILoginRepository 
    {
        Task<Usuario?> ObtenerPorUsernameAsync(string username);
        Task<bool> ValidarCredencialesAsync(string username, string password);
    }
}
