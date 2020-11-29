using System.Collections.Generic;
using GospoRol.Domain.Models.BaseClasses;

namespace GospoRol.Domain.Models.Treatments
{
    public class TypeCultivation : BaseClass
    {
        public string Name { get; set; }
        public virtual ICollection<Cultivation> Cultivations { get; set; }
    }
}