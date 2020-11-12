using System.Collections.Generic;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Domain.Models
{
    public class Warehouse : BaseEntity
    {
        public string Name { get; set; }
        public decimal Acreage { get; set; }                 //areał // ładowność
        public decimal AcreageFree { get; set; }             //Wolny areał
        public decimal AcreageOccupied { get; set; }         //zajęty Areał
        public virtual ICollection<Product> Products { get; set; }
        //
        // maszyny + płody rolne +

    }
}