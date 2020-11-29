using System.Collections.Generic;
using System.ComponentModel;
using AutoMapper;
using GospoRol.Application.Mapping;
using GospoRol.Domain.Models.Products;
using GospoRol.Domain.Models.Treatments;

namespace GospoRol.Application.ViewModels.ProductsViewsModels.PesticideViewModels.TypePesticideViewModels
{
    public class TypePesticideForListVm : IMapFrom<TypePesticide>
    {
        public int Id { get; set; }
        [DisplayName("Rodzaj Pestycydów")]
        public string Name { get; set; }
        public List<Spraying> Sprayings { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TypePesticide, TypePesticideForListVm>();
        }
    }
}