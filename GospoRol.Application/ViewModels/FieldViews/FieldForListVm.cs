using System.ComponentModel;
using AutoMapper;
using GospoRol.Application.Mapping;
using GospoRol.Domain.Models;

namespace GospoRol.Application.ViewModels
{
    public class FieldForListVm : IMapFrom<Field>
    {
        public int Id { get; set; }
        [DisplayName("Nazwa Pola")]
        public string FieldName { get; set; }
        [DisplayName("Areał")]
        public double Acreage { get; set; }
        [DisplayName("Uprawiana roślina")]
        public string CultivatedPlant { get; set; }
        [DisplayName("Odmiana uprawianej rośliny")]
        public string Variety { get; set; }
        [DisplayName("Klasa gruntu rolnego")]
        public AgriculturalClass AgriculturalClass { get; set; }
        [DisplayName("Odległość do magazynu")]
        public double DistanceToWarehouse { get; set; }
        [DisplayName("Numer działki")]
        public Land Land { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Field, FieldForListVm>();
            
        }
    }
}