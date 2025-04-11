using eUseControl.BussinesLogic.Core;
using eUseControl.BussinesLogic.DBModel.Seed;
using eUseControl.BussinesLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BussinesLogic
{
    public class SessionBL : ISession
    {
        private readonly string validUsername = "admin";
        private readonly string validPassword = "1234";
   
        public bool Login(string username, string password, string email)
        {
            return username == validUsername && password == validPassword;


        }

        public bool RegisterUser(ULoginData data, out string message)
        {
            using (var db = new UserContext())
            {
                var existingUser = db.Users.FirstOrDefault(u => u.username == data.Username); // Modifică "Username" în "username"
                if (existingUser != null)
                {
                    message = "Acest username este deja folosit.";
                    return false;
                }

                var newUser = new UDBTable
                {
                    username = data.Username,  // Modifică "Username" în "username"
                    password = data.Password,  // Modifică "Password" în "password"
                    email = data.Email,
                };

                db.Users.Add(newUser);
                db.SaveChanges();

                message = "Contul a fost creat cu succes.";
                return true;
            }
        }
    }
}

