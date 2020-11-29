using System.ComponentModel;
using AutoMapper;
using GospoRol.Application.Mapping;
using GospoRol.Domain.Models.Places;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Application.ViewModels.ProductsViewsModels.SeedViewModels
{
    public class SeedForListVm : IMapFrom<Seed>
    {
        public int Id { get; set; }
        [DisplayName("Nazwa Rosliny")]
        public string NamePlant { get; set; }
        [DisplayName("Odmiana Rosliny")]
        public string PlantVariety { get; set; }
        [DisplayName("Producent")]
        public string Producer { get; set; }
        [DisplayName("Ilość")]
        public decimal Capacity { get; set; }
        [DisplayName("Obecna Ilość")]
        public decimal CurrentAmount { get; set; }
        [DisplayName("Cena")]
        public decimal Price { get; set; }
        [DisplayName("Dodatkowe informacje")]
        public string AdditionalInformation { get; set; }
        [DisplayName("Nazwa Magazynu")]
        public Warehouse Warehouse { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Seed, SeedForListVm>();

        }
    }
}