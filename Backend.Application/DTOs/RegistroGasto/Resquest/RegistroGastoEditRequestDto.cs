using Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.DTOs.RegistroGasto.Resquest
{
    public class RegistroGastoEditRequestDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int FondoMonetarioId { get; set; }
        public string? Comercio { get; set; }
        public string? TipoDoc { get; set; }
        public double Total { get; set; }
        public int TipoGastoId { get; set; }
    }
}
