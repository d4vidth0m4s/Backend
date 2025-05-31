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

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] PresupuestoRequestDto dto)
        {
            var id = await _presupuestosServices.CreateAsync(dto);
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

            var updated = await _presupuestosServices.UpdateAsync(dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _presupuestosServices.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PresupuestoResponseDto>>> GetAll()
        {
            var response = await _presupuestosServices.GetAllAsync();
            return Ok(response);
        }

    }
}
