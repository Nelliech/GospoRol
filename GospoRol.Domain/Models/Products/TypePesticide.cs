using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GospoRol.Domain.Models.Products
{
    public enum NamePesticide
    {
        Algicyd,
        Bakteriocyd,
        Fungicyd,
        Herbicyd,
        [Display(Name = "Regulator wzrostu roślin")]
        RegulatorWzrostuRoślin,
        [Display(Name = "Regulator wzrostu owadów")]
        RegulatorWzrostuOwadow,
        Zoocyd,
        Synergetyk,
        Wirocyd
    }
    public class TypePesticide : BaseClass
    {
        public string Name { get; set; }
        public virtual ICollection<Pesticide> Pesticides{ get; set; }
    }
}