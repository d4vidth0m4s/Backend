using Backend.Application.DTOs.TipoGasto.Response;
using Backend.Application.DTOs.TipoGasto.Resquest;
using Backend.Application.Interfaz;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoGastoController(ITipoGastoServices tipoGastoServices) : ControllerBase
    {
        private readonly ITipoGastoServices _tipoGastoServices = tipoGastoServices;

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] TipoGastoRequestDto dto)
        {
            var id = await _tipoGastoServices.CreateAsync(dto);
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
            if (id != dto.Id) return BadRequest();

            var updated = await _tipoGastoServices.UpdateAsync(dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var deleted = await _tipoGastoServices.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoGastoResponseDto>>> GetAll()
        {
            var response = await _tipoGastoServices.GetAllAsync();
            return Ok(response);
        }
    }
}
