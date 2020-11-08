using System.Collections.Generic;
using GospoRol.Domain.Models.Treatments;

namespace GospoRol.Domain.Models.Products
{
    public class Pesticide : BaseEntity
    {
        public string Producer { get; set; }
        public string Name { get; set; }
        public string PesticideComposition { get; set; }
        public double Capacity { get; set; }
        public double Price { get; set; }
        // nazwa, głowny skladnik, pojemnosc, cena, 

        public int TypePesticideId { get; set; }   //Fungicyd,Chwastobójczy,Insektycyd,Moluskocyd,Regulator wzrostu, Atraktant,Rodentycyd,bakteriocyd
        public TypePesticide TypePesticide { get; set; }  //Dezynfektant, Stymulator Odporności,Repelent??,Środek mikrobiologiczny,Nematocyd
        public virtual ICollection<Spraying> Sprayings { get; set; }
    }
}