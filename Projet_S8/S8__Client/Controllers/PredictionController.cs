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
    public class PredictionController : Controller
    {
        private IHostingEnvironment _env;
        private string _dir;

        public PredictionController(IHostingEnvironment env)
        {
            _env = env;
            _dir = _env.ContentRootPath;
        }
        //GetPredictionAsync()
        public static readonly HttpClient client = new HttpClient();
        public async Task<ICollection<Prediction>> GetPredictionAsync()
        {
            ICollection<Prediction> Prediction = new List<Prediction>();
            HttpResponseMessage response = client.GetAsync("https://localhost:5001/api/Prediction").Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                Prediction = JsonConvert.DeserializeObject<List<Prediction>>(resp);
            }
            return Prediction;
        }
        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return View(GetPredictionAsync(id).Result);

            }
        }



        //GetPredictionAsync(id)
        public async Task<Prediction> GetPredictionAsync(int? id)
        {
            Prediction Prediction = null;
            HttpResponseMessage response = client.GetAsync("https://localhost:5001/api/Prediction/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                Prediction = JsonConvert.DeserializeObject<Prediction>(resp);
            }
            return Prediction;
        }
        // GET: Prediction/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return View(GetPredictionAsync(id).Result);
        }

        //AjoutPredictionAsync(Prediction)
        public async Task<Uri> AjoutPredictionAsync(Prediction Prediction)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:5001/api/Prediction/", Prediction);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        // GET: Prediction/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prediction/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nom")] Prediction prediction)
        {
            if (ModelState.IsValid)
            {
                var URI = AjoutPredictionAsync(prediction);
                return RedirectToAction(nameof(Index));
            }
            return View(prediction);
        }


        //ModifPredictionAsync(Prediction)
        public async Task<Uri> ModifPredictionAsync(Prediction Prediction)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("https://localhost:5001/api/Prediction/" + Prediction.ID, Prediction);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        // GET: Prediction/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return View(GetPredictionAsync(id).Result);
        }

        // POST: Prediction/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nom")] Prediction prediction)
        {
            if (id != prediction.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var URI = ModifPredictionAsync(prediction);
                return RedirectToAction(nameof(Index));
            }
            return View(prediction);
        }
    }
}
