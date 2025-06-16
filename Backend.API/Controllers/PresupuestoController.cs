using Backend.Application.DTOs.Presupuesto.Response;
using Backend.Application.DTOs.Presupuesto.Resquest;
using Backend.Application.DTOs.TipoGasto.Response;
using Backend.Application.DTOs.TipoGasto.Resquest;
using Backend.Application.Interfaz;
using Backend.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PresupuestoController(IPresupuestosServices presupuestosServices) : ControllerBase
    {
        private readonly IPresupuestosServices _presupuestosServices = presupuestosServices;

        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst("user_id");
            if (userIdClaim == null)
                throw new UnauthorizedAccessException("No se pudo encontrar el ID del usuario en el token.");

            return int.Parse(userIdClaim.Value);
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] PresupuestoRequestDto dto)
        {
            var userId = GetCurrentUserId();
            var id = await _presupuestosServices.CreateAsync(dto, userId);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PresupuestoResponseDto>> GetById(int id)
        {
            var response = await _presupuestosServices.GetByIdAsync(id);
            if (response == null) return NotFound();

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] PresupuestoEditRequestDto dto)
        {
            if (id != dto.Id) return BadRequest();
            var userId = GetCurrentUserId();
            var updated = await _presupuestosServices.UpdateAsync(dto,userId);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = GetCurrentUserId();
            var deleted = await _presupuestosServices.DeleteAsync(id, userId);
            return deleted ? NoContent() : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PresupuestoResponseDto>>> GetAll()
        {
            var userId = GetCurrentUserId();
            var response = await _presupuestosServices.GetAllAsync(userId);
            return Ok(response);
        }

    }
}
