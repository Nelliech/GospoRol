using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using GospoRol.Application.Mapping;
using GospoRol.Domain.Models;
using GospoRol.Domain.Models.Places;
using GospoRol.Domain.Models.Products;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GospoRol.Application.ViewModels.ProductsViewsModels.FertilizerViewModels
{
    public class NewFertilizerVm : IMapFrom<Fertilizer>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [DisplayName("Producent")]
        public string Producer { get; set; }           
        [DisplayName("Skład Nawozu")]
        public string FertilizerComposition { get; set; }
        [DisplayName("Steżenie")]
        public string Concentration { get; set; }
        [DisplayName("Pojemność opakowania")]
        public decimal Capacity { get; set; }
        [DisplayName("Jednostka")]
        public FertilizerUnit FertilizerUnit { get; set; }
        [DisplayName("Obecna Ilość")]
        public decimal CurrentAmount { get; set; }
        [DisplayName("Cena")]
        public decimal Price { get; set; }
        [DisplayName("Dodatkowe informacje")]
        public string AdditionalInformation { get; set; }
        [DisplayName("Rodzaj nawozu")]
        public int TypeFertilizerId { get; set; }          
        public List<SelectListItem> TypeFertilizers { get; set; }
        [DisplayName("Nazwa Magazynu")]
        public int WarehouseId { get; set; }
        public List<SelectListItem> Warehouses { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewFertilizerVm, Fertilizer>().ReverseMap();
        }
    }
}