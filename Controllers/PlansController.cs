using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GymApp.Controllers
{
    public class PlansController : Controller
    {
        // 
        // GET: /HelloWorld/

         public IActionResult Index()
        {
            return View();
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