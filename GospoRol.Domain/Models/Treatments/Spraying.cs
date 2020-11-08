using System;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Domain.Models.Treatments
{
    public class Spraying : BaseTreatment // ochrony roślin    // nazwa ??
    {
        public string NameProduct { get; set; }         //Nazwa substancij --
        public double Dose { get; set; }                //Dawka----b
        public string Unit { get; set; }                //Jednostka (L/ha, kg/ha, %)-----
        public string Reason { get; set; }              //Powód zastosowania  
        
        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }
        public int PesticideId { get; set; }
        public Pesticide Pesticide { get; set; }   
    }
}