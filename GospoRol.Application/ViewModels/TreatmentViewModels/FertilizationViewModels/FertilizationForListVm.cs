using AutoMapper;
using GospoRol.Application.Mapping;
using GospoRol.Domain.Models.Treatments;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace GospoRol.Application.ViewModels.TreatmentViewModels.FertilizationViewModels
{
    public class FertilizationForListVm : IMapFrom<Fertilization>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [DisplayName("Data Zabiegu")]
        public DateTime DateTreatment { get; set; }
        [DisplayName("Uprawiana Roślina")]
        public string CultivatedPlant { get; set; }
        [DisplayName("Odmiana Rośliny")]
        public string PlantVariety { get; set; }
        [DisplayName("Areał")]
        public decimal Area { get; set; }
        [DisplayName("Dodatkowe Informacje")]
        public string AdditionalInformation { get; set; }
        [DisplayName("Ile jednostek")]
        public decimal HowManyHa { get; set; }
        [DisplayName("Jednostka")]
        public FertilizationUnit FertilizationUnit { get; set; }
        [DisplayName("Pole")]
        public int FieldId { get; set; }
        public List<SelectListItem> Fields { get; set; }
        [DisplayName("Rodzaj Nawozu")]
        public int TypeTreatmentId { get; set; }
        public List<SelectListItem> TypeTreatment { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Fertilization, FertilizationForListVm>();
        }
    }
}
