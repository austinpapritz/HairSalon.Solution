using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
        List<Stylist> model = _db.Stylists.ToList();
        return View(model);
    }
}
