namespace Backend.Domain.Entities
{
    public class RegistroGasto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string? FondoMonectario { get; set; }
        public string? Comercio { get; set; }
        public string? TipoDoc { get; set; }
        public double Total { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
