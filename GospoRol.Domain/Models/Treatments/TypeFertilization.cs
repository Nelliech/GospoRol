using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GospoRol.Domain.Models.Treatments
{
    public enum NameFertilization 
    {
        [Display(Name = "Nawożenie Przedsiewne")]
        NawozeniePrzedsiewne,
        [Display(Name = "Nawożenie Siewne")]
        NawozenieSiewne,
        [Display(Name = "Nawożenie Pogłówne")]
        NawozeniePoglowne,
        [Display(Name = "Nawożenie Dolistne")]
        NawozenieDolistne
    }
    public class TypeFertilization : BaseClass//Rodzaj nawożenia
    {
        public string Name { get; set; }
        public virtual ICollection<Fertilization> Fertilizations { get; set; }
    }
}
