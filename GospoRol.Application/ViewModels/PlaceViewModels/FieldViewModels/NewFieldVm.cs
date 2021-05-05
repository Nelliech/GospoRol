using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using FluentValidation;
using GospoRol.Application.Mapping;
using GospoRol.Domain.Models.Places;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GospoRol.Application.ViewModels.PlaceViewModels.FieldViewModels
{
    public class NewFieldVm : IMapFrom<Field>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [DisplayName("Nazwa Pola")]
        [Required(ErrorMessage = "Nazwa Pola jest wymagana")]
        public string FieldName { get; set; }
        [DisplayName("Areał [ha]")]
        [Required(ErrorMessage = "Areał jest wymagany")]
        public decimal Acreage { get; set; }
        //[DisplayName("Uprawiana roślina")]
        ////public string CultivatedPlant { get; set; }
        ////[DisplayName("Odmiana uprawianej rośliny")]
        ////public string Variety { get; set; }    
        ////[DisplayName("Klasa gleby")]
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
}