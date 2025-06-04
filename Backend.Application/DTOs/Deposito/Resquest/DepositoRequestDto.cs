namespace Backend.Application.DTOs.Deposito.Resquest
{
    public class DepositoRequestDto
    {
        public DateTime Fecha { get; set; }
        public int FondoMonetarioId { get; set; }
        public double Monto { get; set; }
        public string? Observacion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
