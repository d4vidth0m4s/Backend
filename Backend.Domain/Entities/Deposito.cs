namespace Backend.Domain.Entities
{
    public class Deposito
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string? FondoMonectario { get; set; }
        public double Monto { get; set; }
        public string? Observacion { get; set; }
       
        public DateTime FechaCreacion { get; set; }
    }
}
