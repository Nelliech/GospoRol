using System.Collections.Generic;

namespace GospoRol.Domain.Models.Treatments
{
    public class TypeSowing : BaseClass
    {
        public string Name { get; set; }
        public virtual ICollection<Sowing> Sowings { get; set; }
        
    }
}