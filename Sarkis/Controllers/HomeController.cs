using BussinesLogic.Interfaces;
using Sarkis.BussinesLogic;
using Sarkis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sarkis.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
          public ActionResult Meniu()
          {
               return View();
          }
          public ActionResult About()
          {
               return View();
          }
          public ActionResult Sali ()
          {
               return View();
          }
          public ActionResult Galerie()
          {
               return View();
          }
          public ActionResult Contact()
          {
               return View();
          }
          public ActionResult Rezervareasimpla()
          {
               return View();
          }
        private readonly ISession _session = new SessionBL();
        public ActionResult profile()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Authentification", "Auth");
            }
            ViewBag.UserName = Session["UserName"];
            ViewBag.UserEmail = Session["UserEmail"];
            return View();

          }
        [HttpGet]
        public ActionResult Setari()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Authentification", "Auth");

            var userId = (int)Session["UserId"];
            var user = _session.GetUserById(userId);

            var model = new UserSetariModel
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Setari(UserSetariModel updatedUser)
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Authentification", "Auth");

            var user = _session.GetUserById(updatedUser.Id);

            user.Username = updatedUser.Username;
            user.Email = updatedUser.Email;

            _session.UpdateUser(user);

            Session["UserName"] = user.Username;
            Session["UserEmail"] = user.Email;

            TempData["SuccessMessage"] = "Datele au fost actualizate cu succes!";
            return RedirectToAction("Setari");
        }

        public ActionResult Comenzi()
        {
            return View();
        }

    }
}