using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Domain.Models.Treatments
{
    public class Harvest : BaseTreatment
    {
        [Column(TypeName = "decimal(18,4)")]
        public decimal Efficiency { get; set; }          //Wydajność [t/ha]
        public bool IsPostHarvestResidue { get; set; } // Czy zebrano resztki pożniwne 
        public Yield Yield{ get; set; }
        
    }
    public enum HarvestUnit
    {
        [Display(Name = "szt/ha")]
        SztHa,
        [Display(Name = "kg/ha")]
        KgHa,
        [Display(Name = "t/ha")]
        Tha

    }
}