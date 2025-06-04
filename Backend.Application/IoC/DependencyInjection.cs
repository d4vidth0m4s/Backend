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
            services.AddScoped<IMovimientoService, MovimientoService>();
            services.AddScoped<IGraficoPresupuestoService, GraficoPresupuestoService>();
            services.AddScoped<IRegistroGastoService, RegistroGastoService>();

            return services;
        }
    }
}
