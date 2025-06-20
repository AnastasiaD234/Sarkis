﻿using BussinesLogic.DBModel;
using BussinesLogic.Interfaces;
using Domain.Entities.User;
using Sarkis.BussinesLogic;
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
        private readonly ISession _session = new SessionBL();

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
            if (Session["UserId"] == null)
            {
                TempData["RezervareModel"] = model;
                return RedirectToAction("Authentification", "Auth");
            }
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

            TempData["SuccessMessage"] = "Rezervarea a fost trimisă cu succes!";
            return RedirectToAction("Index", "Home");
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
