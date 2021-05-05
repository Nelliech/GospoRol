using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GospoRol.Domain.Models.BaseClasses;
using GospoRol.Domain.Models.Treatments;

namespace GospoRol.Domain.Models.Places
{
    public class Field : BaseEntity//Pole
    {
        public string FieldName { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Acreage { get; set; }             //Areał
        public string CultivatedPlant { get; set; }     //Uprawiana Roślina
        public string Variety { get; set; }             //Odmiana?       
        public int AgriculturalClassId { get; set; }
        public AgriculturalClass AgriculturalClass { get; set; }
        public int LandId { get; set; }
        public virtual Land Land { get; set; }
        public virtual ICollection<Sowing> Sowings { get; set; }
    }
}
