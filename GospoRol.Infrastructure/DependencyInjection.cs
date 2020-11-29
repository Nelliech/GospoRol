﻿using GospoRol.Domain.Interfaces;
using GospoRol.Domain.Interfaces.PlaceInterfaces;
using GospoRol.Domain.Interfaces.ProductInterfaces;
using GospoRol.Domain.Interfaces.TreatmentInterfaces;
using GospoRol.Infrastructure.Repositories;
using GospoRol.Infrastructure.Repositories.PlaceRepositories;
using GospoRol.Infrastructure.Repositories.ProductRepositories;
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
            services.AddTransient<IWarehouseRepository, WarehouseRepository>();
            // Products
            services.AddTransient<ITypeFertilizerRepository, TypeFertilizerRepository>();
            services.AddTransient<IFertilizerRepository, FertilizerRepository>();
            services.AddTransient<ISeedRepository, SeedRepository>();
            services.AddTransient<IPesticideRepository, PesticideRepository>();
            services.AddTransient<IYieldRepository, YieldRepository>();







            return services;
        }
    }
}