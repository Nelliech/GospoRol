using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;
using GospoRol.Application.Interfaces.PlaceInterfaces;
using GospoRol.Application.Interfaces.ProductInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GospoRol.Web.Controllers.ProductControllers
{
    [Authorize]
    public class PesticideController : Controller
    {
        private readonly IPesticideService _pesticideService;
        private readonly IWarehouseService _warehouseService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PesticideController(IPesticideService pesticideService, IHttpContextAccessor httpContextAccessor,IWarehouseService warehouseService)
        {
            _pesticideService = pesticideService;
            _warehouseService = warehouseService;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = _pesticideService.GetAllPesticideForList(userId);
            return View(model);
        }

        public IActionResult AddPesticide()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var modelWarehouse = _warehouseService.GetAllWarehouseForList(userId).Warehouses;
            var warehouseSelectList =
                modelWarehouse.Select(f => new SelectListItem(f.Name, Convert.ToString(f.Id))).ToList();
        }
    }
}
