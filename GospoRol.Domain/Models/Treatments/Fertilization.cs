using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Schema;
using GospoRol.Domain.Models.Products;
using GospoRol.Domain.Models.Treatments;

namespace GospoRol.Domain.Models.Treatments
{
    public class Fertilization : BaseTreatment                         //Nawożenie
    {
        [Column(TypeName = "decimal(18,4)")]
        public decimal HowManyHa { get; set; }       //Ile na 'ha'(jednostka kg/ha, t/ha)
        public FertilizationUnit FertilizationUnit { get; set; }
        public int FertilizerId { get; set; }
        public Fertilizer Fertilizer { get; set; }
        public int TypeFertilizationId { get; set; }    //rodzaj nawożenia zależne od daty do sprawdzenia 
        public virtual TypeFertilization TypeFertilization { get; set; }
        
    }

    public enum FertilizationUnit
    {
        [Display(Name = "kg/ha")]
        KgHa,
        [Display(Name = "t/ha")]
        THa,

    }
}