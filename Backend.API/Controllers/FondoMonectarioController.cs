using Backend.Application.DTOs.FondoMonectario.Response;
using Backend.Application.DTOs.FondoMonectario.Resquest;
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
    public class FondoMonectarioController(IFondoMonectarioServices fondoMonectarioServices) : ControllerBase
    {
        private readonly IFondoMonectarioServices _fondoMonectarioServices = fondoMonectarioServices;

        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst("user_id") ?? throw new UnauthorizedAccessException("No se pudo encontrar el ID del usuario en el token.");
            return int.Parse(userIdClaim.Value);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] FondoMonectarioRequestDto dto)
        {
            var userId = GetCurrentUserId();
            var id = await _fondoMonectarioServices.CreateAsync(dto, userId);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FondoMonectarioRequestDto>> GetById(int id)
        {
            var userId = GetCurrentUserId();
            var response = await _fondoMonectarioServices.GetByIdAsync(id,userId);
            if (response == null) return NotFound();

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] FondoMonectarioEditRequestDto dto)
        {
            if (id != dto.Id) return BadRequest();
            var userId = GetCurrentUserId();
            var updated = await _fondoMonectarioServices.UpdateAsync(dto, userId);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = GetCurrentUserId();
            var deleted = await _fondoMonectarioServices.DeleteAsync(id, userId);
            return deleted ? NoContent() : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FondoMonectarioResponseDto>>> GetAll()
        {
            var userId = GetCurrentUserId();
            var response = await _fondoMonectarioServices.GetAllAsync(userId);
            return Ok(response);
        }
    }
}
