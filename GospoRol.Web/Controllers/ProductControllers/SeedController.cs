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
        public SeedController(ISeedService seedService,IWarehouseService warehouseService, IHttpContextAccessor httpContextAccessor)
        {
            _seedService = seedService;
            _warehouseService = warehouseService;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = _seedService.GetAllSeedForList(userId);
            return View(model);
        }

        public IActionResult AddSeed()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

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
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (ModelState.IsValid)
            {
                var id = _seedService.AddSeed(model, userId);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult DetailsSeed(int id)
        {
            var seed = _seedService.GetSeedById(id);
            return View(seed);
        }
    }
}
