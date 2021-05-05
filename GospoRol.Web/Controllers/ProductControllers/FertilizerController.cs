using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using GospoRol.Application.Interfaces.PlaceInterfaces;
using GospoRol.Application.Interfaces.ProductInterfaces;
using GospoRol.Application.ViewModels.ProductsViewsModels.FertilizerViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace GospoRol.Web.Controllers.ProductControllers
{
   [Authorize]
    public class FertilizerController : Controller
    {
        private readonly IFertilizerService _fertilizerService;
        private readonly ITypeFertilizerService _typeFertilizerService;
        private readonly IWarehouseService _warehouseService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string userId;
        public FertilizerController(IFertilizerService fertilizerService,ITypeFertilizerService typeFertilizerService,
            IWarehouseService warehouseService, IHttpContextAccessor httpContextAccessor)
        {
            _fertilizerService = fertilizerService;
            _typeFertilizerService = typeFertilizerService;
            _warehouseService = warehouseService;
            _httpContextAccessor = httpContextAccessor;
            userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public IActionResult Index()
        {
            
            var model = _fertilizerService.GetAllFertilizerForList(userId);
            return View(model);
        }
        public IActionResult AddFertilizer()
        {
            var warehouseSelectList = _warehouseService.GetAllWarehouseForSelectList(userId);
            var typeFertilizerSelectList = _typeFertilizerService.GetAllTypeFertilizerFoSelectList();

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
            
            if (ModelState.IsValid)
            {
                _fertilizerService.AddFertilizer(model, userId);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult EditFertilizer(int id)
        {
            var fertilizer = _fertilizerService.GetFertilizerById(id);
            if (fertilizer.UserId != userId)
            {
                return RedirectToAction("Index");

            }

            var warehouseSelectList = _warehouseService.GetAllWarehouseForSelectList(userId);
            var typeFertilizerSelectList = _typeFertilizerService.GetAllTypeFertilizerFoSelectList();

            fertilizer.Warehouses = warehouseSelectList;
            fertilizer.TypeFertilizers = typeFertilizerSelectList;

            return View(fertilizer);
        }
        [HttpPost]
        public IActionResult EditSeed(NewFertilizerVm model)
        {
            if (ModelState.IsValid)
            {
                _fertilizerService.UpdateFertilizer(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult DeleteFertilizer(int id)
        {
            var fertilizerUserId = _fertilizerService.GetFertilizerById(id).UserId;
            if (fertilizerUserId != userId)
            {
                return RedirectToAction("Index");

            }
            _fertilizerService.DeleteFertilizer(id);
            return RedirectToAction("Index");
        }

        public IActionResult DetailsFertilizer(int id)
        {
            var fertilizer = _fertilizerService.GetFertilizerById(id);
            if (fertilizer.UserId != userId)
            {
                return RedirectToAction("Index");
            }
            return View(fertilizer);
        }
    }
}
