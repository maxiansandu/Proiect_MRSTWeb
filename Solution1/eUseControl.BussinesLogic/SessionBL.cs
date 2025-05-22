using eUseControl.BussinesLogic.Core;
using eUseControl.BussinesLogic.DBModel.Seed;
using eUseControl.BussinesLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BussinesLogic
{
    public class SessionBL
    {
        private readonly UserApi _userApi = new UserApi();

        public bool Login(string username, string password, string email)
        {
            var result = LoginWithResult(username, password);
            return result.Status;
        }

        public LoginResult LoginWithResult(string username, string password)
        {
            var loginData = new ULoginData
            {
                Username = username,
                Password = password
            };

            var result = _userApi.LoginUser(loginData); // Verificare în DB

            if (result.Status)
            {
                // Setăm rolul în funcție de username
                var role = (password == "admin") ? "admin" : "user";

                result.Role = role; // presupunem că ai o proprietate Role în modelul User
            }

            return result;
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
                    password = data.Password   // Modifică "Password" în "password"
                };

                db.Users.Add(newUser);
                db.SaveChanges();

                message = "Contul a fost creat cu succes.";
                return true;
            }
        }
    }
}