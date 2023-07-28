using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers;

public class ClientsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
