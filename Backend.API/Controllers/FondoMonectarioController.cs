using Backend.Application.DTOs.FondoMonectario.Response;
using Backend.Application.DTOs.FondoMonectario.Resquest;
using Backend.Application.DTOs.TipoGasto.Response;
using Backend.Application.DTOs.TipoGasto.Resquest;
using Backend.Application.Interfaz;
using Backend.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FondoMonectarioController(IFondoMonectarioServices fondoMonectarioServices) : ControllerBase
    {
        private readonly IFondoMonectarioServices _fondoMonectarioServices = fondoMonectarioServices;
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] FondoMonectarioRequestDto dto)
        {
            var id = await _fondoMonectarioServices.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FondoMonectarioRequestDto>> GetById(int id)
        {
            var response = await _fondoMonectarioServices.GetByIdAsync(id);
            if (response == null) return NotFound();

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] FondoMonectarioEditRequestDto dto)
        {
            if (id != dto.Id) return BadRequest();

            var updated = await _fondoMonectarioServices.UpdateAsync(dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _fondoMonectarioServices.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FondoMonectarioResponseDto>>> GetAll()
        {
            var response = await _fondoMonectarioServices.GetAllAsync();
            return Ok(response);
        }
    }
}
