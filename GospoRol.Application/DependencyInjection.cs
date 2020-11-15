using System.Reflection;
using GospoRol.Application.Interfaces;
using GospoRol.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace GospoRol.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ILandService, LandService>();
            services.AddTransient<IFieldService, FieldService>();
            services.AddTransient<IAgriculturalClassService, AgriculturalClassService>();
            services.AddTransient<IWarehouseService, WarehouseService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;

        }
    }
}