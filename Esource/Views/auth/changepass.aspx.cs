using Esource.BL.profile;
using Esource.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Esource.Views.auth
{
    public partial class changepass : System.Web.UI.Page
    {
        static string password;
        static string salt;
        byte[] Key;
        byte[] IV;

        string currUserId = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] != null)
            {
                currUserId = Session["uid"].ToString();
            }
            else
            {
                Session["error"] = "You need to be logged in to change password";
                Response.Redirect("~/Views/index.aspx");
            }
        }

        protected bool GetHash()
        {
            bool isCorrect = false;
            User user = new User().SelectById(currUserId);
            string pwd = currPass.Value.ToString().Trim();
            
            string dbHash = user.password;
            string dbSalt = user.passSalt;
            
            if (Auth.hash(pwd, dbSalt).Item1 == dbHash)
            {
                isCorrect = true;
            }

            return isCorrect;
        }

        public bool ValidateInput(string currPass, string newPass, string confPass)
        {
            bool valid = false;
            User user = new User().SelectById(currUserId);
            if (String.IsNullOrEmpty(currPass))
            {
                Toast.error(this, "Please enter your current password");
            }
            else if (String.IsNullOrEmpty(newPass))
            {
                Toast.error(this, "Please enter your new password");
            }
            else if (String.IsNullOrEmpty(confPass))
            {
                Toast.error(this, "Please confirm your new password");
            }
            else if (!GetHash())
            {
                Toast.error(this, "Your current password is incorrect");
            }
            else if (newPass.Length < 8)
            {
                Toast.error(this, "Your new password must be 8 characters or longer");
            }
            else if (newPass != confPass)
            {
                Toast.error(this, "The passwords do not match");
            }
            else if (currPass == newPass)
            {
                Toast.error(this, "You must use a different password");
            }
            else
            {
                valid = true;
            }
            return valid;
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (ValidateInput(currPass.Value, newPass.Value, confPass.Value))
            {
                string pwd = newPass.Value.ToString().Trim();
                Tuple<string, string> pwdAndSalt = Auth.hash(pwd);

                int result = new User().UpdatePassword(pwdAndSalt.Item1, pwdAndSalt.Item2, currUserId);
                if (result != 0)
                {
                    Session["success"] = "Your password has been changed successfully";
                    Response.Redirect("~/Views/profile/index.aspx");
                }
                else
                {
                    Toast.error(this, "An error occured while updating password");
                }
            }
        }
    }
}