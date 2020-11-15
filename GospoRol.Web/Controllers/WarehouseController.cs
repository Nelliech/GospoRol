using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GospoRol.Application.Interfaces;
using GospoRol.Application.ViewModels.WarehouseViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GospoRol.Web.Controllers
{
    [Authorize]
    public class WarehouseController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWarehouseService _warehouseService;
        public WarehouseController(IWarehouseService warehouseService, IHttpContextAccessor httpContextAccessor)
        {
            _warehouseService = warehouseService;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = _warehouseService.GetAllWarehouseForList(userId);
            return View(model);
        }

        public IActionResult AddWarehouse()
        {
            return View(new NewWarehouseVm());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddWarehouse(NewWarehouseVm model)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (ModelState.IsValid)
            {
                var id = _warehouseService.AddWarehouse(model, userId);
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
