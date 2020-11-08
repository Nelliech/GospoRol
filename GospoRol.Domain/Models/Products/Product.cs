using System.Collections.Generic;

namespace GospoRol.Domain.Models.Products
{
    
    public class Product : BaseEntity    //Produkty np. Nawozy, Nasiona, Pestycydy 
    {
        public int TypeProductId { get; set; }
        public virtual TypeProduct TypeProduct { get; set; }
        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public virtual ICollection<Seed> Seeds { get; set; }
        public virtual ICollection<Fertilizer> Fertilizers { get; set; }
        public virtual ICollection<Pesticide> Pesticides { get; set; }
    }
}