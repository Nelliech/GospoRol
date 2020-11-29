using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GospoRol.Application.Interfaces;
using GospoRol.Application.Interfaces.ProductInterfaces;
using GospoRol.Application.Services;
using Microsoft.AspNetCore.Http;

namespace GospoRol.Web.Controllers.ProductControllers
{
    public class ProductController : Controller
    {
        private readonly ISeedService _seedService;
        private readonly IFertilizerService _fertilizerService;
        private readonly IYieldService _yieldService;
        private readonly IPesticideService _pesticideService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductController(ISeedService seedService, IFertilizerService fertilizerService, IYieldService yieldService,
            IPesticideService pesticideService, IHttpContextAccessor httpContextAccessor)
        {
            _seedService = seedService;
            _fertilizerService = fertilizerService;
            _yieldService = yieldService;
            _pesticideService = pesticideService;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
