using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GospoRol.Application.Interfaces;
using GospoRol.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GospoRol.Web.Controllers
{
    [Authorize]
    public class LandController : Controller
    {
        private readonly ILandService _landService;
        private readonly IFieldService _fieldService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LandController(ILandService landService,IFieldService fieldService, IHttpContextAccessor httpContextAccessor)
        {
            _landService = landService;
            _fieldService = fieldService;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = _landService.GetAllLandForList(userId);
            return View(model);
        }
        
        public IActionResult AddLand()
        {
            return View(new NewLandVm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddLand(NewLandVm model)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (ModelState.IsValid)
            {
                var id = _landService.AddLand(model,userId);
                return RedirectToAction("Index");
            }

            return View(model);
        }
        public IActionResult EditLand(int id)
        {
            var land = _landService.GetLandById(id);
            return View(land);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditLand(NewLandVm model, decimal oldAcreage, decimal oldAcreageFree)
        {
            
            if (ModelState.IsValid)
            {
                _landService.UpdateLand(model, oldAcreage, oldAcreageFree);
                return RedirectToAction("Index");
            }

            return View(model);
        }
        public IActionResult DeleteLand(int id) // Usuwa również field który był powiązany !!!
        {
            var model=_fieldService.GetAllFieldForList(id);
            if (model.Count == 0)
            {
                _landService.DeleteLand(id);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult DeleteLandContinue(int id)
        {
            _landService.DeleteLand(id);
            return RedirectToAction("Index");
        }
    }
}
