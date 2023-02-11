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
        private readonly AbstractUserService userService;
        public UsersController(AbstractUserService userService)
        {
            this.userService = userService;
        }
        public IActionResult Index()
        {
            return Content("Sono in user Index ");
        }

        public IActionResult Detail(string id)
        {
            UserViewModel users = userService.GetUser(id);
            return View(users);
        }


    }
}