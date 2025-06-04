namespace Backend.Domain.Entities
{
    public class RegistroGastoDetalles
    {
        public int Id { get; set; }
        public int IdRegistroGasto { get; set; }
        public int IdRegistroTipo { get; set; }
        public int Monto { get; set; }
        public RegistroGasto? RegistroGasto { get; set; }
    }
}
