using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Claims;
using System.Threading.Tasks;
using GospoRol.Application.Interfaces.PlaceInterfaces;
using GospoRol.Application.Interfaces.ProductInterfaces;
using GospoRol.Application.ViewModels.ProductsViewsModels.SeedViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GospoRol.Web.Controllers.ProductControllers
{
    public class SeedController : Controller
    {
        private readonly ISeedService _seedService;
        private readonly IWarehouseService _warehouseService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string userId;
        public SeedController(ISeedService seedService,IWarehouseService warehouseService, IHttpContextAccessor httpContextAccessor)
        {
            _seedService = seedService;
            _warehouseService = warehouseService;
            _httpContextAccessor = httpContextAccessor;
            userId= _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public IActionResult Index()
        {
            
            var model = _seedService.GetAllSeedForList(userId);
            return View(model);
        }

        public IActionResult AddSeed()
        {
            

            var modelWarehouses = _warehouseService.GetAllWarehouseForList(userId).Warehouses;
            var warehouseSelectList =
                modelWarehouses.Select(f => new SelectListItem(f.Name, Convert.ToString(f.Id))).ToList();
            var viewModel = new NewSeedVm()
            {
                Warehouses = warehouseSelectList
            };
            
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult AddSeed(NewSeedVm model)
        {
            

            if (ModelState.IsValid)
            {
                _seedService.AddSeed(model, userId);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult EditSeed(int id)
        {
            var seed = _seedService.GetSeedById(id);
            if (seed.UserId != userId)
            {
                return RedirectToAction("Index");
            }

            var modelWarehouses = _warehouseService.GetAllWarehouseForList(userId).Warehouses;
            var warehouseSelectList =
                modelWarehouses.Select(f => new SelectListItem(f.Name, Convert.ToString(f.Id))).ToList();

            seed.Warehouses = warehouseSelectList;

            return View(seed);
        }
        [HttpPost]
        public IActionResult EditSeed(NewSeedVm model)
        {
            if (ModelState.IsValid)
            {
                _seedService.UpdateSeed(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult DetailsSeed(int id)
        {
            var seed = _seedService.GetSeedById(id);
            if (seed.UserId != userId)
            {
                return RedirectToAction("Index");

            }
            return View(seed);
        }
        public IActionResult DeleteSeed(int id)
        {
            var seedUserId = _seedService.GetSeedById(id).UserId;
            if (seedUserId != userId)
            {
                return RedirectToAction("Index");

            }
            _seedService.DeleteSeed(id);
            return RedirectToAction("Index");
        }
    }
}
