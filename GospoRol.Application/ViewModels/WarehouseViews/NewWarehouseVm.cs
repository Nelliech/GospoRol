using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using GospoRol.Application.Mapping;
using GospoRol.Domain.Models;

namespace GospoRol.Application.ViewModels.WarehouseViews
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