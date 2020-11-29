using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GospoRol.Application.Interfaces;
using GospoRol.Application.Interfaces.PlaceInterfaces;
using GospoRol.Application.ViewModels;
using GospoRol.Application.ViewModels.PlaceViewModels.FieldViewModels;
using GospoRol.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GospoRol.Web.Controllers
{
    [Authorize]
    public class FieldController : Controller
    {
        private readonly IFieldService _fieldService;
        private readonly ILandService _landService;
        private readonly IAgriculturalClassService _agriculturalClassService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FieldController(IFieldService fieldService, ILandService landService, IHttpContextAccessor htppContextAccessor,
            IAgriculturalClassService agriculturalClassService)
        {
            _fieldService = fieldService;
            _landService = landService;
            _agriculturalClassService = agriculturalClassService;
            _httpContextAccessor = htppContextAccessor;
        }
        public IActionResult Index()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = _fieldService.GetAllFieldForList(userId);
            return View(model);
        }

        public IActionResult AddField()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //Dropdown list with plot number
            var modelLand = _landService.GetAllLandForListDrop(userId).Name;
            var landSelectList = modelLand.Select(f => new SelectListItem(f.PlotNumber, Convert.ToString(f.Id))).ToList();
            //Dropdown list with agricultural Class
            var modelAgrClass = _agriculturalClassService.GetAllAgriculturalClassForList().Classes;
            var agrClassSelectList =
                modelAgrClass.Select(f => new SelectListItem(f.Class, Convert.ToString(f.Id))).ToList();


            var viewModel = new NewFieldVm();
            viewModel.Lands = landSelectList;
            viewModel.AgriculturalClasses = agrClassSelectList;
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddField(NewFieldVm model, int landId)
        {
           
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (ModelState.IsValid)
            {
                var id = _fieldService.AddField(model, landId, userId);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult EditField(int id)
        {
            var modelAgrClass = _agriculturalClassService.GetAllAgriculturalClassForList().Classes;
            var agrClassSelectList =
                modelAgrClass.Select(f => new SelectListItem(f.Class, Convert.ToString(f.Id))).ToList();

            var field = _fieldService.GetFieldById(id);
            field.AgriculturalClasses = agrClassSelectList;
            
            
            return View(field);
        }

        [HttpPost]
        public IActionResult EditField(NewFieldVm model)
        {
            if (ModelState.IsValid)
            {
                _fieldService.UpdateField(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult DeleteField(int id)
        {
            _fieldService.DeleteField(id);
            return RedirectToAction("Index");
        }
    }
}
