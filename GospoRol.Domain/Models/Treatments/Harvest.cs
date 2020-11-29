using System;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Domain.Models.Treatments
{
    public class Harvest : BaseTreatment
    {
        public decimal Efficiency { get; set; }          //Wydajność [t/ha]
        public bool IsPostHarvestResidue { get; set; } // Czy zebrano resztki pożniwne 
        public Yield Yield{ get; set; }
        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }

    }
}