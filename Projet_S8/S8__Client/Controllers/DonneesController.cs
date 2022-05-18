using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using S8__API.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using S8__Client.Controllers;

namespace S8__API.Controllers
{
    public class DonneesController : Controller
    {
        // GET: Donnees
        public IActionResult Index()
        {
            IEnumerable<Donnees> donnees = API.Instance.GetDonneesAsync().Result;
            return View(donnees);
        }

        // GET: Donnees/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return View(API.Instance.GetDonneesAsync(id).Result);
        }

        // GET: Donnees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Donnees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nom")] Donnees donnee)
        {
            if (ModelState.IsValid)
            {
                var URI = API.Instance.AjoutDonneesAsync(donnee);
                return RedirectToAction(nameof(Index));
            }
            return View(donnee);
        }
        // GET: Donnees/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return View(API.Instance.GetDonneesAsync(id).Result);
        }

        // POST: Donnees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nom")] Donnees donnee)
        {
            if (id != donnee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var URI = API.Instance.ModifDonneesAsync(donnee);
                return RedirectToAction(nameof(Index));
            }
            return View(donnee);
        }

        // GET: Donnees/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return View(API.Instance.GetDonneesAsync(id).Result);
        }
        [HttpPost, ActionName("Delete")]
        // POST: Donnees/Delete/5
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var URI = API.Instance.SupprDonneesAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
