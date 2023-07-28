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
    public IActionResult New()
    {
        // Send in a new Stylist object for error handling 
        return View(new Stylist());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult New([Bind("Name,Specialty,Wage")] Stylist stylist)
    {
        // If valid stylist is returned from form add to db
        if (ModelState.IsValid)
        {
            _db.Stylists.Add(stylist);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        // If not, reload New page with error
        ModelState.AddModelError("", "Make sure every field is filled with the correct data type.");
        return View(stylist);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        Stylist stylistToBeDeleted = _db.Stylists.FirstOrDefault(s => s.StylistId == id);

        if (stylistToBeDeleted == null)
        {
            return NotFound();
        }

        _db.Stylists.Remove(stylistToBeDeleted);
        _db.SaveChanges();

        // AJAX call in site.js is expecting Ok() before it reloads the page
        return Ok();
    }

}
