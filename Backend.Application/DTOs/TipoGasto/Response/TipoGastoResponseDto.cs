namespace Backend.Application.DTOs.TipoGasto.Response
{
    public class TipoGastoResponseDto
    {
        public string Id { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int UserId { get; set; } 
    }
}
