using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sarkis.Controllers
{
     public class ReservationController : Controller
     {
          [HttpPost]
          public ActionResult Buy()
          {
               // dacă utilizatorul nu este autentificat
               if (!User.Identity.IsAuthenticated)
               {
                    return RedirectToAction("Authentification", "Auth");
               }

               // altfel, mergi la pagina de rezervare
               return RedirectToAction("Confirm"); // sau ce pagină ai pentru finalizare
          }

          public ActionResult Confirm()
          {
               return View(); // aici ar fi pagina unde se finalizează comanda
          }
     }
}
