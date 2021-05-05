using System.Security.Claims;
using GospoRol.Application.Interfaces.PlaceInterfaces;
using GospoRol.Application.ViewModels.PlaceViewModels.FieldViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GospoRol.Web.Controllers.PlaceControllers
{
    [Authorize]
    public class FieldController : Controller
    {
        private readonly IFieldService _fieldService;
        private readonly ILandService _landService;
        private readonly IAgriculturalClassService _agriculturalClassService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string userId;
        public FieldController(IFieldService fieldService, ILandService landService, IHttpContextAccessor htppContextAccessor,
            IAgriculturalClassService agriculturalClassService)
        {
            _fieldService = fieldService;
            _landService = landService;
            _agriculturalClassService = agriculturalClassService;
            _httpContextAccessor = htppContextAccessor;
            userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public IActionResult Index()
        {
            
            var model = _fieldService.GetAllFieldForList(userId);
            return View(model);
        }

        public IActionResult AddField()
        {
            var land = _landService.GetAllLandForList(userId);
            if(land.Count == 0)
            {
                return RedirectToAction("LandDontExist");
            }
            //Dropdown list with plot number
            var landSelectList = _landService.GetAllLandForSelectList(userId);
            //Dropdown list with agricultural Class
            var agrClassSelectList = _agriculturalClassService.GetAllAgriculturalClassForSelectList();

            var viewModel = new NewFieldVm()
            {
                Lands = landSelectList,
                AgriculturalClasses = agrClassSelectList
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddField(NewFieldVm model, int landId)
        {
            var land = _landService.GetLandById(landId);
            if(land.AcreageFree < model.Acreage)
            {
                return RedirectToAction("NoFreeAcreage", new { landName = land.PlotNumber });
            }
            
            if (ModelState.IsValid)
            {
                _fieldService.AddField(model, landId, userId);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult EditField(int id)
        {

            var agrClassSelectList = _agriculturalClassService.GetAllAgriculturalClassForSelectList();

            var field = _fieldService.GetFieldForEditById(id);
            if (field.UserId != userId)
            {
                return RedirectToAction("Index");
            }
            field.AgriculturalClasses = agrClassSelectList;
            
            
            return View(field);
        }

        [HttpPost]
        public IActionResult EditField(EditFieldVm model)
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
            var fieldUserId = _fieldService.GetFieldById(id).UserId;
            if (fieldUserId != userId)
            {
                return RedirectToAction("Index");

            }
            _fieldService.DeleteField(id);
            return RedirectToAction("Index");
        }
        public IActionResult NoFreeAcreage(string landName)
        {
            ViewBag.LandName = landName;
            return View();
        }

        public IActionResult LandDontExist()
        {
            return View();
        }
    }
}
