using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GospoRol.Application.Interfaces;
using GospoRol.Application.Interfaces.PlaceInterfaces;
using GospoRol.Application.ViewModels;
using GospoRol.Application.ViewModels.PlaceViewModels.LandViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GospoRol.Web.Controllers.PlaceControllers
{
    [Authorize]
    public class LandController : Controller
    {
        private readonly ILandService _landService;
        private readonly IFieldService _fieldService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string userId;
        public LandController(ILandService landService,IFieldService fieldService, IHttpContextAccessor httpContextAccessor)
        {
            _landService = landService;
            _fieldService = fieldService;
            _httpContextAccessor = httpContextAccessor;
            userId= _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public IActionResult Index()
        {
            
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
            
            if (ModelState.IsValid)
            {
                _landService.AddLand(model,userId);
                return RedirectToAction("Index");
            }

            return View(model);
        }
        public IActionResult EditLand(int id)
        {
            
            var land = _landService.GetLandById(id);
            if (land.UserId != userId)
            {
                return RedirectToAction("Index");
            }
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
            var landUserId = _landService.GetLandById(id).UserId;
            if (landUserId != userId)
            {
                return RedirectToAction("Index");
            }
            if (model.Count == 0)
            {
                _landService.DeleteLand(id);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult DeleteLandContinue(int id)
        {
            var landUserId = _landService.GetLandById(id).UserId;
            if (landUserId != userId)
            {
                return RedirectToAction("Index");

            }
            _landService.DeleteLand(id);
            return RedirectToAction("Index");
        }

        public IActionResult DetailsLand(int id)
        {
            var model = _landService.GetLandById(id);
            if(model.UserId != userId)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
