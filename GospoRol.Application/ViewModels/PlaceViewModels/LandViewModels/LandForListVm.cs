using System.Collections.Generic;
using System.ComponentModel;
using AutoMapper;
using GospoRol.Application.Mapping;
using GospoRol.Domain.Models.Places;

namespace GospoRol.Application.ViewModels.PlaceViewModels.LandViewModels
{
    public class LandForListVm : IMapFrom<Land>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [DisplayName("Numer Działki")]
        public string PlotNumber { get; set; }          //Numer Działki
        [DisplayName("Areał")]
        public decimal Acreage { get; set; }                 //areał
        [DisplayName("Wolny Areał")]
        public decimal AcreageFree { get; set; }             //Wolny areał
        [DisplayName("Zajęty Areał")]
        public decimal AcreageOccupied { get; set; }         //zajęty Areał
        [DisplayName("Ilość Pol")]
        public List<Field> Fields { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Land, LandForListVm>();
        }
    }
}