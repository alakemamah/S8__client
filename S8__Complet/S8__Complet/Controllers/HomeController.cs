using S8__Complet.Models;
using S8__Complet.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S8__Complet.Controllers
{
    
    public class HomeController : Controller
    {
        

        private DonneeRepository _donneeRepository;
        public HomeController()
        {
            this._donneeRepository = new DonneeRepository(new Entities());
        }

        /*[Authorize(Roles ="Admin")]*/
        public ActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public ActionResult RespoHome()
        {
            return View();
        }

        public ActionResult Prediction()
        {
          
            //IEnumerable<Donnees> dataNames = _donneeRepository.GetDonnee();
            ViewBag.Accounts = new SelectList(_donneeRepository.GetDonnee(), "AccountId", "AccountName");
            PredictionItem pred = new PredictionItem();
            ViewBag.Prediction = pred;
            return View();
        }
    }
}