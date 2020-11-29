using System.Collections.Generic;
using GospoRol.Domain.Models.BaseClasses;

namespace GospoRol.Domain.Models.Treatments
{
    public class TypeSowing : BaseClass
    {
        public string Name { get; set; }
        public virtual ICollection<Sowing> Sowings { get; set; }
        
    }
}