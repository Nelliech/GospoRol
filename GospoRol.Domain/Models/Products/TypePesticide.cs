using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GospoRol.Domain.Models.BaseClasses;

namespace GospoRol.Domain.Models.Products
{
    
    public class TypePesticide : BaseClass
    {
        public string Name { get; set; }
        public virtual ICollection<Pesticide> Pesticides{ get; set; }
    }
}