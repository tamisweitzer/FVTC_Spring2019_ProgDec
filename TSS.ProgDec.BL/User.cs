using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSS.ProgDec2.PL;

namespace TSS.ProgDec.BL
{
    public class User
    {
        public int Id { get; set; }

        [DisplayName("User Id")]
        public string UserId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Password")]
        public string UserPass { get; set; }

        public User()
        {

        }

        // Useful for logging in 
        public User(string userid, string userpass)
        {
            UserId = userid;
            UserPass = userpass;
        }

        // Useful for creating a user
        public User(string userid, string userpass, string firstname, string lastname)
        {
            UserId = userid;
            FirstName = firstname;
            LastName = lastname;
            UserPass = userpass;
        }

        // Useful for editing a user
        public User(int id, string userid, string userpass, string firstname, string lastname)
        {
            Id = id;
            UserId = userid;
            FirstName = firstname;
            LastName = lastname;
            UserPass = userpass;
        }

        private string GetHash()
        {
            using (var hash = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(UserPass);
                return Convert.ToBase64String(hash.ComputeHash(hashbytes));
            }
        }

        private void Map(tblUser tblUser)
        {
            tblUser.Id = this.Id;
            tblUser.UserId = this.UserId;
            tblUser.FirstName = this.FirstName;
            tblUser.LastName = this.LastName;
            tblUser.UserPass = this.UserPass;
        }

        public void Insert()
        {
            try
            {
                ProgDecEntities dc = new ProgDecEntities();
                tblUser newuser = new tblUser();
                //Id = 1 assumes there are no users yet
                Id = 1;
                // Check ? if no users id=1 : else add 1
                if (dc.tblUsers.Any())
                {
                    Id = dc.tblUsers.Max(u => u.Id) + 1;
                }
                UserPass = GetHash();
                Map(newuser);
                dc.tblUsers.Add(newuser);
                dc.SaveChanges();      
            }
            catch (Exception ex )
            {
                throw ex;
            }
        }

        public bool Login()
        {
            try
            {
                if (!string.IsNullOrEmpty(UserId))
                {
                    if (!string.IsNullOrEmpty(UserPass))
                    {
                        ProgDecEntities dc = new ProgDecEntities();
                        tblUser user = dc.tblUsers.FirstOrDefault(u => UserId == UserId);

                        if ( user != null)
                        {
                            if (user.UserPass == GetHash())
                            {
                                // Successful login
                                FirstName = user.FirstName;
                                LastName = user.LastName;
                                Id = user.Id;
                                return true;
                            }
                            else
                            {
                                throw new Exception("Cannot login with those credentials.");
                            }
                        }
                        else
                        {
                            throw new Exception("User Id could not be found");
                        }
                    }
                    else
                    {
                        throw new Exception("Password needs to be set");
                    }
                }
                else
                {
                    throw new Exception("User id needs to be set");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Seed()
        {
            User user = new User("tami", "maple", "Tami", "Sweitzer");
            user.Insert();
        }
    }
}
