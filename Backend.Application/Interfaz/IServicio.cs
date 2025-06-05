using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Interfaz
{
    internal interface IAutenticacionServicio
    {
        Task<(bool success, string token)> LoginAsync(string username, string password);
        Task<bool> ValidarTokenAsync(string token);
        Task LogoutAsync(string token);
    }
}
