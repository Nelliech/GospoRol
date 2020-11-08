using System;
using System.Collections.Generic;
using System.Text;

namespace GospoRol.Domain.Models
{
    public class Land : BaseEntity //Grunt Rolny /działka 
    {// dodać działke na których będą pola
        public string PlotNumber { get; set; }          //Numer Działki
        public double Acreage { get; set; }                 //areał
        public double AcreageFree { get; set; }             //Wolny areał
        public double AcreageOccupied { get; set; }         //zajęty Areał
        public virtual ICollection<Field> Fields { get; set; }
    }
}
