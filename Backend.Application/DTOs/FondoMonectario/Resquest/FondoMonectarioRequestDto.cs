
namespace Backend.Application.DTOs.FondoMonectario.Resquest
{
    public class FondoMonectarioRequestDto
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public double SaldoInicial { get; set; }

        public double SaldoActual { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
