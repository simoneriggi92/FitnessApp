using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FitnessApp.Models.Services.Application;
using GymApp.Models.Entities;
using GymApp.Models.Services.Application;
using GymApp.Models.Services.Application.Interfaces;
using GymApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GymApp.Controllers
{
    public class PlansController : Controller
    {
        private readonly IEfCorePlanService planService;
        private readonly IEfCoreExerciseService exerciseService;
        private readonly IHttpContextAccessor httpContextAccessor;

        // 
        // GET: /HelloWorld/

        public PlansController(IEfCorePlanService planService,IEfCoreExerciseService exerciseService, IHttpContextAccessor httpContextAccessor)
        {
            this.planService = planService;
            this.exerciseService = exerciseService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var user = planService.GetPlans();
            return View(user.Result);
        }

     
        // 
        // GET: /HelloWorld/Welcome/ 
        public void CreatePlan(List<string> exercises)
        {
            var plan = new Plan();
            var user = planService.GetPlans();
            planService.AddPlan(plan);
        }
        
        // 
        // GET: /HelloWorld/Welcome/ 
        public IActionResult AddPlan(string id)
        {
            var exercises = exerciseService.GetExercises();
            return View(exercises.Result);
        }

         public IActionResult Detail(string id)
        {
            return View();
        }




    }
}