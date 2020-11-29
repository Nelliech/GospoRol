using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;
using GospoRol.Application.Interfaces.PlaceInterfaces;
using GospoRol.Application.Interfaces.ProductInterfaces;
using GospoRol.Application.ViewModels.ProductsViewsModels.FertilizerViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GospoRol.Web.Controllers.ProductControllers
{
   [Authorize]
    public class FertilizerController : Controller
    {
        private readonly IFertilizerService _fertilizerService;
        private readonly ITypeFertilizerService _typeFertilizerService;
        private readonly IWarehouseService _warehouseService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public FertilizerController(IFertilizerService fertilizerService,ITypeFertilizerService typeFertilizerService,
            IWarehouseService warehouseService, IHttpContextAccessor httpContextAccessor)
        {
            _fertilizerService = fertilizerService;
            _typeFertilizerService = typeFertilizerService;
            _warehouseService = warehouseService;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = _fertilizerService.GetAllFertilizerForList(userId);
            return View(model);
        }
        public IActionResult AddFertilizer()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var modelWarehouse = _warehouseService.GetAllWarehouseForList(userId).Warehouses;
            var warehouseSelectList =
                modelWarehouse.Select(f => new SelectListItem(f.Name, Convert.ToString(f.Id))).ToList();

            var modelTypeFertilizer = _typeFertilizerService.GetAllTypeFertilizerForList().TypeFertilizer;
            var typeFertilizerSelectList = modelTypeFertilizer
                .Select(f => new SelectListItem(f.Name, Convert.ToString(f.Id))).ToList().ToList();

            var model = new NewFertilizerVm()
            {
                TypeFertilizers = typeFertilizerSelectList,
                Warehouses = warehouseSelectList
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFertilizer(NewFertilizerVm model)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (ModelState.IsValid)
            {
                var id = _fertilizerService.AddFertilizer(model, userId);
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
