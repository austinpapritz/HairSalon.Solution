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
    public IActionResult Create()
    {
        // Both Create() and Edit() use `Create.cshtml`
        ViewData["FormAction"] = "Create";
        ViewData["SubmitButton"] = "Add Stylist";
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Name,Specialty,Wage")] Stylist stylist)
    {
        // If valid stylist is returned from form add to db
        if (ModelState.IsValid)
        {
            _db.Stylists.Add(stylist);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult Edit(int id)
    {
        Stylist stylistToBeEdited = _db.Stylists.FirstOrDefault(s => s.StylistId == id);

        if (stylistToBeEdited == null)
        {
            return NotFound();
        }

        // Both Create() and Edit() use `Create.cshtml`
        ViewData["FormAction"] = "Edit";
        ViewData["SubmitButton"] = "Update Stylist";

        return View("Create", stylistToBeEdited);
    }

    [HttpPost]
    public IActionResult Edit(int id, [Bind("StylistId,Name,Specialty,Wage")] Stylist stylist)
    {
        if (id != stylist.StylistId)
        {
            return NotFound();
        }

        _db.Update(stylist);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }

    private bool StylistExists(int id)
    {
        return _db.Stylists.Any(e => e.StylistId == id);
    }

    // Handled by wwwroot/js/site.js.
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

        // Return HTTP 200 OK to AJAX request, signalling successful deletion.
        return Ok();
    }
}
