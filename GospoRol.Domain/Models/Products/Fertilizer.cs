using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GospoRol.Domain.Models.BaseClasses;
using GospoRol.Domain.Models.Places;
using GospoRol.Domain.Models.Treatments;

namespace GospoRol.Domain.Models.Products
{                                                               /// enum w viewmodel czy  w modelu ??
    public class Fertilizer : BaseEntity    // Nawóz
    {
        public string Producer { get; set; }                //Producent
        public string FertilizerComposition { get; set; }   //Sklad nawozu (ilość) np MPk ważne ile procentówa

        [Column(TypeName = "decimal(18,4)")]
        public decimal Concentration { get; set; } // stężenie + objętność, ilość procentowo stężenie ?

        [Column(TypeName = "decimal(18,4)")]
        public decimal Capacity { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal CurrentAmount { get; set; }
        public FertilizerUnit FertilizerUnit { get; set; }

        [Column(TypeName = "Money")]
        public decimal Price { get; set; }         // cena
        public string AdditionalInformation { get; set; }
        public int TypeProductId { get; set; }
        public virtual TypeProduct TypeProduct { get; set; }
        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public int TypeFertilizerId { get; set; }           //Jeden do wielu jeden typ nawozu może mieć wiele nawozów
        public TypeFertilizer TypeFertilizer { get; set; }  //Rodzaj nawozu
        public virtual ICollection<Fertilization> Fertilizations { get; set; }

    }
    public enum FertilizerUnit
    {
        [Display(Name = "Kg")]
        kg,
        [Display(Name = "mg")]
        mg,
        [Display(Name = "L")]
        l

    }

}