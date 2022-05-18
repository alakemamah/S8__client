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
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;

namespace S8__API.Controllers
{
    public class DonneesController : Controller
    {
        private IHostingEnvironment _env;
        private string _dir;

        public DonneesController(IHostingEnvironment env)
        {
            _env = env;
            _dir = _env.ContentRootPath;
        }
        //GetDonneesAsync()
        public static readonly HttpClient client = new HttpClient();
        public async Task<ICollection<Donnees>> GetDonneesAsync()
        {
            ICollection<Donnees> donnees = new List<Donnees>();
            HttpResponseMessage response = client.GetAsync("https://localhost:5001/api/Donnees").Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                donnees = JsonConvert.DeserializeObject<List<Donnees>>(resp);
            }
            return donnees;
        }
        public IActionResult Index()
        {
            ICollection<Donnees> donnees = GetDonneesAsync().Result;

            return View(donnees);
        }



        //GetDonneesAsync(id)
        public async Task<Donnees> GetDonneesAsync(int? id)
        {
            Donnees Donnees = null;
            HttpResponseMessage response = client.GetAsync("https://localhost:5001/api/Donnees/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                Donnees = JsonConvert.DeserializeObject<Donnees>(resp);
            }
            return Donnees;
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

        //AjoutDonneesAsync(donnees)
        public async Task<Uri> AjoutDonneesAsync(Donnees donnees)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:5001/api/Donnees/", donnees);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
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
                var URI = AjoutDonneesAsync(donnee);
                return RedirectToAction(nameof(Index));
            }
            return View(donnee);
        }


        //ModifDonneesAsync(donnees)
        public async Task<Uri> ModifDonneesAsync(Donnees donnees)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("https://localhost:5001/api/Donnees/" + donnees.Id, donnees);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        // GET: Donnees/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return View(GetDonneesAsync(id).Result);
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
                var URI =ModifDonneesAsync(donnee);
                return RedirectToAction(nameof(Index));
            }
            return View(donnee);
        }



        //SupprDonneesAsync(id)
        public async Task<Uri> SupprDonneesAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("https://localhost:5001/api/Donnees/" + id);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        // GET: Donnees/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return View(GetDonneesAsync(id).Result);
        }
        [HttpPost, ActionName("Delete")]
        // POST: Donnees/Delete/5
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var URI = SupprDonneesAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
