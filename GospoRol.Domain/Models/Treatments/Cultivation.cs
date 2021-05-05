using System.Security;

namespace GospoRol.Domain.Models.Treatments
{
    public class Cultivation : BaseTreatment // zabiegii uprawowe // Orka bronowanie  
    {
        public int TypeCultivationId { get; set; }
        public TypeCultivation TypeCultivation { get; set; }
      
    }
}