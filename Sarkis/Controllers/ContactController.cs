using BussinesLogic.DBModel;
using Sarkis.Models;
using System.Web.Mvc;
using Domain.Entities.User;

namespace Sarkis.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactContext _db = new ContactContext();

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Send(ContactModel model)
        {
            if (ModelState.IsValid)
            {
              
                var contactEntity = new ContactTable
                {
                    Name = model.Name,
                    Email = model.Email,
                    Subject = model.Subject,
                    Message = model.Message
                };

                _db.ContactTable.Add(contactEntity);
                _db.SaveChanges();

                ViewBag.Mesaj = "Mesajul a fost trimis cu succes!";
                ModelState.Clear();
                return Content("success");
            }

            Response.StatusCode = 400;
            return Content("invalid");
        }
    }
}
