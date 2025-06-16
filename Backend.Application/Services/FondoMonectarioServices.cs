using Backend.Application.DTOs.FondoMonectario.Response;
using Backend.Application.DTOs.FondoMonectario.Resquest;
using Backend.Application.Interfaz;
using Backend.Domain.Entities;
using Backend.Domain.IRepository;
using Mapster;

namespace Backend.Application.Services
{
    public class FondoMonectarioServices(IFondoMonectarioRepository repo) : IFondoMonectarioServices
    {
        private readonly IFondoMonectarioRepository _repo = repo;
        public async Task<int> CreateAsync(FondoMonectarioRequestDto dto, int userId)
        {
            var response = dto.Adapt<FondoMonetario>();
            response.FechaCreacion = DateTime.UtcNow;
            response.UserId = userId;
            return await _repo.CreateAsync(response);
        }

        public async Task<IEnumerable<FondoMonectarioResponseDto>> GetAllAsync(int userId)
        {
            var data = await _repo.GetAllAsync(userId);
            return data.Select(a => new FondoMonectarioResponseDto
            {
                Id = a.Id,
                Nombre = a.Nombre,
                SaldoInicial=a.SaldoInicial,
                SaldoActual=a.SaldoActual,
                FechaCreacion = a.FechaCreacion,
                Descripcion = a.Descripcion,
            });
        }

        public async Task<FondoMonectarioResponseDto?> GetByIdAsync(int id)
        {
            var a = await _repo.GetByIdAsync(id);
            if (a == null) return null;

            return new FondoMonectarioResponseDto
            {
                Id = a.Id,
                Nombre = a.Nombre,
                SaldoInicial = a.SaldoInicial,
                SaldoActual = a.SaldoActual,
                FechaCreacion = a.FechaCreacion,
                Descripcion = a.Descripcion,

            };
        }

        public async Task<bool> UpdateAsync(FondoMonectarioEditRequestDto dto, int userId)
        {
            var response = dto.Adapt<FondoMonetario>();
            return await _repo.UpdateAsync(response, userId);
        }

        public async Task<bool> DeleteAsync(int id, int userId)
        {
            return await _repo.DeleteAsync(id, userId);
        }
    }    
}
