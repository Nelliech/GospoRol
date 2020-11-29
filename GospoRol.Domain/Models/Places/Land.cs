using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using GospoRol.Domain.Models.BaseClasses;

namespace GospoRol.Domain.Models.Places
{
    public class Land : BaseEntity //Grunt Rolny /działka 
    {// dodać działke na których będą pola
        public string PlotNumber { get; set; }          //Numer Działki
        public decimal Acreage { get; set; }                 //areał
        public decimal AcreageFree { get; set; }             //Wolny areał
        public decimal AcreageOccupied { get; set; }         //zajęty Areał
        public virtual ICollection<Field> Fields { get; set; }
    }
}
