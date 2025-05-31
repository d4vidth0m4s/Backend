using Backend.Application.DTOs.Deposito.Response;
using Backend.Application.DTOs.Deposito.Resquest;
using Backend.Application.DTOs.TipoGasto.Response;
using Backend.Application.DTOs.TipoGasto.Resquest;
using Backend.Application.Interfaz;
using Backend.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepositoContoller(IDepositoServices depositoServices ) : ControllerBase
    {
        private readonly IDepositoServices _depositoServices = depositoServices;

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] DepositoRequestDto dto)
        {
            var id = await _depositoServices.CreateAsync(dto);
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

            var updated = await _depositoServices.UpdateAsync(dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _depositoServices.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepositoResponseDto>>> GetAll()
        {
            var response = await _depositoServices.GetAllAsync();
            return Ok(response);
        }

    }
}
