using System.Collections.Generic;

namespace GospoRol.Domain.Models.Treatments
{
    public class TypeCultivation : BaseClass
    {
        public string Name { get; set; }
        public virtual ICollection<Cultivation> Cultivations { get; set; }
    }
}