using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GospoRol.Web.Controllers.TreatmentControllers
{
    public class FertilizationController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string userId;
        public FertilizationController(IHttpContextAccessor htppContextAccessor)
        {
            _httpContextAccessor = htppContextAccessor;
            userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
