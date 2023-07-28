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
        // Fetch all Stylists from the database
        var stylists = _db.Stylists.ToList();

        // Print the count of Stylists for debugging
        Debug.WriteLine("Number of stylists: " + stylists.Count);

        ViewBag.Stylists = new SelectList(_db.Stylists, "StylistId", "Name");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Name,StylistId")] Client client)
    {
        if (ModelState.IsValid)
        {
            _db.Clients.Add(client);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        // If anything goes wrong, reload the form
        ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name", client.StylistId);
        return View();
    }
}
