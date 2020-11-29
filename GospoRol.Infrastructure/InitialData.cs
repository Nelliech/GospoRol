using GospoRol.Domain.Models;
using GospoRol.Domain.Models.Places;
using GospoRol.Domain.Models.Products;
using GospoRol.Domain.Models.Treatments;
using Microsoft.EntityFrameworkCore;

namespace GospoRol.Infrastructure
{
    public static class InitialData 
    {
        public static void SendInitialData(this ModelBuilder builder)
        {
            builder.Entity<TypeTreatment>().HasData(
              new TypeTreatment() { Id = 1, Name = "Siew" },
              new TypeTreatment() { Id = 2, Name = "Zbiór" },
              new TypeTreatment() { Id = 3, Name = "Nawożenie" },
              new TypeTreatment() { Id = 4, Name = "Oprysk" },
              new TypeTreatment() { Id = 5, Name = "Odchwaszczanie" },
              new TypeTreatment() { Id = 6, Name = "Zabieg Uprawowy" }
            );
            builder.Entity<TypeCultivation>().HasData(
                new TypeCultivation() { Id = 1, Name = "Włókowanie" },
                new TypeCultivation() { Id = 2, Name = "Orka" },
                new TypeCultivation() { Id = 3, Name = "Bronowanie" },
                new TypeCultivation() { Id = 4, Name = "Kultywatorowanie" },
                new TypeCultivation() { Id = 5, Name = "Wałowanie" },
                new TypeCultivation() { Id = 6, Name = "Gryzowanie" }
            );
            builder.Entity<AgriculturalClass>().HasData(
                new AgriculturalClass() { Id = 1, Class = "I", NameClass = "Gleby orne najlepsze" },
                new AgriculturalClass() { Id = 2, Class = "II", NameClass = "Gleby orne bardzo dobre" },
                new AgriculturalClass() { Id = 3, Class = "III a", NameClass = "Gleby orne dobre" },
                new AgriculturalClass() { Id = 4, Class = "III b", NameClass = "Gleby orne średnio dobre" },
                new AgriculturalClass() { Id = 5, Class = "IV a", NameClass = "Gleby orne średniej jakości, lepsze" },
                new AgriculturalClass() { Id = 6, Class = "IV a", NameClass = "Gleby orne średniej jakości, gorsze" },
                new AgriculturalClass() { Id = 7, Class = "V", NameClass = "Gleby orne słabe" },
                new AgriculturalClass() { Id = 8, Class = "VI", NameClass = "Gleby orne najsłabsze" }
            );
            builder.Entity<TypeFertilization>().HasData(
                new TypeFertilization() { Id = 1, Name = "Nawożenie Przedsiewne" },
                new TypeFertilization() { Id = 2, Name = "Nawożenie Siewne" },
                new TypeFertilization() { Id = 3, Name = "Nawożenie Pogłówne" },
                new TypeFertilization() { Id = 4, Name = "Nawożenie Dolistne" }
            );
            builder.Entity<TypeSowing>().HasData(
                new TypeSowing() { Id = 1, Name = "Siew Gwiazdowy" },
                new TypeSowing() { Id = 2, Name = "Siew Punktowy" },
                new TypeSowing() { Id = 3, Name = "Siew Pasowy" },
                new TypeSowing() { Id = 4, Name = "Siew Rzędowy" },
                new TypeSowing() { Id = 5, Name = "Siew Rzutowy" }
            );
            builder.Entity<TypeProduct>().HasData(
                new TypeProduct() { Id = 1, Name = "Nawozy" },
                new TypeProduct() { Id = 2, Name = "Nasiona" },
                new TypeProduct() { Id = 3, Name = "Pestycydy" },
                new TypeProduct() { Id = 4, Name = "Plony Rolne" }

            );
            builder.Entity<TypeFertilizer>().HasData(
                new TypeFertilizer() { Id = 1, Name = "Nawóz Zielony" },
                new TypeFertilizer() { Id = 2, Name = "Nawóz Organiczny" },
                new TypeFertilizer() { Id = 3, Name = "Nawóz Mineralny" },
                new TypeFertilizer() { Id = 4, Name = "Azot" },
                new TypeFertilizer() { Id = 5, Name = "Fosfor" },
                new TypeFertilizer() { Id = 6, Name = "Potas" },
                new TypeFertilizer() { Id = 7, Name = "Mikroelementy" }
            );
            builder.Entity<TypePesticide>().HasData(
                new TypePesticide() { Id = 1, Name = "Algicyd" },
                new TypePesticide() { Id = 2, Name = "Bakteriocyd" },
                new TypePesticide() { Id = 3, Name = "Fungicyd" },
                new TypePesticide() { Id = 4, Name = "Herbicyd" },
                new TypePesticide() { Id = 5, Name = "Regulator wzrostu roślin" },
                new TypePesticide() { Id = 6, Name = "Regulator wzrostu owadów" },
                new TypePesticide() { Id = 7, Name = "Zoocyd" },
                new TypePesticide() { Id = 8, Name = "Synergetyk" },
                new TypePesticide() { Id = 9, Name = "Wirocyd" }
            );
        }
    }
}