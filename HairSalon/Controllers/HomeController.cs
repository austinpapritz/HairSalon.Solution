using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace HairSalon.Controllers;

public class HomeController : Controller
{
    // SPLASH PAGE 
    public IActionResult Index()
    {
        return View();
    }
}
