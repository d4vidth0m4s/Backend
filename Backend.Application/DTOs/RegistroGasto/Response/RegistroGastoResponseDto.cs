using Backend.Application.DTOs.RegistroGasto.Resquest;
using Backend.Domain.Entities;

namespace Backend.Application.DTOs.RegistroGasto.Response
{
    public class RegistroGastoResponseDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int FondoMonetarioId { get; set; }
        public string? Comercio { get; set; }
        public string? TipoDoc { get; set; }
        public double Total { get; set; }
        public DateTime FechaCreacion { get; set; }

        public List<RegistroGastoDetallesDto>? Detalles { get; set; }

    }
}
