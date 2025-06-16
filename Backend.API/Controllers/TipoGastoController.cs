using Backend.Application.DTOs.TipoGasto.Response;
using Backend.Application.DTOs.TipoGasto.Resquest;
using Backend.Application.Interfaz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TipoGastoController(ITipoGastoServices tipoGastoServices) : ControllerBase
    {
        private readonly ITipoGastoServices _tipoGastoServices = tipoGastoServices;

        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst("user_id");
            if (userIdClaim == null)
                throw new UnauthorizedAccessException("No se pudo encontrar el ID del usuario en el token.");

            return int.Parse(userIdClaim.Value);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> Create([FromBody] TipoGastoRequestDto dto)
        {
            var userId = GetCurrentUserId();
            
            var id = await _tipoGastoServices.CreateAsync(dto, userId);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoGastoResponseDto>> GetById(string id)
        {
            var response = await _tipoGastoServices.GetByIdAsync(id);
            if (response == null) return NotFound();

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] TipoGastoEditRequestDto dto)
        {
            var userId = GetCurrentUserId(); 

            if (id != dto.Id) return BadRequest();

            var updated = await _tipoGastoServices.UpdateAsync(dto, userId);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var userId = GetCurrentUserId();
            var deleted = await _tipoGastoServices.DeleteAsync(id, userId);
            return deleted ? NoContent() : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoGastoResponseDto>>> GetAll()
        {
             var userId = GetCurrentUserId();
            var response = await _tipoGastoServices.GetAllAsync(userId);
            return Ok(response);
        }
    }
}
