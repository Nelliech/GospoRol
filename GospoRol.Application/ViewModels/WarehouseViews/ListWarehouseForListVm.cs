using System.Collections.Generic;
using GospoRol.Domain.Models;

namespace GospoRol.Application.ViewModels.WarehouseViews
{
    public class ListWarehouseForListVm
    {
        public List<WarehouseForListVm> Warehouses { get; set; }
        public int Count { get; set; }

    }
}