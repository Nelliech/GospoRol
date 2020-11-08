using System.Collections.Generic;
using GospoRol.Domain.Models.Treatments;

namespace GospoRol.Domain.Models.Products
{
    public class Seed : BaseEntity//Nasiono
    {
        public string NamePlant { get; set; }       //Nazwa rośliny-----
        public string PlantVariety { get; set; } //Odmiana rośliny 
        public string Producer { get; set; }
        public string SeedingRate { get; set; }
        //zdolnosc do kiełkowania, czy zaprawione(jaka zaprawa ? czy z ochrony roślin czy nie ) s jest ziarno, 
        //ilość kg lub ilość w worku 

        public virtual ICollection<Sowing> Sowings { get; set; }

    }
}