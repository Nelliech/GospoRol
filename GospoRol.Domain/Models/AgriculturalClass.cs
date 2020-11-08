using System.Collections.Generic;

namespace GospoRol.Domain.Models
{
    public class AgriculturalClass : BaseClass
    {
        public string Class { get; set; }
        public string NameClass { get; set; }
        public virtual ICollection<Field> Fields { get; set; }

    }
}