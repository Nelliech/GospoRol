using System;
using System.Collections.Generic;
using AutoMapper;
using GospoRol.Application.Mapping;
using GospoRol.Domain.Models.Treatments;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GospoRol.Application.ViewModels.TreatmentViewModels.SowingViewModels
{
    public class SowingForListVm : IMapFrom<Sowing>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime DateTreatment { get; set; }
        public string CultivatedPlant { get; set; }
        public string PlantVariety { get; set; }
        public decimal Area { get; set; }
        public string AdditionalInformation { get; set; }
        public double WidthBetweenRows { get; set; }
        public int NumberRows { get; set; }
        public decimal HowManyHa { get; set; }
        public SowingUnit SowingUnit { get; set; }
        public decimal DepthSowing { get; set; }
        public int SeedId { get; set; }
        public List<SelectListItem> Seed { get; set; }
        public int TypeSowingId { get; set; }
        public List<SelectListItem> TypeSowing { get; set; }
        public int FieldId { get; set; }
        public List<SelectListItem> Field { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Sowing, SowingForListVm>();
        }
    }
}