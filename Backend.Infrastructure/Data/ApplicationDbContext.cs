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
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.HasIndex(e => e.Username).IsUnique();
            });

            // Configuración de TipoGasto
            modelBuilder.Entity<TipoGasto>(entity =>
            {
                entity.HasKey(t => t.Id);


                entity.Property(t => t.UserId).IsRequired();

                entity.HasOne(t => t.Usuario)
                      .WithMany(u => u.TipoGastos)
                      .HasForeignKey(t => t.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Relaciones del TipoGasto
                entity.HasMany(t => t.Presupuestos)
                      .WithOne(p => p.TipoGasto)
                      .HasForeignKey(p => p.TipoGastoId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(t => t.RegistroGastos)
                      .WithOne(g => g.TipoGasto)
                      .HasForeignKey(g => g.TipoGastoId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuración de FondoMonetario
            modelBuilder.Entity<FondoMonetario>(entity =>
            {
                entity.HasKey(f => f.Id);

                entity.Property(p => p.UserId)
                      .IsRequired();

                entity.HasOne(f => f.Usuario)
                      .WithMany(u => u.FondoMonetos)
                      .HasForeignKey(f => f.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Relaciones con Depositos
                entity.HasMany(f => f.Depositos)
                      .WithOne(d => d.FondoMonetario)
                      .HasForeignKey(d => d.FondoMonetarioId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Relaciones con RegistroGastos
                entity.HasMany(f => f.RegistroGastos)
                      .WithOne(g => g.FondoMonetario)
                      .HasForeignKey(g => g.FondoMonetarioId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuración de Presupuesto
            modelBuilder.Entity<Presupuesto>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.UserId)
                      .IsRequired();

                entity.HasOne(p => p.Usuario)
                      .WithMany(u => u.Presupuestos)
                      .HasForeignKey(p => p.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(p => p.TipoGasto)
                      .WithMany(t => t.Presupuestos)
                      .HasForeignKey(p => p.TipoGastoId)
                      .OnDelete(DeleteBehavior.Restrict);
            });


            // Configuración de RegistroGasto
            modelBuilder.Entity<RegistroGasto>(entity =>
            {
                entity.HasKey(r => r.Id);

                // Relación con Detalles
                entity.HasMany(r => r.Detalles)
                      .WithOne(d => d.RegistroGasto)
                      .HasForeignKey(d => d.IdRegistroGasto)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuración de Deposito
            modelBuilder.Entity<Deposito>(entity =>
            {
                entity.HasKey(d => d.Id);
                
                entity.Property(p=>p.UserId).IsRequired();

                entity.HasOne(p => p.Usuario)
                      .WithMany(u => u.Depositos)
                      .HasForeignKey(p => p.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

            });

            // Configuración de RegistroGastoDetalles
            modelBuilder.Entity<RegistroGastoDetalles>(entity =>
            {
                entity.HasKey(d => d.Id);
            });

            // Datos semilla
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Username = "admin",
                    PasswordHash = "123", // Hash de "admin"
                    Nombre = "Administrador",
                    Activo = true,
                    FechaCreacion = new DateTime(2025, 5, 30, 0, 0, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}