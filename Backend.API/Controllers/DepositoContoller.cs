using Backend.Application.DTOs.Deposito.Response;
using Backend.Application.DTOs.Deposito.Resquest;
using Backend.Application.DTOs.TipoGasto.Response;
using Backend.Application.DTOs.TipoGasto.Resquest;
using Backend.Application.Interfaz;
using Backend.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DepositoContoller(IDepositoServices depositoServices ) : ControllerBase
    {
        private readonly IDepositoServices _depositoServices = depositoServices;

        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst("user_id") ?? throw new UnauthorizedAccessException("No se pudo encontrar el ID del usuario en el token.");
            return int.Parse(userIdClaim.Value);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] DepositoRequestDto dto)
        {
            var userId = GetCurrentUserId(); 
            var id = await _depositoServices.CreateAsync(dto,userId);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepositoResponseDto>> GetById(int id)
        {
            var response = await _depositoServices.GetByIdAsync(id);
            if (response == null) return NotFound();

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] DepositoEditRequestDto dto)
        {
            if (id != dto.Id) return BadRequest();
            var userId = GetCurrentUserId();
            var updated = await _depositoServices.UpdateAsync(dto,userId);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = GetCurrentUserId();
            var deleted = await _depositoServices.DeleteAsync(id, userId);
            return deleted ? NoContent() : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepositoResponseDto>>> GetAll()
        {
            var userId = GetCurrentUserId();
            var response = await _depositoServices.GetAllAsync(userId);
            return Ok(response);
        }

    }
}
