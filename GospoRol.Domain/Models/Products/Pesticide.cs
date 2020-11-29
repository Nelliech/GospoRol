using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GospoRol.Domain.Models.BaseClasses;
using GospoRol.Domain.Models.Places;
using GospoRol.Domain.Models.Treatments;

namespace GospoRol.Domain.Models.Products
{
    public class Pesticide : BaseEntity
    {
        public string Producer { get; set; }
        public string Name { get; set; }
        public string PesticideComposition { get; set; }
        public decimal Capacity { get; set; }
        public decimal CurrentAmount { get; set; }
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }
        // nazwa, głowny skladnik, pojemnosc, cena, 
        public int TypeProductId { get; set; }
        public virtual TypeProduct TypeProduct { get; set; }
        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public int TypePesticideId { get; set; }   //Fungicyd,Chwastobójczy,Insektycyd,Moluskocyd,Regulator wzrostu, Atraktant,Rodentycyd,bakteriocyd
        public TypePesticide TypePesticide { get; set; }  //Dezynfektant, Stymulator Odporności,Repelent??,Środek mikrobiologiczny,Nematocyd
        public virtual ICollection<Spraying> Sprayings { get; set; }
    }
}