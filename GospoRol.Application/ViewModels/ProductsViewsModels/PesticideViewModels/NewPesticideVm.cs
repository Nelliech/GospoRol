using System.Collections.Generic;
using System.ComponentModel;
using AutoMapper;
using GospoRol.Domain.Models.Products;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GospoRol.Application.ViewModels.ProductsViewsModels.PesticideViewModels
{
    public class NewPesticideVm
    {
        public int Id { get; set; }
        [DisplayName("Producent")]
        public string Producer { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Sklad Pestycydu")]
        public string PesticideComposition { get; set; }
        [DisplayName("Pojemność opakowania")]
        public decimal Capacity { get; set; }
        [DisplayName("Obecna Ilość")]
        public decimal CurrentAmount { get; set; }
        [DisplayName("Cena")]
        public decimal Price { get; set; }
        [DisplayName("Dodatkowe informacje")]
        public string AdditionalInformation { get; set; }
        public int TypePesticideId { get; set; }
        public List<SelectListItem> TypePesticide { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewPesticideVm, Pesticide>().ReverseMap();
        }
    }
}