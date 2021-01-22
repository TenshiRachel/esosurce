using Esource.BL.profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.Utilities;

namespace Esource.Views.auth
{
    public partial class reset : System.Web.UI.Page
    {
        string currUserId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            bool tokenValid = new User().CheckTokenValid("reset", Request.QueryString["token"].ToString());

            if (!tokenValid)
            {
                Session["error"] = "Token is invalid or has expired";
                Response.Redirect("~/Views/index.aspx");
            }
            else
            {
                currUserId = Request.QueryString["uid"].ToString();
            }
        }

        public bool ValidateInput(string newPass, string confirm)
        {
            bool valid = false;
            if (string.IsNullOrEmpty(newPass))
            {
                Toast.error(this, "Please enter a new password");
            }
            else if (newPass.Length < 8)
            {
                Toast.error(this, "New password must be more than 8 characters or longer");
            }
            else if (newPass != confirm)
            {
                Toast.error(this, "Passwords do not match");
            }
            else
            {
                valid = true;
            }

            return valid;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            if (ValidateInput(password.Value, confirmpass.Value))
            {
                Tuple<string, string> pwdAndSalt = Auth.hash(password.Value);
                int result = new User().UpdatePassword(pwdAndSalt.Item1, pwdAndSalt.Item2, currUserId);
                if (result == 0)
                {
                    Toast.error(this, "An error occured while updating password, please try again");
                }
                else
                {
                    Session["success"] = "Password reset successfully, please log in";
                    Response.Redirect("~/Views/auth/login.aspx");
                }
            }
        }
    }
}