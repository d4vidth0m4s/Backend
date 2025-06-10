using Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Interfaz
{
    public interface IJwtService
    {
        string CreateToken(Usuario usuario);
       // string ValidateToken(String token);
        //string GetUserIdFromToken(String token);
    }
}