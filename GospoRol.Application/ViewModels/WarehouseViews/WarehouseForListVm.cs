using System.Collections.Generic;
using System.ComponentModel;
using AutoMapper;
using GospoRol.Application.Mapping;
using GospoRol.Domain.Models;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Application.ViewModels.WarehouseViews
{
    public class WarehouseForListVm : IMapFrom<Warehouse>
    {
        public int Id { get; set; }
        [DisplayName("Nazwa Magazynu")]
        public string Name { get; set; }
        [DisplayName("Areał")]
        public decimal Acreage { get; set; }
        //[DisplayName("Wolny Areał")]
        //public decimal AcreageFree { get; set; }
        //[DisplayName("Zajęty Areał")]
        //public decimal AcreageOccupied { get; set; }
        [DisplayName("Ilość Produktów")]
        public List<Product> Products { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Warehouse, WarehouseForListVm>();

        }
    }
}