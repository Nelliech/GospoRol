
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Domain.Models.Treatments
{
    public class Spraying : BaseTreatment // ochrony roślin    // nazwa ??
    {
        public string NameProduct { get; set; }         //Nazwa substancij --

        [Column(TypeName = "decimal(18,4)")]
        public decimal Dose { get; set; }                //Dawka----b
        public SprayingUnit SprayingUnit { get; set; }                //Jednostka (L/ha, kg/ha, %)-----
        public string Reason { get; set; }              //Powód zastosowania  
        public int PesticideId { get; set; }
        public Pesticide Pesticide { get; set; }   
    }

    public enum SprayingUnit
    {
        [Display(Name = "l/ha")]
        LHa,
        [Display(Name = "kg/ha")]
        KgHa,
        [Display(Name = "&")]
        Perc,
    }
}