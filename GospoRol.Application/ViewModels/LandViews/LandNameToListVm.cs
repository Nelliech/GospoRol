using System.ComponentModel;
using AutoMapper;
using GospoRol.Application.Mapping;
using GospoRol.Domain.Models;

namespace GospoRol.Application.ViewModels
{
    public class LandNameToListVm : IMapFrom<Land>
    {
        public int Id { get; set; }
        public string PlotNumber { get; set; }          //Numer Działki
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Land, LandNameToListVm>();
        }
    }
}