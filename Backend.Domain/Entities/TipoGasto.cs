﻿namespace Backend.Domain.Entities
{
    public class TipoGasto
    {
        public string Id { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public ICollection<Presupuesto> Presupuestos { get; set; } = [];
        public ICollection<RegistroGasto> RegistroGastos { get; set; } = [];
    }
}
