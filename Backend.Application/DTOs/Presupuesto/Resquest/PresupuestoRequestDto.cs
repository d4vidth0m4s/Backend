namespace Backend.Application.DTOs.Presupuesto.Resquest
{
    public class PresupuestoRequestDto
    {
        public string? Mes { get; set; }
        public int Anio { get; set; }
        public double Monto { get; set; }
        public int TipoGastoId { get; set; }

        public string? FechaCreacion { get; set; }
    }
}
