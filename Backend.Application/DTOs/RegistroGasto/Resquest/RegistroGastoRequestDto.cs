namespace Backend.Application.DTOs.RegistroGasto.Resquest
{
    public class RegistroGastoRequestDto
    {
        public DateTime Fecha { get; set; }
        public int FondoMonetarioId { get; set; }
        public string? Comercio { get; set; }
        public string? TipoDoc { get; set; }
        public double Total { get; set; }
        public DateTime FechaCreacion { get; set; }

        public int TipoGastoId { get; set; }

        public List<RegistroGastoDetallesDto>? Detalles { get; set; }
    }
}
