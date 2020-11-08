using System;
using System.Collections.Generic;
using System.Text;

namespace GospoRol.Domain.Models.Treatments
{
    public class Treatment : BaseClass //Zabieg
    {
        public int TypeTreatmentId { get; set; }
        public virtual TypeTreatment TypeTreatment { get; set; }
        public virtual Field Field { get; set; }
        public virtual ICollection<Spraying> Sprayings { get; set; }
        public virtual ICollection<Sowing> Sowings { get; set; }
        public virtual ICollection<Fertilization> Fertilizations { get; set; }
        public virtual ICollection<Harvest> Harvests { get; set; }
        public virtual ICollection<MechanicalWeedControl> MechanicalWeedControls { get; set; }
        public virtual ICollection<Cultivation> Cultivatings { get; set; }
    }
}
