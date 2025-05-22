using eUseControl.BussinesLogic.DBModel.Seed;
using eUseControl.Domain.Entities.User;

using System.Linq;

namespace eUseControl.BussinesLogic.Core
{
    public class UserApi
    {
        public LoginResult LoginUser(ULoginData data)
        {
            using (var db = new UserContext())
            {
                var user = db.Users.FirstOrDefault(u =>
                    (u.username == data.Username || u.email == data.Username)
                    && u.password == data.Password);

                if (user == null)
                {
                    return new LoginResult
                    {
                        Status = false,
                        Message = "Username/email sau parolă incorectă."
                    };
                }

                return new LoginResult
                {
                    Status = true,
                    Message = "Autentificare reușită.",
                    User = user
                };
            }
        }
        public RegisterResult RegisterUser(ULoginData data)
        {
            using (var db = new UserContext())
            {
                var userExists = db.Users.Any(u => u.username == data.Username);

                if (userExists)
                {
                    return new RegisterResult
                    {
                        Status = false,
                        Message = "Acest username există deja."
                    };
                }

                var newUser = new UDBTable
                {
                    username = data.Username,
                    password = data.Password,
                    email = data.Email // trebuie să adaugi și Email în ULoginData
                };

                db.Users.Add(newUser);
                db.SaveChanges();

                return new RegisterResult
                {
                    Status = true,
                    Message = "Înregistrare reușită!"
                };
            }
        }
    }
}