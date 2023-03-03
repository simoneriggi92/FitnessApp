using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GymApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GymApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            // this._loginService = loginService;
        }



        // public IActionResult Dashboard()
        // {
        //     return View();
        // }

        public IActionResult Index()
        {
            return View();
        }


        // [HttpPost]
        // public IActionResult Index(string username, string password)
        // {
        //     // UserViewModel loggedUser = _loginService.AutenticateUser(username, password).Result;

        //     // if (loggedUser != null)
        //     // {
        //     //     TempData["username"] = loggedUser.Username;
        //     //     return RedirectToAction("Index");
        //     // }
        //     // else
        //     // {
        //     //     return View();
        //     // }
        //     return View()

        // }


    }
}