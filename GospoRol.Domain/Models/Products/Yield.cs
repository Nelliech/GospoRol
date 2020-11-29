using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using GospoRol.Domain.Models.BaseClasses;
using GospoRol.Domain.Models.Places;
using GospoRol.Domain.Models.Treatments;

namespace GospoRol.Domain.Models.Products
{
    public class Yield : BaseEntity // plony rolne
    {
        public string NamePlant { get; set; }
        public string PlantVariety { get; set; }
        public decimal Count { get; set; }
        public Unit Unit { get; set; }
        public int HarvestRef { get; set; }
        public Harvest Harvest { get; set; }
        public int TypeProductId { get; set; }
        public virtual TypeProduct TypeProduct { get; set; }
        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }

    }

    public enum Unit
    {
        [Display(Name = "kg/ha")]
        kgha,
        [Display(Name = "t/ha")]
        tha,
        [Display(Name = "szt/ha")]
        sztha

    }
}