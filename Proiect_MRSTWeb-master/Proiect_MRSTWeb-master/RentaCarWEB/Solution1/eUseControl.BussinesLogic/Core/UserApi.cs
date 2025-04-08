using eUseControl.BussinesLogic.DBModel.Seed;
using eUseControl.Domain.Entities.User;

using System.Linq;

namespace eUseControl.BussinesLogic.Core
{
    public class UserApi
    {
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
                    password = data.Password
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
