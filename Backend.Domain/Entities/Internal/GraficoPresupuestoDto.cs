namespace Backend.Domain.Entities.Internal
{
    public class GraficoPresupuestoDto
    {
        public string TipoGasto { get; set; } = string.Empty;
        public double Presupuesto { get; set; }
        public double Ejecutado { get; set; }
        public double Diferencia => Presupuesto - Ejecutado;
    }
}
