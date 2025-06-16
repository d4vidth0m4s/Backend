using Backend.Application.DTOs.TipoGasto.Response;
using Backend.Application.DTOs.TipoGasto.Resquest;
using Backend.Application.Interfaz;
using Backend.Domain.Entities;
using Backend.Domain.IRepository;
using Mapster;
using shortid;
using shortid.Configuration;

namespace Backend.Application.Services
{
    public class TipoGastoServices(ITipoGastoRepository repo): ITipoGastoServices
    {
        private readonly ITipoGastoRepository _repo = repo;

        public async Task<string> CreateAsync(TipoGastoRequestDto dto, int userId)
        {
            ShortId.SetCharacters("0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");
            ShortId.SetSeed(Environment.TickCount);
            var options = new GenerationOptions(length: 9, useSpecialCharacters:false);


            var response = dto.Adapt<TipoGasto>();
            response.FechaCreacion = DateTime.UtcNow;
            response.Id = ShortId.Generate(options);
            response.UserId = userId;
            return await _repo.CreateAsync(response);
        }

        public async Task<IEnumerable<TipoGastoResponseDto>> GetAllAsync(int userId)
        {
            var data = await _repo.GetAllAsync(userId);
            return data.Select(a => new TipoGastoResponseDto
            {
                UserId = a.UserId,
                Id = a.Id,
                Descripcion = a.Descripcion,
                FechaCreacion = a.FechaCreacion,
            });
        }

        public async Task<TipoGastoResponseDto?> GetByIdAsync(string id)
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

        public async Task<bool> UpdateAsync(TipoGastoEditRequestDto dto, int userId)
        {
            var response = dto.Adapt<TipoGasto>();
            return await _repo.UpdateAsync(response, userId);
        }

        public async Task<bool> DeleteAsync(string id, int userId)
        {
            return await _repo.DeleteAsync(id, userId);
        }
    }
}
