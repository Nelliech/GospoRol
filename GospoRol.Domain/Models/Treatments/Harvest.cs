using System;

namespace GospoRol.Domain.Models.Treatments
{
    public class Harvest : BaseTreatment
    {
        public decimal Efficiency { get; set; }          //Wydajność [t/ha]
        public bool IsPostHarvestResidue { get; set; } // Czy zebrano resztki pożniwne 
        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }

    }
}