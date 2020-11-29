using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GospoRol.Web.Controllers.ProductControllers
{
    public class YieldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
