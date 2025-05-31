using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.DTOs.Presupuesto.Response
{
    public class PresupuestoResponseDto
    {
        public int Id { get; set; }
        public string? TipoGasto { get; set; }
        public string? Mes { get; set; }
        public int Año { get; set; }
        public double Monto { get; set; }
        public DateTime? FechaCreacion { get; set; }

    }
}
