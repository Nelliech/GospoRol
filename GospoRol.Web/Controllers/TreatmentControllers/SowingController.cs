using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GospoRol.Application.Interfaces.PlaceInterfaces;
using GospoRol.Application.Interfaces.ProductInterfaces;
using GospoRol.Application.Interfaces.TreatmentInterfaces;
using GospoRol.Application.ViewModels.TreatmentViewModels.SowingViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using GospoRol.Application.ViewModels.PlaceViewModels.FieldViewModels;
using AutoMapper;

namespace GospoRol.Web.Controllers.TreatmentControllers
{
    public class SowingController : Controller
    {
        private readonly ISowingService _sowingService;
        private readonly ITypeSowingService _typeSowingService;
        private readonly ISeedService _seedService;
        private readonly IWarehouseService _warehouseService;
        private readonly IFieldService _fieldService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string userId;

        public SowingController(ISowingService sowingService, ISeedService seedService, IWarehouseService warehouseService,IFieldService fieldService,
            IHttpContextAccessor httpContextAccessor, IMapper mapper,
            ITypeSowingService typeSowingService)
        {
            _sowingService = sowingService;
            _typeSowingService = typeSowingService;
            _seedService = seedService;
            _warehouseService = warehouseService;
            _fieldService = fieldService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            userId = userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddSowing()
        {
            var modelFields = _fieldService.GetAllFieldForList(userId).Fields;
            var fieldsSelectList =
                modelFields.Select(f => new SelectListItem(f.FieldName, Convert.ToString(f.Id))).ToList();

            var typeSowingSelectList = _typeSowingService.GetAllTypeSowingFotSelectList();
            
            var model = new NewSowingVm()
            {
                Field=fieldsSelectList,             
                TypeSowing = typeSowingSelectList
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSowing(NewSowingVm model)
        {
            //sprawdzic czy nie ma nowszego zabiegu. 
            if (ModelState.IsValid)
            {
                var sowingId = _sowingService.AddSowing(model, userId);            
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
