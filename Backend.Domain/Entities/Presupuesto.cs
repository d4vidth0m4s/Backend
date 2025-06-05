
namespace Backend.Domain.Entities
{
    public class Presupuesto
    {
        public int Id { get; set; }
        public string? Mes { get; set; }
        public int Anio { get; set; }
        public double Monto { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public string TipoGastoId { get; set; }
        public TipoGasto? TipoGasto { get; set; }
    }
}
