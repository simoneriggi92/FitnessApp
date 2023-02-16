using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FitnessApp.Models.Services.Application;
using FitnessApp.Models.Services.Infrastructure;
using GymApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GymApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILoginService _loginService;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ILoginService loginService)
        {
            _logger = logger;
            this._loginService = loginService;
        }



        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            UserViewModel loggedUser = _loginService.AutenticateUser(username, password).Result;

            if(loggedUser != null)
            {
                TempData["username"] = loggedUser.Username;
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

       
    }
}