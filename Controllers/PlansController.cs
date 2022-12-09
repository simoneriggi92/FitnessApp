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
        return Content("This is my default action...");
    }
    // 
    // GET: /HelloWorld/Welcome/ 
    public IActionResult Welcome(string id)
    {
        return Content($"This is the Welcome action method...{id}");
    }
}
}