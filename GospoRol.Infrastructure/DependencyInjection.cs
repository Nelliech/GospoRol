using GospoRol.Domain.Interfaces;
using GospoRol.Infrastructure.Repositores;
using Microsoft.Extensions.DependencyInjection;

namespace GospoRol.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructures(this IServiceCollection services)
        {
            services.AddTransient<ILandRepository, LandRepository>();
            services.AddTransient<IFieldRepository, FieldRepository>();
            services.AddTransient<IAgriculturalClassRepository, AgriculturalClassRepository>();


            return services;
        }
    }
}