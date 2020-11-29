using System.ComponentModel;
using AutoMapper;
using GospoRol.Application.Mapping;
using GospoRol.Domain.Models.Places;

namespace GospoRol.Application.ViewModels.PlaceViewModels.WarehouseViewModels
{
    public class NewWarehouseVm : IMapFrom<Warehouse>
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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewWarehouseVm, Warehouse>().ReverseMap();
        }
    }
}