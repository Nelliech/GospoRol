using System.Collections.Generic;
using System.ComponentModel;
using AutoMapper;
using GospoRol.Application.Mapping;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Application.ViewModels.ProductsViewsModels.FertilizerViewModels.TypeFertilizerViewModels
{
    public class TypeFertilizerForListVm : IMapFrom<TypeFertilizer>
    {
        public int Id { get; set; }
        [DisplayName("Rodzaj I Grupy Nawozów")]
        public string Name { get; set; }
        public List<Fertilizer> Fertilizers { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TypeFertilizer, TypeFertilizerForListVm>();
        }
    }
}