using System.ComponentModel;
using AutoMapper;
using GospoRol.Application.Mapping;
using GospoRol.Domain.Models.Places;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Application.ViewModels.ProductsViewsModels.PesticideViewModels
{
    public class PesticideForListVm : IMapFrom<Pesticide>
    {
        public int Id { get; set; }
        [DisplayName("Producent")]
        public string Producer { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Skład Pestycyda")]
        public string PesticideComposition { get; set; }
        [DisplayName("Pojemność opakowania")]
        public decimal Capacity { get; set; }
        [DisplayName("Obecna Ilość")]
        public decimal CurrentAmount { get; set; }
        [DisplayName("Cena")]
        public decimal Price { get; set; }
        [DisplayName("Dodatkowe informacje")]
        public string AdditionalInformation { get; set; }
        [DisplayName("Rodzaj nawozu")]
        public TypePesticide TypePesticide { get; set; }
        [DisplayName("Nazwa Magazynu")]
        public Warehouse Warehouse { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Pesticide, PesticideForListVm>();
        }
    }
}