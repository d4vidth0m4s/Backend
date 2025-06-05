namespace Backend.Application.DTOs.RegistroGasto.Resquest
{
    public class RegistroGastoDetallesDto
    {
        public int IdRegistroGasto { get; set; }
        public string IdRegistroTipo { get; set; }
        public int Monto { get; set; }
    }
}
