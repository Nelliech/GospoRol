using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GospoRol.Application.Interfaces.PlaceInterfaces;
using GospoRol.Application.Interfaces.ProductInterfaces;
using GospoRol.Application.ViewModels.ProductsViewsModels.YieldViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GospoRol.Web.Controllers.ProductControllers
{
    public class YieldController : Controller
    {
        private readonly IYieldService _yieldService;
        private readonly IWarehouseService _warehouseService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string userId;
        public YieldController(IYieldService yieldService, IWarehouseService warehouseService, IHttpContextAccessor httpContextAccessor)
        {
            _yieldService = yieldService;
            _warehouseService = warehouseService;
            _httpContextAccessor = httpContextAccessor;
            userId= _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public IActionResult Index()
        {
           
            var model = _yieldService.GetAllYieldForList(userId);
            return View(model);
        }

        public IActionResult AddYield()
        {

            var modelWarehouses = _warehouseService.GetAllWarehouseForList(userId).Warehouses;
            var warehouseSelectList =
                modelWarehouses.Select(f => new SelectListItem(f.Name, Convert.ToString(f.Id))).ToList();
            var model = new NewYieldVm()
            {
                Warehouses = warehouseSelectList
            };
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult AddYield(NewYieldVm model)
        {
           

            if (ModelState.IsValid)
            {
                _yieldService.AddYield(model, userId);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult EditYield(int id)
        {
            var yield = _yieldService.GetYieldById(id);
            if (yield.UserId != userId)
            {
                return RedirectToAction("Index");

            }
            var modelWarehouses = _warehouseService.GetAllWarehouseForList(userId).Warehouses;
            var warehouseSelectList =
                modelWarehouses.Select(f => new SelectListItem(f.Name, Convert.ToString(f.Id))).ToList();

            yield.Warehouses = warehouseSelectList;

            return View(yield);
        }
        [HttpPost]
        public IActionResult EditSeed(NewYieldVm model)
        {
            if (ModelState.IsValid)
            {
                _yieldService.UpdateYield(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult DeleteYield(int yieldId)
        {
            var yield = _yieldService.GetYieldById(yieldId);
            if (yield.UserId != userId)
            {
                return RedirectToAction("Index");
            }
            _yieldService.DeleteYield(yieldId);
            return RedirectToAction("Index");
        }
    }
}
