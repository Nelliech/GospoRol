using System.ComponentModel;
using AutoMapper;
using FluentValidation;
using GospoRol.Application.Mapping;
using GospoRol.Domain.Models;

namespace GospoRol.Application.ViewModels
{
    public class NewLandVm : IMapFrom<Land>
    {
        public int Id { get; set; }
        [DisplayName("Numer Działki")]
        public string PlotNumber { get; set; }          //Numer Działki
        [DisplayName("Areał")]
        public double Acreage { get; set; }                 //areał
        [DisplayName("Wolny Areał")]
        public double AcreageFree { get; set; }             //Wolny areał
        [DisplayName("Zajęty Areał")]
        public double AcreageOccupied { get; set; }         //zajęty Areał
        public string UserId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewLandVm, Land>().ReverseMap();
        }
    }
    public class NewLandValidation : AbstractValidator<NewLandVm>
    {
        public NewLandValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Acreage).NotNull();
        }
    }
}