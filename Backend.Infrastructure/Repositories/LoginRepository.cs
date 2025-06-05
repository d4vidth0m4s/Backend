using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Repositories
{
    public class LoginRepository
    {
        Task<Domain.Entities.Usuarios> ObtenerPorUsernameAsync(string username);

        Task<bool> ValidarCredencialesAsync(string username, string password);
    }
}
