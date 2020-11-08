using System.Collections.Generic;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Domain.Models
{
    public class Warehouse : BaseEntity
    {
        public string Name { get; set; }
        public double Acreage { get; set; }                 //areał // ładowność
        public double AcreageFree { get; set; }             //Wolny areał
        public double AcreageOccupied { get; set; }         //zajęty Areał
        public virtual ICollection<Product> Products { get; set; }
        //
        // maszyny + płody rolne +

    }
}