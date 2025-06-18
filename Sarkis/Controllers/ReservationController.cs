using BussinesLogic.DBModel;
using BussinesLogic.Interfaces;
using Domain.Entities;
using Domain.Entities.User;
using Sarkis.BussinesLogic;
using Sarkis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace Sarkis.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly ReservareContext _db;
        private readonly ISession _session = new SessionBL();


        public ReservationsController()
        {
            
            _db = new ReservareContext();
        }

        public ActionResult Create()
        {

            var model = TempData["RezervareModel"] as ReservareModel ?? new ReservareModel();
            return View(model);
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservareModel model)
        {

            if ( Session["UserId"] == null)
            {
                TempData["RezervareModel"] = model;
                return RedirectToAction("Authentification", "Auth");
            }

            if (!ModelState.IsValid)
            {
                
                return View(model);
            }

           
            var entity = new ReserTable
            {
                
                EventDate = model.EventDate,
                EventTime = model.EventTime,
                NumPersons = model.NumPersons,
                EventType = model.EventType,
                PhoneNumber = model.PhoneNumber

                
            };

            _db.ReserTable.Add(entity);
            _db.SaveChanges();

            if (model.BucateComandate != null && model.BucateComandate.Any())
            {
                foreach (var item in model.BucateComandate)
                {
                    var bucat = new BucataComandata
                    {
                        ReserTable = entity,
                        Nume = item.Nume,
                        Pret = item.Pret,
                        Cantitate = item.Cantitate
                    };

                    _db.BucateComandate.Add(bucat);
                }
                _db.SaveChanges();
            }
            TempData["SuccessMessage"] = "Rezervarea cu bucate a fost trimisă cu succes!";
            return RedirectToAction("Index", "Home");
        }


        
        public ActionResult Confirm(int id)
        {
            var entity = _db.ReserTable.Find(id);
            if (entity == null)
                return HttpNotFound();

           
            return View(entity);
        }
    }
}
