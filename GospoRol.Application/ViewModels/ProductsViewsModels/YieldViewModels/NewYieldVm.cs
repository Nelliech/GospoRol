using System.Collections.Generic;
using System.ComponentModel;
using AutoMapper;
using GospoRol.Application.Mapping;
using GospoRol.Domain.Models.Products;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GospoRol.Application.ViewModels.ProductsViewsModels.YieldViewModels
{
    public class NewYieldVm : IMapFrom<Yield>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [DisplayName("Nazwa Rosliny")]
        public string NamePlant { get; set; }
        [DisplayName("Odmiana Rosliny")]
        public string PlantVariety { get; set; }
        [DisplayName("Ilość")]
        public decimal Count { get; set; }
        [DisplayName("Jednostka")]
        public YieldUnit YieldUnit { get; set; }
        [DisplayName("Dodatkowe informacje")]
        public string AdditionalInformation { get; set; }
        
        [DisplayName("Magazyn")]
        public int WarehouseId { get; set; }
        public List<SelectListItem> Warehouses { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewYieldVm, Yield>();
        }
    }
}