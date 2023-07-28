using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers;

public class StylistsController : Controller
{
    private readonly HairSalonContext _db;

    public StylistsController(HairSalonContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        return View();
    }
}
