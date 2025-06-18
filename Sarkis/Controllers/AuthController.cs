using Sarkis.Models;
using System.Web.Mvc;
using BussinesLogic.Interfaces;
using Sarkis.BussinesLogic;
using Domain.Entities.User;
using System;
using System.Web.UI.WebControls;
using System.Web;
using Domain.Enums;

namespace Sarkis.Controllers
{
    public class AuthController : Controller
    {
        private readonly ISession _session;

        public AuthController()
        {
            var bl = new LogicBussines();
            _session = bl.GetSessionBL();
        }

        public ActionResult Authentification()
        {
            var model = new AuthViewModel
            {
                LoginModel = new UserLogin(),
                RegisterModel = new UserRegister()
            };

            return View(model);
        }

        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(AuthViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var data = new URegisterData
                {
                    Username = model.RegisterModel.Username,
                    Email = model.RegisterModel.Email,
                    Password = model.RegisterModel.Password,
                    RegisterIp = Request.UserHostAddress,
                    Level = model.RegisterModel.Email.Contains("@admin") ? LevelAcces.Admin : LevelAcces.User
                };

                var result = _session.UserRegister(data);

                if (result.Status)
                {
                    // Generează cookie
                    HttpCookie cookie = _session.GenCookie(data.Username);
                    Response.Cookies.Add(cookie);

                    // NU mai folosim GetUserByCookie – ci preluăm direct userul înregistrat
                    var user = _session.GetUserByCredential(data.Email); // sau data.Username

                    if (user != null)
                    {
                        Session["UserId"] = user.Id;
                        Session["UserEmail"] = user.Email;
                        Session["UserName"] = user.Username;
                    }

                    if (!string.IsNullOrEmpty(returnUrl))
                        return Redirect(returnUrl);

                    if (user.Email.Contains("@admin"))
                        return RedirectToAction("Index", "Admin");

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", result.StatusMsg);
            }

            return View("Authentification", model);

        }
        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AuthViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var data = new ULoginData
                {
                    Credential = model.LoginModel.Credential,
                    Password = model.LoginModel.Password,
                    LoginIp = Request.UserHostAddress,
                    LoginDateTime = DateTime.Now
                };

                var result = _session.UserLogin(data);
                if (result.Status)
                {
                    HttpCookie cookie = _session.GenCookie(model.LoginModel.Credential);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                    var user = _session.GetUserByCookie(cookie.Value);

                    if (user == null)
                    {
                        ModelState.AddModelError("", "Utilizatorul nu a fost găsit.");
                        return View("Authentification", model);
                    }

                    Session["UserId"] = user.Id;
                    Session["UserEmail"] = user.Email;
                    Session["UserName"] = user.Username;


                    if (!string.IsNullOrEmpty(returnUrl))
                        return Redirect(returnUrl);

                    if (user.Level == LevelAcces.Admin)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", result.StatusMsg);
            }

            return View("Authentification", model);
        }
     
    public ActionResult Logout()
        {
            Session.Clear(); // Șterge toți parametrii din sesiune
            Session.Abandon(); // Abandonează sesiunea complet

            // (Opțional) Ștergem cookie-ul de autentificare
            if (Request.Cookies["X-KEY"] != null)
            {
                var cookie = new HttpCookie("X-KEY")
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                Response.Cookies.Add(cookie);
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
