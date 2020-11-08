using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using GospoRol.Domain.Models;
using GospoRol.Domain.Models.Products;
using GospoRol.Domain.Models.Treatments;
using Microsoft.EntityFrameworkCore;

namespace GospoRol.Infrastructure
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Land> Lands { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Cultivation> Cultivatings { get; set; }
        public DbSet<TypeCultivation> TypeCultivations { get; set; }
        public DbSet<Fertilization> Fertilizations { get; set; }
        public DbSet<TypeFertilization> TypeFertilizations { get; set; }
        public DbSet<Harvest> Harvests { get; set; }
        public DbSet<MechanicalWeedControl> MechanicalWeedControls { get; set; }
        public DbSet<Sowing> Sowings { get; set; }
        public DbSet<Spraying> Sprayings { get; set; }
        public DbSet<TypeSowing> TypeSowings { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Fertilizer> Fertilizers { get; set; }
        public DbSet<TypeFertilizer> TypeFertilizers { get; set; }
        public DbSet<Pesticide> Pesticides { get; set; }
        public DbSet<TypePesticide> TypePesticides { get; set; }
        public DbSet<Seed> Seeds { get; set; }
        public DbSet<AgriculturalClass> AgriculturalClasses { get; set; }
        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
          
            builder.SendInitialData();

        }
    }
}
