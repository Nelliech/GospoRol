using System;
using System.Collections.Generic;
using System.Text;
using GospoRol.Domain.Models.Treatments;

namespace GospoRol.Domain.Models
{
    public class Field : BaseEntity//Pole
    {
        public string FieldName { get; set; }
        public decimal Acreage { get; set; }             //Areał
        public string CultivatedPlant { get; set; }     //Uprawiana Roślina
        public string Variety { get; set; }             //Odmiana? 
        public decimal DistanceToWarehouse { get; set; } //Odległość od magazynu
        public int AgriculturalClassId { get; set; }
        public AgriculturalClass AgriculturalClass { get; set; }
        public int LandId { get; set; }
        public virtual Land Land { get; set; }

        public virtual ICollection<Treatment> Treatments { get; set; }

    }
}
