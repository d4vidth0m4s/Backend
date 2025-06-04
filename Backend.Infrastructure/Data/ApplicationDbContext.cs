using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<TipoGasto> TipoGastos { get; set; }
        public DbSet<FondoMonetario> FondoMonectarios { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }
        public DbSet<RegistroGasto> RegistroGastos { get; set; }
        public DbSet<Deposito> Depositos { get; set; }
        public DbSet<RegistroGastoDetalles> RegistroGastoDetalles { get; set; }


        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FondoMonetario>()
             .HasMany(f => f.Depositos)
             .WithOne(d => d.FondoMonetario)
             .HasForeignKey(d => d.FondoMonetarioId);

            modelBuilder.Entity<FondoMonetario>()
                .HasMany(f => f.RegistroGastos)
                .WithOne(g => g.FondoMonetario)
                .HasForeignKey(g => g.FondoMonetarioId);

            modelBuilder.Entity<TipoGasto>()
                .HasMany(t => t.Presupuestos)
                .WithOne(p => p.TipoGasto)
                .HasForeignKey(p => p.TipoGastoId);

            modelBuilder.Entity<TipoGasto>()
                .HasMany(t => t.RegistroGastos)
                .WithOne(g => g.TipoGasto)
                .HasForeignKey(g => g.TipoGastoId);

            modelBuilder.Entity<RegistroGasto>()
              .HasMany(r => r.Detalles)
              .WithOne(d => d.RegistroGasto)
              .HasForeignKey(d => d.IdRegistroGasto);
        }
    }
}
