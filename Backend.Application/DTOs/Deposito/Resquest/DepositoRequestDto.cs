namespace Backend.Application.DTOs.Deposito.Resquest
{
    public class DepositoRequestDto
    {
        public DateTime Fecha { get; set; }
        public string? FondoMonectario { get; set; }
        public double Monto { get; set; }
        public string? Observacion { get; set; }
    }
}
