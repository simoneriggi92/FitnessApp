using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymApp.Models.Services.Application;
using GymApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Controllers
{
   
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return Content("Sono in user Index ");
        }

        public IActionResult Detail(string id)
        {
            var userService = new UserService();
            UserViewModel users = userService.GetServices();
            return View(users);
        }


    }
}