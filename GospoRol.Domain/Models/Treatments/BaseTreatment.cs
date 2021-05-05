using System;
using System.ComponentModel.DataAnnotations.Schema;
using GospoRol.Domain.Models.BaseClasses;
using GospoRol.Domain.Models.Places;

namespace GospoRol.Domain.Models.Treatments
{
    public abstract class BaseTreatment : BaseEntity
    {
        public DateTime DateTreatment { get; set; } //Data Zabiagu
        public string CultivatedPlant { get; set; }     //Uprawiana Roślina ?
        public string PlantVariety { get; set; } //Odmiana rośliny 

        [Column(TypeName = "decimal(18,4)")]
        public decimal Area { get; set; }                //Powierzchnia
        public string AdditionalInformation { get; set; }
        public int FieldId { get; set; }
        public virtual Field Field { get; set; }
        public int TypeTreatmentId { get; set; }
        public TypeTreatment TypeTreatment { get; set; }
    }
}