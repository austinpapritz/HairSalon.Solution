using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
    public IActionResult Create()
    {
        ViewBag.Stylists = new SelectList(_db.Stylists, "StylistId", "Name");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Name,StylistId")] Client client)
    {

        // client.stylist = _db.Stylists
        //                     .FirstOrDefault(s => s.StylistId == client.StylistId);
        _db.Clients.Add(client);
        _db.SaveChanges();
        return RedirectToAction("details", "stylists", new { id = client.StylistId });
    }
}
