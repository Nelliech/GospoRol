using System.Collections.Generic;
using GospoRol.Domain.Models.BaseClasses;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Domain.Models.Places
{
    public class Warehouse : BaseEntity
    {
        public string Name { get; set; }
        public decimal Acreage { get; set; }                 //areał // ładowność
        //public decimal AcreageFree { get; set; }             //Wolny areał
        //public decimal AcreageOccupied { get; set; }         //zajęty Areał
        public virtual ICollection<Seed> Seeds { get; set; }
        public virtual ICollection<Fertilizer> Fertilizers { get; set; }
        public virtual ICollection<Pesticide> Pesticides { get; set; }
        public virtual ICollection<Yield> Yields { get; set; }


        //
        // maszyny + płody rolne +

    }
}