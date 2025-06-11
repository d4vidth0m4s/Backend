using Backend.Application.DTOs.Login.Response;
using Backend.Application.DTOs.Login.Resquest;
using Microsoft.AspNetCore.Mvc;
using Backend.Application.Interfaz;
using Backend.Application.Services;
using Microsoft.AspNetCore.Identity.Data;
using Azure;
using Microsoft.AspNetCore.Authorization;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AutenticacionController(Iloginservices loginservices) : ControllerBase
    {
        private readonly Iloginservices _tipoGastoServices = loginservices;


        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto request)
        {
            var response = await _tipoGastoServices.loginAsync(request.Username, request.Password);
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpGet("login/authorize")]
        [Authorize]
        public IActionResult ValidateToken()
        {
            try
            {
                // El token ya fue validado por el middleware [Authorize]
                return Ok(new ValidateTokenDto
                {
                    ValToken = true,
                    Mensaje = "Token válido"
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(new ValidateTokenDto
                {
                    ValToken = false,
                    Mensaje = "Token inválido o expirado"
                });
            }
        }
    }
}