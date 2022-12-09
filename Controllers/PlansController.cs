using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GymApp.Controllers
{
    [Route("[controller]")]
    public class PlanController : Controller
    {
        private readonly ILogger<PlanController> _logger;

        public PlanController(ILogger<PlanController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }


        public IActionResult PlanDetail(string id)
        {
            return View();
        }


    }
}