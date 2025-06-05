using Backend.Application.DTOs.Login.Response;
using Backend.Application.DTOs.Login.Resquest;
using Microsoft.AspNetCore.Mvc;
using Backend.Application.Interfaz;
using Backend.Application.Services;
using Microsoft.AspNetCore.Identity.Data;
using Azure;

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
            var response = await _tipoGastoServices.loginAsync(request.Username,request.Password);
            if (response == null) return NotFound();
            return Ok(response);
        }
    }
}