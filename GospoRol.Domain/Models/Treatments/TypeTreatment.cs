using System.Collections.Generic;

namespace GospoRol.Domain.Models.Treatments
{
    public class TypeTreatment : BaseClass
    {
        public string Name { get; set; }
        public virtual ICollection<Treatment> Treatments { get; set; }
    }
}