using System.Collections.Generic;

namespace GospoRol.Domain.Models.Products
{
    public class TypeProduct : BaseClass
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}