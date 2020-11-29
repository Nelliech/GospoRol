using System.Collections.Generic;
using System.ComponentModel;
using AutoMapper;
using GospoRol.Application.Mapping;
using GospoRol.Domain.Models.Places;
using GospoRol.Domain.Models.Products;

namespace GospoRol.Application.ViewModels.PlaceViewModels.WarehouseViewModels
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
        public List<Seed> Seeds { get; set; }
        public List<Pesticide> Pesticides { get; set; }
        public List<Fertilizer> Fertilizers { get; set; }
        public List<Yield> Yields { get; set; }
        [DisplayName("Ilość Produktów")]
        public int CountProducts { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Warehouse, WarehouseForListVm>();

        }
    }
}