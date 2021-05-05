using System;
using System.Collections.Generic;
using AutoMapper;
using GospoRol.Application.Mapping;
using GospoRol.Domain.Models.Places;
using GospoRol.Domain.Models.Products;
using GospoRol.Domain.Models.Treatments;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace GospoRol.Application.ViewModels.TreatmentViewModels.SowingViewModels
{
    public class NewSowingVm : IMapFrom<Sowing>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [DisplayName("Data Zabiegu")]

        public DateTime DateTreatment { get; set; }
        [DisplayName("Rodzaj Rośliny")]
        public string CultivatedPlant { get; set; } 
        [DisplayName("Gatunek Rośliny")]
        public string PlantVariety { get; set; }
        [DisplayName("Areał [ha]")]
        public decimal Area { get; set; }    
        [DisplayName("Dodatkowe Informacje")]
        public string AdditionalInformation { get; set; }
        [DisplayName("Szerokość Rzędów [mm]")]
        public double WidthBetweenRows { get; set; }
        [DisplayName("Ilość Rzędów")]
        public int NumberRows { get; set; }
        [DisplayName("Ilość Rozsianego Materiału")]
        public decimal HowManyHa { get; set; }
        [DisplayName("Jednostka")]
        public SowingUnit SowingUnit { get; set; }
        [DisplayName("Głębokość Siewu [mm]")]
        public decimal DepthSowing { get; set; }

        [DisplayName("Rodzaj Siewu")]
        public int TypeSowingId { get; set; }       
        public List<SelectListItem> TypeSowing { get; set; }
        [DisplayName("Pole")]
        public int FieldId { get; set; }
        public List<SelectListItem> Field { get; set; }
        

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewSowingVm, Sowing>();
        }
    }
}