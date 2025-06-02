using BussinesLogic.DBModel;
using Domain.Entities.User;
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

        public ReservationsController()
        {
            
            _db = new ReservareContext();
        }

        public ActionResult Create()
        {
           
            var model = new ReservareModel();
            return View(model);
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservareModel model)
        {
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

            
            return RedirectToAction("Authentification", new { id = entity.ReservationId });
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
