namespace Backend.Application.DTOs.Graficas.Response
{
    public class GraficoPresupuestoDto
    {
        public string TipoGasto { get; set; } = string.Empty;
        public double Presupuesto { get; set; }
        public double Ejecutado { get; set; }
        public double Diferencia => Presupuesto - Ejecutado;
    }
}
