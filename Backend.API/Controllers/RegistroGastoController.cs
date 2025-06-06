﻿using Backend.Application.DTOs.RegistroGasto.Response;
using Backend.Application.DTOs.RegistroGasto.Resquest;
using Backend.Application.DTOs.TipoGasto.Response;
using Backend.Application.Interfaz;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistroGastoController(IRegistroGastoService tipoGastoServices) : ControllerBase
    {
        private readonly IRegistroGastoService _registroGastoService = tipoGastoServices;
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] RegistroGastoRequestDto dto)
        {
            var id = await _registroGastoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroGastoResponseDto>> GetById(int id)
        {
            var response = await _registroGastoService.GetByIdAsync(id);
            if (response == null) return NotFound();

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] RegistroGastoEditRequestDto dto)
        {
            if (id != dto.Id) return BadRequest();

            var updated = await _registroGastoService.UpdateAsync(dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _registroGastoService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoGastoResponseDto>>> GetAll()
        {
            var response = await _registroGastoService.GetAllAsync();
            return Ok(response);
        }

    }
}
