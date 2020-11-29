using System.ComponentModel;
using AutoMapper;
using GospoRol.Domain.Models.Places;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Application.ViewModels.ProductsViewsModels.YieldViewModels
{
    public class YieldForListVm
    {
        [DisplayName("Nazwa Rosliny")]
        public string NamePlant { get; set; }
        [DisplayName("Odmiana Rosliny")]
        public string PlantVariety { get; set; }
        [DisplayName("Ilość")]
        public decimal Count { get; set; }
        [DisplayName("Dodatkowe informacje")]
        public string AdditionalInformation { get; set; }
        public Unit Unit { get; set; }
        [DisplayName("Nazwa Magazynu")]
        public Warehouse Warehouse { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Yield, YieldForListVm>();
        }
    }
}