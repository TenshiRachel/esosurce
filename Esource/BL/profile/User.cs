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
        public string passSalt { get; set; }
        public string bio { get; set; }
        public string profile_src { get; set; }
        public string type { get; set; }
        public string stripeId { get; set; }
        public int following { get; set; }
        public int followers { get; set; }
        public string website { get; set; }
        public string birthday { get; set; }
        public string gender { get; set; }
        public string location { get; set; }
        public string occupation { get; set; }
        public string social { get; set; }
        public string resetToken { get; set; }
        public string resetTokenExpiry { get; set; }
        public string paymentToken { get; set; }
        public string paymentTokenExpiry { get; set; }

        public User()
        {

        }

        public User(string username, string email, string password, string passSalt, string bio, string profile_src, string type, string stripeId = "", int following = 0, int followers = 0, string social = ",,,,", string website = "Not Set", string birthday = "Not Set", string gender = "Not Set", string location = "Not Set", string occupation = "Not Set", string resetToken = "",
            string resetTokenExpiry = "", string paymentToken = "", string paymentTokenExpiry = "", int Id = -1)
        {
            this.username = username;
            this.email = email;
            this.password = password;
            this.passSalt = passSalt;
            this.bio = bio;
            this.profile_src = profile_src;
            this.type = type;
            this.stripeId = stripeId;
            this.Id = Id;
            this.following = following;
            this.followers = followers;
            this.website = website;
            this.birthday = birthday;
            this.gender = gender;
            this.location = location;
            this.occupation = occupation;
            this.social = social;
            this.resetToken = resetToken;
            this.resetTokenExpiry = resetTokenExpiry;
            this.paymentToken = paymentToken;
            this.paymentTokenExpiry = paymentTokenExpiry;
        }

        public int AddUser()
        {
            int result = new UserDAO().Insert(this);
            return result;
        }

        public int UpdateStripe(string id, string stripeId)
        {
            int result = new UserDAO().UpdateStripeId(id, stripeId);
            return result;
        }

        public int UpdateFollowing(string id, int follows)
        {
            int result = new UserDAO().UpdateFollowing(id, follows);
            return result;
        }

        public int UpdateFollower(string id, int follows)
        {
            int result = new UserDAO().UpdateFollower(id, follows);
            return result;
        }

        public User SelectById(string id)
        {
            User user = new UserDAO().SelectById(id);
            return user;
        }

        public User SelectByEmail(string email)
        {
            User user = new UserDAO().SelectByEmail(email);
            return user;
        }

        public int UpdateUser(string id, string bio, string profile_src, string website, string birthday, string gender, string location, string occupation, string social)
        {
            int result = new UserDAO().Update(id, bio, profile_src, website, birthday, gender, location, occupation, social);
            return result;
        }

        public int UpdatePassword(string password, string passSalt, string id)
        {
            int result = new UserDAO().UpdatePassword(password, passSalt, id);
            return result;
        }

        public int UpdateReset(string id, string token, string expiry)
        {
            int result = new UserDAO().UpdateReset(id, token, expiry);
            return result;
        }

        public int UpdatePaymentToken(string id, string token, string expiry)
        {
            int result = new UserDAO().UpdatePaymentToken(id, token, expiry);
            return result;
        }

        public bool CheckTokenValid(string type, string token, string expiry)
        {
            bool valid = new UserDAO().CheckTokenValid(type, token, expiry);
            return valid;
        }
    }
}