using eUseControl.BussinesLogic.DBModel.Seed;
using eUseControl.BussinesLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace eUseControl.BussinesLogic.Core
{
    public class UserApi
    {

        internal bool adAnunce_action(PostTable postTable)
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


        internal List<PostTable> get_posts_action() {


            using (var db = new UserContext()) { 
            
            
            
            return db.PostTables.ToList();
            
            }
        
        
        
        }

        public static string HashPassword(string password)
        {
       
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20); 

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

          
            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            
            byte[] hashBytes = Convert.FromBase64String(storedHash);

          
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

        
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                    return false;
            }

            return true;
        }



        public LoginResult LoginUser_action(ULoginData data)
        {
           var password = HashPassword(data.Password);
            using (var db = new UserContext())
            {
                var user = db.Users.FirstOrDefault(u =>
                    (u.username == data.Username || u.email == data.Username)
                   );

                if (user == null || !VerifyPassword(data.Password, user.password))
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

       

        public RegisterResult RegisterUser_action(ULoginData data)
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

                var password = HashPassword(data.Password);

                var newUser = new UDBTable
                {
                    username = data.Username,
                    password = password,
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


        public List<PostTable> getMyPosts_action(ULoginData data, string username) {

           


            using (var db = new UserContext()) { 

              
           
                
                    return db.PostTables.Where(p => p.author == username.ToString()).ToList();
                
                }

               
            
            
        
        
        }


        internal bool Delete_Post_action(int ad_id)
        {

        
                

            using (var db = new UserContext()) {

                var post = db.PostTables.FirstOrDefault(p => p.Id == ad_id);

                db.PostTables.Remove(post);
                db.SaveChanges();

            }


            return true;
        }


       

        internal bool check_if_favorite_ad_exist(Favorite ad)
        {
            using (var db = new UserContext()) {


                var result = new Favorite();

                result = db.Favorites.FirstOrDefault(

                    p => p.ad_id == ad.ad_id && p.author == ad.author


                    );

                if (result == null) {

                    return true;
                
                
                }
            }


            return false;
        }


        internal bool ad_to_favorites_action(Favorite ad)
        {
            using (var db = new UserContext()) { 
            
            if (check_if_favorite_ad_exist(ad)){
                    db.Favorites.Add(ad);
                    db.SaveChanges();

                }
           
            
            
            }
            return true;

        }


        internal List<PostTable> my_favorites_action(string username) {

      


            using (var db = new UserContext()) {


                var favoritePostIds = db.Favorites
              .Where(f => f.author == username)
              .Select(f => f.ad_id)
              .ToList();

                // Pasul 2: Ia postările corespunzătoare din PostTables
                var favoritePosts = db.PostTables
                    .Where(p => favoritePostIds.Contains(p.Id))
                    .ToList();

                return favoritePosts;

            }
        
        
        }


        internal bool delete_fav_ad_action(int ad_id) {


            using (var db = new UserContext()) {

                var post = new Favorite();

               

              post = db.Favorites.FirstOrDefault(p => p.ad_id == ad_id);

                db.Favorites.Remove(post);
                db.SaveChanges();

                return true;
            
            }

           
        
        
        
        }

        internal bool SaveSession_action(UserSession data)
        {

            using (var db = new UserContext())
            {
                db.UserSessions.Add(data);
                db.SaveChanges();
            }

            return true;
        }
    }
}
