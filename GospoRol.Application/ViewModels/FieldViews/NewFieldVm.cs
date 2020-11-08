using System.Collections.Generic;
using System.ComponentModel;
using AutoMapper;
using FluentValidation;
using GospoRol.Application.Mapping;
using GospoRol.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GospoRol.Application.ViewModels
{
    public class NewFieldVm : IMapFrom<Field>
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
        [DisplayName("Odległość do magazynu")]
        public double DistanceToWarehouse { get; set; }
        [DisplayName("Klasa gleby")]
        public int AgriculturalClassId { get; set; }
        public List<SelectListItem> AgriculturalClasses { get; set; }
        [DisplayName("Grunt Rolny / Działka")]
        public int LandId { get; set; }
        public List<SelectListItem> Lands { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewFieldVm, Field>().ReverseMap();
        }
    }

    public class NewFieldValidation : AbstractValidator<NewFieldVm>
    {
        public NewFieldValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Acreage).NotNull();
        }
    }
}