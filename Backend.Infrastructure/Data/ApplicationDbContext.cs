using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<TipoGasto> TipoGastos { get; set; }
        public DbSet<FondoMonectario> FondoMonectarios { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }
        public DbSet<RegistroGasto> RegistroGastos { get; set; }
        public DbSet<Deposito> Depositos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
