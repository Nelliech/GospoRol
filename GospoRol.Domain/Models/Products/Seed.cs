using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GospoRol.Domain.Models.BaseClasses;
using GospoRol.Domain.Models.Places;
using GospoRol.Domain.Models.Treatments;

namespace GospoRol.Domain.Models.Products
{
    public class Seed : BaseEntity//Nasiono
    {
        public string NamePlant { get; set; }       //Nazwa rośliny-----
        public string PlantVariety { get; set; } //Odmiana rośliny 
        public string Producer { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Capacity { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal CurrentAmount { get; set; }
        public SeedUnit SeedUnit { get; set; }
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }
        public string AdditionalInformation { get; set; }
        public int TypeProductId { get; set; }
        public virtual TypeProduct TypeProduct { get; set; }
        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        
        public virtual ICollection<Sowing> Sowings { get; set; }

    }

    public enum SeedUnit
    {
        [Display(Name = "Kg")]
        kg,
        [Display(Name = "T")]
        t,
        [Display(Name = "szt")]
        szt

    }
}