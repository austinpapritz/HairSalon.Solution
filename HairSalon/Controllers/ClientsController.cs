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

    // GET CLIENT LIST
    public IActionResult Index()
    {
        List<Client> model = _db.Clients.Include(c => c.Stylist).ToList();
        ViewBag.Stylists = _db.Stylists.ToList();
        return View(model);
    }

    // POST EDIT REASSIGN STYLIST TO CLIENT
    [HttpPost]
    public IActionResult Edit([Bind("Name,StylistId")] Client client)
    {
        _db.Clients.Update(client);
        _db.SaveChanges();

        return RedirectToAction("details", "stylists", new { id = client.StylistId });
    }

    // GET NEW CLIENT FORM
    public IActionResult Create()
    {
        ViewBag.Stylists = new SelectList(_db.Stylists, "StylistId", "Name");
        return View();
    }

    // POST NEW CLIENT
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Name,StylistId")] Client client)
    {
        _db.Clients.Add(client);
        _db.SaveChanges();
        return RedirectToAction("details", "stylists", new { id = client.StylistId });
    }
}
