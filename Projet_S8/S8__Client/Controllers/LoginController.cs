using Microsoft.AspNetCore.Mvc;
using S8__API.Models;
using S8__Client.ViewModels;

namespace S8__Client.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            UserViewModel viewModel = new UserViewModel { Authentifie = false };
            //if (HttpContext.User.Identity.IsAuthenticated)
            //{
            //    viewModel.User = API.Instance.GetUser(HttpContext.User.Identity.Name).Result;
            //}
            //else
            //{
            //    HttpContext.User.Identity.;
            //}
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(UserViewModel viewModel)
         {
             //if (ModelState.IsValid)
             {
                 User user = API.Instance.GetUser(viewModel.User.Username, viewModel.User.Password).Result;
                 if (user != null)
                 {
                     return Redirect("/Ecuries/Index");
                 }
                 ModelState.AddModelError("User.Login", "Login et/ou mot de passe incorrect(s)");
             }
             return View(viewModel);
         }

        public ActionResult Deconnexion()
        {
            return Redirect("/");
        }
    }
}