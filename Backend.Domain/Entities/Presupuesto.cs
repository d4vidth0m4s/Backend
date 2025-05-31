
namespace Backend.Domain.Entities
{
    public class Presupuesto
    {
        public int Id { get; set; }
        public string? TipoGasto { get; set; }
        public string? Mes { get; set; }
        public int Año { get; set; }
        public double Monto { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
