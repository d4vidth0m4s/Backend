namespace Backend.Application.DTOs.Presupuesto.Resquest
{
    public class PresupuestoRequestDto
    {
        public string? Mes { get; set; }
        public int Año { get; set; }
        public double Monto { get; set; }
        public int TipoGastoId { get; set; }
    }
}
