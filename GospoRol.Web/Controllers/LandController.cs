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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LandController(ILandService landService, IHttpContextAccessor httpContextAccessor)
        {
            _landService = landService;
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
        public IActionResult EditLand(NewLandVm model)
        {
           
            if (ModelState.IsValid)
            {
                _landService.UpdateLand(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
