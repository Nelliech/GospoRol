using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GospoRol.Domain.Models.Treatments
{
    public class Sowing : BaseTreatment                           //Siew
    {
        [Column(TypeName = "decimal(18,4)")]
        public decimal WidthBetweenRows { get; set; }//szerokość rzedow 
        public int NumberRows { get; set; }//ilość rzędów 

        [Column(TypeName = "decimal(18,4)")]
        public decimal HowManyHa { get; set; }       //Ile na ha(sztuk/mk2, kg/ha, ) ----
        public SowingUnit SowingUnit { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal DepthSowing { get; set; } //głębokość siewu [ mm ]
        public int TypeSowingId { get; set; }       //Metody siewu (Siew gniazdowy,Siew punktowy,Siew rzędowy,Siew rzutowy)
        public virtual TypeSowing TypeSowing { get; set; }
        
        
    }

    public enum SowingUnit
    {
        [Display(Name = "szt/ha")]
        SztHa,
        [Display(Name = "kg/ha")]
        KgHa,
    }
}