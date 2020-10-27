using Esource.DAL.profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Esource.BL.profile
{
    public class User
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string bio { get; set; }
        public string profile_src { get; set; }
        public string type { get; set; }

        public User()
        {

        }

        public User(string username, string email, string password, string bio, string profile_src, string type, int Id = -1)
        {
            this.username = username;
            this.email = email;
            this.password = password;
            this.bio = bio;
            this.profile_src = profile_src;
            this.type = type;
            this.Id = Id;
        }

        public int AddUser()
        {
            int result = new UserDAO().Insert(this);
            return result;
        }
    }
}