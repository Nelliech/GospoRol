using System;
using System.ComponentModel;
using AutoMapper;
using GospoRol.Application.Mapping;
using GospoRol.Domain.Models.Places;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Application.ViewModels.ProductsViewsModels.FertilizerViewModels
{
    public class FertilizerForListVm : IMapFrom<Fertilizer>
    {
        [DisplayName("Producent")]
        public string Producer { get; set; }       
        [DisplayName("Formuła Nawozu")]
        public string FertilizerComposition { get; set; }
        [DisplayName("Stężenie głównego związku nawozu")]
        public decimal Concentration { get; set; }
        [DisplayName("Pojemność opakowania")]
        public decimal Capacity { get; set; }
        [DisplayName("Obecna Ilość")]
        public decimal CurrentAmount { get; set; }
        [DisplayName("Jednostka")]
        public FertilizerUnit FertilizerUnit { get; set; }
        [DisplayName("Cena")]
        public decimal Price { get; set; }
        [DisplayName("Dodatkowe informacje")]
        public string AdditionalInformation { get; set; }
        [DisplayName("Rodzaj Nawozu")]
        public TypeFertilizer TypeFertilizer { get; set; }
        [DisplayName("Nazwa Magazynu")]
        public Warehouse Warehouse { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Fertilizer, FertilizerForListVm>();
        } 
    }
}