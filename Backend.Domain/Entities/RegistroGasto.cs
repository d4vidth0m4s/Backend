namespace Backend.Domain.Entities
{
    public class RegistroGasto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int FondoMonetarioId { get; set; }
        public FondoMonetario? FondoMonetario { get; set; }
        public string? Comercio { get; set; }
        public string? TipoDoc { get; set; }
        public double Total { get; set; }
        public DateTime FechaCreacion { get; set; }

        public int TipoGastoId { get; set; }
        public TipoGasto? TipoGasto { get; set; }
    }
}
