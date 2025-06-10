using Backend.Application.DTOs.Login.Response;
using Backend.Application.Interfaz;
using Backend.Domain.IRepository;



namespace Backend.Application.Services
{
    public class LoginServices : Iloginservices
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IJwtService _JwtService;

        public LoginServices(ILoginRepository loginRepository, IJwtService JwtService)
        {
            _loginRepository = loginRepository;
            _JwtService = JwtService;
        }



        public async Task<LoginResponseDto> loginAsync(string username, string password)
        {
            // Validar credenciales
            var usuario = await _loginRepository.ObtenerPorUsernameAsync(username);

            Console.WriteLine(usuario);
            bool isValid = await _loginRepository.ValidarCredencialesAsync(username, password);

            if (usuario == null || !isValid)
            {
                throw new UnauthorizedAccessException("Credenciales inválidas");
            }


           
            return new LoginResponseDto
            {
                Token = _JwtService.CreateToken(usuario),
                Username = usuario.Username,
                Nombre = usuario.Nombre
            };
        }


    }
}