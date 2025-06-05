using System.ComponentModel.DataAnnotations;

namespace Backend.Domain.Entities
{
    public class Usuarios
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Usuername { get; set; } = string.Empty;
        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public bool Activo {  get; set; } = true;

        public DateTime FechaCreacion { get; set; }
    }
}
