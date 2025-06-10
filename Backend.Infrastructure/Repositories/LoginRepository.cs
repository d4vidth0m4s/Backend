using Backend.Domain.IRepository;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Backend.Domain.Entities;


namespace Backend.Infrastructure.Repositories
{
    public class LoginRepository(ApplicationDbContext context) : ILoginRepository
    {
        private readonly ApplicationDbContext _context = context;


        public async Task<Usuario?> ObtenerPorUsernameAsync(string username)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
        }

        public async Task<bool> ValidarCredencialesAsync(string username, string password)
        {
            var usuario = await ObtenerPorUsernameAsync(username);
            if (usuario == null) return false;

            // Aquí puedes comparar directamente si no usas hash
            return usuario.PasswordHash == password;

        }
    }
}
