using AutoMapper;
using GospoRol.Application.Mapping;
using GospoRol.Domain.Models.Places;

namespace GospoRol.Application.ViewModels.PlaceViewModels.AgriculturalClassViewModels
{
    public class AgrClassForListVm : IMapFrom<AgriculturalClass>
    {
        public int Id { get; set; }
        public string Class { get; set; }
        public string NameClass { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AgriculturalClass, AgrClassForListVm>();
        }
    }
}