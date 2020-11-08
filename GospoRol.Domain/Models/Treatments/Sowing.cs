using System;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Domain.Models.Treatments
{
    public class Sowing : BaseTreatment                           //Siew
    {
        public double WidthBetweenRows { get; set; }//szerokość rzedow 
        public int NumberRows { get; set; }//ilość rzędów 
        public double HowManyHa { get; set; }       //Ile na ha(sztuk/mk2, kg/ha, ) ----
        public double DepthSowing { get; set; }
        public int SeedId { get; set; }
        public virtual Seed Seed { get; set; }
        public int TypeSowingId { get; set; }       //Metody siewu (Siew gniazdowy,Siew punktowy,Siew rzędowy,Siew rzutowy)
        public virtual TypeSowing TypeSowing { get; set; }
        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }
        

    }
}