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

        public async Task<int> CreateAsync(PresupuestoRequestDto dto, int userId)
        {
            var response = dto.Adapt<Presupuesto>();
            response.FechaCreacion = DateTime.UtcNow;
            response.UserId = userId;
           
            return await _repo.CreateAsync(response);
        }
        public async Task<IEnumerable<PresupuestoResponseDto>> GetAllAsync(int userId)
        {
            var data = await _repo.GetAllAsync(userId);
            return data.Select(a => new PresupuestoResponseDto
            {
                Id = a.Id,
                TipoGasto = a.TipoGasto!.Descripcion,
                Mes = a.Mes,
                Anio = a.Anio,
                Monto = a.Monto,
                FechaCreacion = a.FechaCreacion,

            });
        }

        public async Task<PresupuestoResponseDto?> GetByIdAsync(int id)
        {
            var a = await _repo.GetByIdAsync(id);
            if (a == null) return null;

            return new PresupuestoResponseDto
            {
                Id = a.Id,
                TipoGasto = a.TipoGasto!.Descripcion,
                Mes = a.Mes,
                Anio = a.Anio,
                Monto = a.Monto,
                FechaCreacion = a.FechaCreacion

            };
        }

        public async Task<bool> UpdateAsync(PresupuestoEditRequestDto dto, int userId)
        {
            var response = dto.Adapt<Presupuesto>();
            return await _repo.UpdateAsync(response, userId);
        }

        public async Task<bool> DeleteAsync(int id, int userId)
        {
            return await _repo.DeleteAsync(id, userId);
        }

    }
}
