
namespace Backend.Application.DTOs.FondoMonectario.Resquest
{
    public class FondoMonectarioEditRequestDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public double SaldoInicial { get; set; }

        public double SaldoActual { get; set; }
    }
}
