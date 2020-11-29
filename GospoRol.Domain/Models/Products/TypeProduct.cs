using System.Collections.Generic;
using GospoRol.Domain.Models.BaseClasses;

namespace GospoRol.Domain.Models.Products
{
    public class TypeProduct : BaseClass
    {
        public string Name { get; set; }
        public virtual ICollection<Seed> Seeds { get; set; }
        public virtual ICollection<Fertilizer> Fertilizers { get; set; }
        public virtual ICollection<Pesticide> Pesticides { get; set; }
    }
}