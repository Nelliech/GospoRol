using System.Collections.Generic;
using GospoRol.Domain.Models.BaseClasses;

namespace GospoRol.Domain.Models.Treatments
{
    public class TypeTreatment : BaseClass
    {
        public string Name { get; set; }
        public virtual ICollection<Spraying> Sprayings { get; set; }
        public virtual ICollection<Sowing> Sowings { get; set; }
        public virtual ICollection<Fertilization> Fertilizations { get; set; }
        public virtual ICollection<Harvest> Harvests { get; set; }
        public virtual ICollection<MechanicalWeedControl> MechanicalWeedControls { get; set; }
        public virtual ICollection<Cultivation> Cultivatings { get; set; }
    }
}