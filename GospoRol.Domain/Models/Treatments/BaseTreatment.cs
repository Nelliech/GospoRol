using System;
using GospoRol.Domain.Models.BaseClasses;

namespace GospoRol.Domain.Models.Treatments
{
    public abstract class BaseTreatment : BaseEntity
    {
        public DateTime DateTreatment { get; set; } //Data Nawożenia
        public string CultivatedPlant { get; set; }     //Uprawiana Roślina ?
        public string PlantVariety { get; set; } //Odmiana rośliny 
        public double Area { get; set; }                //Powierzchnia
    }
}