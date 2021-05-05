using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GospoRol.Domain.Models.BaseClasses;
using GospoRol.Domain.Models.Places;
using GospoRol.Domain.Models.Treatments;

namespace GospoRol.Domain.Models.Products
{
    public class Yield : BaseEntity // plony rolne
    {
        public string NamePlant { get; set; }
        public string PlantVariety { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Count { get; set; }
        public YieldUnit YieldUnit { get; set; }
#nullable enable
        public int? HarvestRef { get; set; }
        public Harvest? Harvest { get; set; }
#nullable disable
        public int TypeProductId { get; set; }
        public virtual TypeProduct TypeProduct { get; set; }
        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }

    }

    public enum YieldUnit
    {
        [Display(Name = "Kg")]
        kg,
        [Display(Name = "T")]
        t,
        [Display(Name = "szt")]
        szt

    }
}