namespace Backend.Application.DTOs.Presupuesto.Resquest
{
    public class PresupuestoEditRequestDto
    {
        public int Id { get; set; }
        public string? Mes { get; set; }
        public int Anio { get; set; }
        public double Monto { get; set; }
        public string TipoGastoId { get; set; }
    }
}
