using System.Collections.Generic;
using GospoRol.Domain.Models.BaseClasses;
using GospoRol.Domain.Models.Places;

namespace GospoRol.Domain.Models.Places
{
    public class AgriculturalClass : BaseClass
    {
        public string Class { get; set; }
        public string NameClass { get; set; }
        public virtual ICollection<Field> Fields { get; set; }

    }
}