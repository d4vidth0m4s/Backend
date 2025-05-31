using Backend.Domain.IRepository;
using Backend.Infrastructure.Data;
using Backend.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Infrastructure.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ITipoGastoRepository, TipoGastoRepository>();
            services.AddScoped<IFondoMonectarioRepository, FondoMonectarioRepository>();
            services.AddScoped<IDepositoRepository, DepositoRepository>();
            services.AddScoped<IPresupuestoRepository, PresupuestoRepository>();


            return services;
        }
    }
}
