using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers;

public class ClientsController : Controller
{
    private readonly HairSalonContext _db;

    public ClientsController(HairSalonContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        return View();
    }
}
