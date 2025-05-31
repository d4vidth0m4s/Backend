using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.DTOs.Presupuesto.Resquest
{
    public class PresupuestoRequestDto
    {
        public string? TipoGasto { get; set; }
        public string? Mes { get; set; }
        public int Año { get; set; }
        public double Monto { get; set; }
    }
}
