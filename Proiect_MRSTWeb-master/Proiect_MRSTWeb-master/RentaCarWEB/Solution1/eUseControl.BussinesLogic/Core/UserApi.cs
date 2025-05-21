using eUseControl.BussinesLogic.DBModel.Seed;
using eUseControl.BussinesLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace eUseControl.BussinesLogic.Core
{
    public class UserApi
    {

        public bool adAnunce(PostTable postTable)
        {

            try
            {
                using (var db = new UserContext()) {

                    db.PostTables.Add(postTable);
                    db.SaveChanges();
                    return true;
                        
                
                }


            }
            catch {

                return false;
            }
            
        }


        public List<PostTable> get_posts() {


            using (var db = new UserContext()) { 
            
            
            
            return db.PostTables.ToList();
            
            }
        
        
        
        }

      
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


        public List<PostTable> getMyPosts(ULoginData data, string username) {

           


            using (var db = new UserContext()) { 

              
           
                
                    return db.PostTables.Where(p => p.author == username.ToString()).ToList();
                
                }

               
            
            
        
        
        }


        public bool Delete_Post(int ad_id)
        {

        
                

            using (var db = new UserContext()) {

                var post = db.PostTables.FirstOrDefault(p => p.Id == ad_id);

                db.PostTables.Remove(post);
                db.SaveChanges();

            }


            return true;
        }
    }
}
