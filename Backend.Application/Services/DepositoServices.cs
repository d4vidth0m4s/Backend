using Backend.Application.DTOs.Deposito.Response;
using Backend.Application.DTOs.Deposito.Resquest;
using Backend.Application.Interfaz;
using Backend.Domain.Entities;
using Backend.Domain.IRepository;
using Mapster;

namespace Backend.Application.Services
{
    internal class DepositoServices(IDepositoRepository repo) : IDepositoServices
    {
        private readonly IDepositoRepository _repo = repo;

        public async Task<int> CreateAsync(DepositoRequestDto dto)
        {
            var response = dto.Adapt<Deposito>();
            response.FechaCreacion = DateTime.UtcNow;
            return await _repo.CreateAsync(response);
        }

        public async Task<IEnumerable<DepositoResponseDto>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            return data.Select(a => new DepositoResponseDto
            {
                Id = a.Id,
                Fecha =a.Fecha,
                FondoMonectario=a.FondoMonetario!.Nombre,
                Monto=a.Monto,
                Observacion=a.Observacion,
                FechaCreacion=a.FechaCreacion,
            });
        }

        public async Task<DepositoResponseDto?> GetByIdAsync(int id)
        {
            var a = await _repo.GetByIdAsync(id);
            if (a == null) return null;

            return new DepositoResponseDto
            {
                Id = a.Id,
                Fecha = a.Fecha,
                FondoMonectario = a.FondoMonetario!.Nombre,
                Monto = a.Monto,
                Observacion = a.Observacion,
            };
        }

        public async Task<bool> UpdateAsync(DepositoEditRequestDto dto)
        {
            var response = dto.Adapt<Deposito>();
            return await _repo.UpdateAsync(response);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
