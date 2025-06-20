﻿using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BussinesLogic.Interfaces
{
     public interface ISession
     {
          ULoginResp UserLogin(ULoginData data);
          URegisterResp UserRegister(URegisterData data);
          HttpCookie GenCookie(string loginCredential);
          UserMinimal GetUserByCookie(string value);
        bool IsAuthenticated(HttpCookieCollection cookies);
        UDbTable GetUserById(int id);
        void UpdateUser(UDbTable user);
        UDbTable GetUserByEmail(string email);
        UDbTable GetUserByCredential(string credential);


    }

}
