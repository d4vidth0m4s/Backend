using Backend.Application.DTOs.TipoGasto.Response;
using Backend.Application.DTOs.TipoGasto.Resquest;
using Backend.Application.Interfaz;
using Backend.Domain.Entities;
using Backend.Domain.IRepository;
using Mapster;

namespace Backend.Application.Services
{
    public class TipoGastoServices(ITipoGastoRepository repo): ITipoGastoServices
    {
        private readonly ITipoGastoRepository _repo = repo;

        public async Task<int> CreateAsync(TipoGastoRequestDto dto)
        {
            var response = dto.Adapt<TipoGasto>();
            response.FechaCreacion = DateTime.UtcNow;
            return await _repo.CreateAsync(response);
        }

        public async Task<IEnumerable<TipoGastoResponseDto>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            return data.Select(a => new TipoGastoResponseDto
            {
                Id = a.Id,
                Descripcion = a.Descripcion,
                FechaCreacion = a.FechaCreacion,
            });
        }

        public async Task<TipoGastoResponseDto?> GetByIdAsync(int id)
        {
            var a = await _repo.GetByIdAsync(id);
            if (a == null) return null;

            return new TipoGastoResponseDto
            {
                Id = a.Id,
                Descripcion = a.Descripcion,
                FechaCreacion = a.FechaCreacion,
            };
        }

        public async Task<bool> UpdateAsync(TipoGastoEditRequestDto dto)
        {
            var response = dto.Adapt<TipoGasto>();
            return await _repo.UpdateAsync(response);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
