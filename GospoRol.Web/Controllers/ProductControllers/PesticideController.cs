using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;
using GospoRol.Application.Interfaces.PlaceInterfaces;
using GospoRol.Application.Interfaces.ProductInterfaces;
using GospoRol.Application.ViewModels.ProductsViewsModels.PesticideViewModels;
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
        private readonly ITypePesticideService _typePesticideService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string userId;
        public PesticideController(IPesticideService pesticideService,IWarehouseService warehouseService,ITypePesticideService typePesticideService,
            IHttpContextAccessor httpContextAccessor)
        {
            _pesticideService = pesticideService;
            _warehouseService = warehouseService;
            _typePesticideService = typePesticideService;
            _httpContextAccessor = httpContextAccessor;
            userId= _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public IActionResult Index()
        {
            
            var model = _pesticideService.GetAllPesticideForList(userId);
            return View(model);
        }

        public IActionResult AddPesticide()
        {
            var warehouseSelectList = _warehouseService.GetAllWarehouseForSelectList(userId);
            var typePesticideSelectList = _typePesticideService.GetAllTypePesticideForSelectList();

            var model = new NewPesticideVm()
            {
                TypePesticide = typePesticideSelectList,
                Warehouses = warehouseSelectList
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPesticide(NewPesticideVm model)
        {           
            if (ModelState.IsValid)
            {
                 _pesticideService.AddPesticide(model, userId);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult EditPesticide(int id)
        {
            var pesticide = _pesticideService.GetPesticideById(id);
            if (pesticide.UserId != userId)
            {
                return RedirectToAction("Index");
            }

            var warehouseSelectList = _warehouseService.GetAllWarehouseForSelectList(userId);
            var typePesticideSelectList = _typePesticideService.GetAllTypePesticideForSelectList();

            pesticide.Warehouses = warehouseSelectList;
            pesticide.TypePesticide = typePesticideSelectList;

            return View(pesticide);
        }
        [HttpPost]
        public IActionResult EditPesticide(NewPesticideVm model)
        {
            if (ModelState.IsValid)
            {
                _pesticideService.UpdatePesticide(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult DetailsPesticide(int id)
        {
            var pesticide = _pesticideService.GetPesticideById(id);
            if (pesticide.UserId != userId)
            {
                return RedirectToAction("Index");

            }

            return View(pesticide);
        }
        public IActionResult DeletePesticide(int id)
        {
            var pesticideUserId = _pesticideService.GetPesticideById(id).UserId;
            if (pesticideUserId != userId)
            {
                return RedirectToAction("Index");
            }
            _pesticideService.DeletePesticide(id);
            return RedirectToAction("Index");
        }
    }
}
