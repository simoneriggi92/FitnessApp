using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GymApp.Models.Services.Application;
using GymApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Controllers
{
   
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsersController(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            this.userService = userService;
            this._httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return Content("Sono in user Index ");
        }

        public async Task<IActionResult> Detail(string id)
        {
            var user = await userService.GetUserAsync(id);
            // return View(users);
            return View(user);
        }

        [Route("Users/all-users")]
        public ActionResult GetUsers()
        {
            // var users = await userService.GetUsersAsync();
            return View("~/Views/Users/Detail.cshtml", userService.GetUsersAsync());
        }


    }
}