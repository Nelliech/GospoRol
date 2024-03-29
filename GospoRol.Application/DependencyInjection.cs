﻿using System.Reflection;
using GospoRol.Application.Interfaces;
using GospoRol.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using GospoRol.Application.Interfaces.PlaceInterfaces;
using GospoRol.Application.Interfaces.ProductInterfaces;
using GospoRol.Application.Interfaces.TreatmentInterfaces;
using GospoRol.Application.Services.PlaceServices;
using GospoRol.Application.Services.ProductServices;
using GospoRol.Application.Services.TreatmentServices;

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
            //Products
            services.AddTransient<ITypeFertilizerService, TypeFertilizerService>();
            services.AddTransient<IFertilizerService, FertilizerService>();
            services.AddTransient<ITypePesticideService, TypePesticideService>();
            services.AddTransient<IPesticideService, PesticideService>();
            services.AddTransient<ISeedService, SeedService>();
            services.AddTransient<IYieldService, YieldService>();
            //Treatments
            services.AddTransient<ISowingService, SowingService>();
            services.AddTransient<ITypeSowingService, TypeSowingService>();



            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;

        }
    }
}