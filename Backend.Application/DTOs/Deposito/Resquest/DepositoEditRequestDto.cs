namespace Backend.Application.DTOs.Deposito.Resquest
{
    public class DepositoEditRequestDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int FondoMonetarioId { get; set; }
        public double Monto { get; set; }
        public string? Observacion { get; set; }
    }
}
