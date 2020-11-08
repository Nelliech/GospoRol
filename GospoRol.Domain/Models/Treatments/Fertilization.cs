using System;
using System.Xml.Schema;
using GospoRol.Domain.Models.Products;
using GospoRol.Domain.Models.Treatments;

namespace GospoRol.Domain.Models.Treatments
{
    public class Fertilization : BaseTreatment                         //Nawożenie
    {
        public double HowManyHa { get; set; }       //Ile na 'ha'(jednostka kg/ha, t/ha)
        public int FertilizerId { get; set; }
        public Fertilizer Fertilizer { get; set; }
        public int TypeFertilizationId { get; set; }    //rodzaj nawożenia zależne od daty do sprawdzenia 
        public virtual TypeFertilization TypeFertilization { get; set; }
        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }
        

    }
}