using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FitnessApp.Models.Services.Application;
using GymApp.Models.Services.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GymApp.Controllers
{
    public class PlansController : Controller
    {
        private readonly IEfCorePlanService planService;
        private readonly IHttpContextAccessor httpContextAccessor;

        // 
        // GET: /HelloWorld/

        public PlansController(IEfCorePlanService planService, IHttpContextAccessor httpContextAccessor)
        {
            this.planService = planService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var user = planService.GetPlans();
            return View(user);
        }

     
        // 
        // GET: /HelloWorld/Welcome/ 
        public IActionResult CreatePlan(string id)
        {
            return View();
        }

         public IActionResult Detail(string id)
        {
            return View();
        }




    }
}