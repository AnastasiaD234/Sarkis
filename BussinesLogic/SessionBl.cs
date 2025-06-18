using BussinesLogic.Core;
using BussinesLogic.DBModel;
using BussinesLogic.Interfaces;
using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Sarkis.BussinesLogic
{
     public class SessionBL : UserAPI, ISession
     {
          public ULoginResp UserLogin(ULoginData data)
          {
               return UserLoginAction(data);
          }
          public URegisterResp UserRegister(URegisterData data)
          {
               return UserRegisterAction(data);  
          }
          public HttpCookie GenCookie(string loginCredential)
          {
               return Cookie(loginCredential);
          }
          public UserMinimal GetUserByCookie(string apiCookieValue)
          {
               return UserCookie(apiCookieValue);
          }
        public UDbTable GetUserByEmail(string email)
        {
            return _db.Users.FirstOrDefault(u => u.Email == email);
        }
        public UDbTable GetUserByCredential(string credential)
        {
            return _db.Users.FirstOrDefault(u => u.Username == credential || u.Email == credential);
        }


        public bool IsAuthenticated(HttpCookieCollection cookies)
        {
            var cookie = cookies["X-KEY"]; 
            if (cookie == null) return false;

            var user = GetUserByCookie(cookie.Value);
            return user != null;
        }
        private readonly UserContext _db = new UserContext();

        public UDbTable GetUserById(int id)
        {
            return _db.Users.FirstOrDefault(u => u.Id == id);
        }

        public void UpdateUser(UDbTable user)
        {
            var existing = _db.Users.Find(user.Id);
            if (existing != null)
            {
                existing.Username = user.Username;
                existing.Email = user.Email;
                _db.SaveChanges();
            }
        }

       

    }
}
