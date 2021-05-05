using System;
using System.Reflection.Metadata;

namespace GospoRol.Domain.Models.Treatments
{
    public class MechanicalWeedControl : BaseTreatment // Mechaniczne Odchwaszczanie  
    {
        public int NumberInterRows { get; set; }
        public string Reason { get; set; }              //Powód zastosowania  
        
    }
}