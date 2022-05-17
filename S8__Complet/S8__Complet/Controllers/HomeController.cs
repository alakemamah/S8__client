using S8__Complet.Models;
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
            PredictionItem pred = new PredictionItem();
            using (Entities db = new Entities())
            {
                pred.DataCollection=db.Donnees.ToList<Donnees>();
            }
                return View();
        }
    }
}