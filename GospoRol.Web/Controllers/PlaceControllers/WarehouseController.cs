using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GospoRol.Application.Interfaces;
using GospoRol.Application.Interfaces.PlaceInterfaces;
using GospoRol.Application.ViewModels.PlaceViewModels.WarehouseViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

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

        public IActionResult EditWarehouse(int id)
        {
            var warehouse = _warehouseService.GetWarehouseById(id);
            return View(warehouse);
        }
        [HttpPost]
        public IActionResult EditWarehouse(NewWarehouseVm model)
        {
            if (ModelState.IsValid)
            {
                _warehouseService.UpdateWarehouse(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult DeleteWarehouse(int id) 
        {
            var warehouse = _warehouseService.GetWarehouseAndCountProductsById(id);
            return View(warehouse);
        }

        public IActionResult DeleteWarehouseContinue(int id)
        {
            _warehouseService.DeleteWarehouse(id);
            return RedirectToAction("Index");

        }

        public IActionResult DetailsWarehouse(int id)
        {
            var warehouse = _warehouseService.GetWarehouseById(id);
            return View(warehouse);
        }
    }
}
