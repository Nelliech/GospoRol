using System.Collections.Generic;
using GospoRol.Domain.Models.BaseClasses;

namespace GospoRol.Domain.Models.Treatments
{
    public class TypeTreatment : BaseClass
    {
        public string Name { get; set; }
        public virtual ICollection<Treatment> Treatments { get; set; }
    }
}