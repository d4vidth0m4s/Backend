using Backend.Application.DTOs.RegistroGasto.Response;
using Backend.Application.DTOs.RegistroGasto.Resquest;
using Backend.Application.DTOs.TipoGasto.Response;
using Backend.Application.DTOs.TipoGasto.Resquest;
using Backend.Application.Interfaz;
using Backend.Domain.Entities;
using Backend.Domain.IRepository;
using Mapster;

namespace Backend.Application.Services
{
    public class RegistroGastoService(IRegistroGastoReoisitory repo) : IRegistroGastoService
    {
        private readonly IRegistroGastoReoisitory _repo = repo;

        public async Task<int> CreateAsync(RegistroGastoRequestDto dto)
        {
            // var response = dto.Adapt<RegistroGasto>();
            var response = new RegistroGasto
            {
                Fecha = dto.Fecha,
                FondoMonetarioId = dto.FondoMonetarioId,
                Comercio = dto.Comercio,
                TipoDoc = dto.TipoDoc,
                Total = dto.Total,
                FechaCreacion = dto.FechaCreacion,
                TipoGastoId = dto.TipoGastoId,
                Detalles = dto.Detalles?.Select(d => new RegistroGastoDetalles
                {
                    IdRegistroTipo = d.IdRegistroTipo,
                    Monto = d.Monto
                }).ToList()
            };
            response.FechaCreacion = DateTime.UtcNow;
            return await _repo.CreateAsync(response);
        }

        public async Task<IEnumerable<RegistroGastoResponseDto>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            return data.Select(a => new RegistroGastoResponseDto
            {
                Id= a.Id,
                Fecha=a.Fecha,
                Comercio= a.Comercio,
                FondoMonetarioId = a.FondoMonetarioId,
                TipoDoc =a.TipoDoc,
                Total=a.Total,
                FechaCreacion=a.FechaCreacion,
                Detalles = a.Detalles?.Select(d => new RegistroGastoDetallesDto
                {
                    IdRegistroGasto = d.IdRegistroGasto,
                    IdRegistroTipo = d.IdRegistroTipo,
                    Monto = d.Monto
                }).ToList()
            });
        }


        public async Task<RegistroGastoResponseDto?> GetByIdAsync(int id)
        {
            var a = await _repo.GetByIdAsync(id);
            if (a == null) return null;

            return new RegistroGastoResponseDto
            {
                Id = a.Id,
                Fecha = a.Fecha,
                Comercio = a.Comercio,
                TipoDoc = a.TipoDoc,
                Total = a.Total,
                FechaCreacion = a.FechaCreacion,
            };
        }

        public async Task<bool> UpdateAsync(RegistroGastoEditRequestDto dto)
        {
            var response = dto.Adapt<RegistroGasto>();
            return await _repo.UpdateAsync(response);
        }


        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
