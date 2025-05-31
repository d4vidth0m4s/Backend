namespace Backend.Domain.Entities
{
    public class FondoMonectario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public double SaldoInicial { get; set; }

        public double SaldoActual { get; set; }
        public DateTime FechaCreacion { get; set; }


    }
}
