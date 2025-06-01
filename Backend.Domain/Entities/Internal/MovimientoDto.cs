namespace Backend.Domain.Entities.Internal
{
    public class MovimientoDto
    {
        public DateTime Fecha { get; set; }
        public string? Tipo { get; set; }
        public int FondoMonetarioId { get; set; }
        public string? FondoMonetario { get; set; }
        public double Monto { get; set; }
        public string? Descripcion { get; set; }
    }
}
