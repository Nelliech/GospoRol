using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Domain.Models.Products
{
    public class TypeFertilizer : BaseClass//Rodzaj nawozu 
    {
        public string Name { get; set; }
        public virtual ICollection<Fertilizer> Fertilizers { get; set; }
    }
}