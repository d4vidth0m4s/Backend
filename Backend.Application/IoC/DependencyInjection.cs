using Backend.Application.Interfaz;
using Backend.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Application.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
           
            services.AddScoped<ITipoGastoServices, TipoGastoServices>();
            services.AddScoped<IFondoMonectarioServices, FondoMonectarioServices>();
            services.AddScoped<IDepositoServices, DepositoServices>();
            services.AddScoped<IPresupuestosServices, PresupuestoServices>();

            return services;
        }
    }
}
