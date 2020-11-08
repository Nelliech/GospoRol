using System.Collections.Generic;
using GospoRol.Domain.Models;

namespace GospoRol.Application.ViewModels
{
    public class ListLandForListVm
    {
        public List<LandForListVm> Lands { get; set; }
        public int Count { get; set; }

    }
}