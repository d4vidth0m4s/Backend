
using System.ComponentModel.DataAnnotations;


namespace Backend.Application.DTOs.Login.Response
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
    }


}
