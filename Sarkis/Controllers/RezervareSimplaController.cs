using BussinesLogic.DBModel;
using Domain.Entities.User;
using Sarkis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sarkis.Controllers
{

     public class RezervareSimplaController : Controller
     {
          private readonly RezervareaContext _db;

          public RezervareSimplaController()
          {

               _db = new RezervareaContext();
          }

          public ActionResult CreateBanquet()
          {

               var model = new RezervareSimplaModel();
               return View(model);
          }


          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult CreateBanquet(RezervareSimplaModel model)
          {
               if (!ModelState.IsValid)
               {

                    return View(model);
               }


               var entity = new RezerTable
               {

                    DataRezervare = model.DataRezervare,
                    OraRezervare = model.OraRezervare,
                    NrPersoane = model.NrPersoane,
                    TipBanchet = model.TipBanchet,
                    NrTelefon = model.NrTelefon


               };

               _db.RezerTable.Add(entity);
               _db.SaveChanges();


               return RedirectToAction("Authentification", "Auth", new { id = entity.RezervationId });
          }


          public ActionResult Confirm(int id)
          {
               var entity = _db.RezerTable.Find(id);
               if (entity == null)
                    return HttpNotFound();


               return View(entity);
          }
     }
}
