using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    public IActionResult Details(int id)
    {
        // Retrieve the currentStylist, including their Client list
        Stylist currentStylist = _db.Stylists
                                    .Include(s => s.Clients)
                                    .FirstOrDefault(s => s.StylistId == id);

        // If currentStylist returns null then return error
        if (currentStylist == null)
        {
            return NotFound();
        }

        // Set model to list of the currentStylist's clients, set currentStylist to ViewBag
        List<Client> model = currentStylist.Clients.ToList();
        ViewBag.Stylist = currentStylist;

        return View(model);
    }
}
