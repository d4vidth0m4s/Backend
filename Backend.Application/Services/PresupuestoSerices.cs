using Backend.Application.DTOs.Presupuesto.Response;
using Backend.Application.DTOs.Presupuesto.Resquest;
using Backend.Application.Interfaz;
using Backend.Domain.Entities;
using Backend.Domain.IRepository;
using Mapster;

namespace Backend.Application.Services
{
    public class PresupuestoServices(IPresupuestoRepository repo) : IPresupuestosServices
    {
        private readonly IPresupuestoRepository _repo = repo;

        public async Task<int> CreateAsync(PresupuestoRequestDto dto)
        {
            var response = dto.Adapt<Presupuesto>();
            response.FechaCreacion = DateTime.UtcNow;
            return await _repo.CreateAsync(response);
        }

        public async Task<IEnumerable<PresupuestoResponseDto>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            return data.Select(a => new PresupuestoResponseDto
            {
                Id = a.Id,
                TipoGasto = a.TipoGasto,
                Mes = a.Mes,
                Año = a.Año,
                Monto=a.Monto,

            });
        }

        public async Task<PresupuestoResponseDto?> GetByIdAsync(int id)
        {
            var a = await _repo.GetByIdAsync(id);
            if (a == null) return null;

            return new PresupuestoResponseDto
            {
                Id = a.Id,
                TipoGasto = a.TipoGasto,
                Mes = a.Mes,
                Año = a.Año,
                Monto = a.Monto,

            };
        }

        public async Task<bool> UpdateAsync(PresupuestoEditRequestDto dto)
        {
            var response = dto.Adapt<Presupuesto>();
            return await _repo.UpdateAsync(response);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

    }
}
