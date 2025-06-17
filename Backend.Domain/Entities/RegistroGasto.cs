namespace Backend.Domain.Entities
{
    public class RegistroGasto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string? Comercio { get; set; }
        public string? TipoDoc { get; set; }
        public double Total { get; set; }
        public DateTime FechaCreacion { get; set; }

        

        public int FondoMonetarioId { get; set; }
        public FondoMonetario? FondoMonetario { get; set; }


        public int UserId { get; set; }
        public Usuario Usuario { get; set; }


        public ICollection<RegistroGastoDetalles>? Detalles { get; set; }


    }
}
