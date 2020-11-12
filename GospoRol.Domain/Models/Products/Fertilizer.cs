using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GospoRol.Domain.Models.Treatments;

namespace GospoRol.Domain.Models.Products
{
    public class Fertilizer : BaseEntity    // Nawóz
    {
        public string Producer { get; set; }                //Producent
        public string FertilizerComposition { get; set; }   //Sklad nawozu (ilość) np MPk ważne ile procentówa
        public string Concentration { get; set; } // stężenie + objętność, ilość procentowo stężenie ?
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }         // cena
        public int TypeFertilizerId { get; set; }           //Jeden do wielu jeden typ nawozu może mieć wiele nawozów
        public TypeFertilizer TypeFertilizer { get; set; }  //Rodzaj nawozu
        public virtual ICollection<Fertilization> Fertilizations { get; set; }

    }
}