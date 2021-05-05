using System.Collections.Generic;
using System.ComponentModel;
using AutoMapper;
using GospoRol.Application.Mapping;
using GospoRol.Domain.Models.Treatments;

namespace GospoRol.Application.ViewModels.TreatmentViewModels.SowingViewModels.TypeSowingViewModels
{
    public class TypeSowingForListVm : IMapFrom<TypeSowing>
    {
        public int Id { get; set; }
        [DisplayName("Metoda Siewu")]
        public string Name { get; set; }
        public List<Sowing> Sowings { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<TypeSowing, TypeSowingForListVm>();
        }
    }
}