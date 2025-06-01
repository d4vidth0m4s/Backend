namespace Backend.Domain.Entities
{
    public class FondoMonetario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public double SaldoInicial { get; set; }
        public double SaldoActual { get; set; }
        public DateTime FechaCreacion { get; set; }

        public ICollection<Deposito>? Depositos { get; set; }
        public ICollection<RegistroGasto>? RegistroGastos { get; set; }

    }
}
