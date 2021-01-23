using Esource.BL.profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.Utilities;

namespace Esource.Views.auth
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["success"] != null)
            {
                Toast.success(this, Session["success"].ToString());
                Session["success"] = null;
            }
        }

        public bool ValidateInput(string email, string password)
        {
            bool valid = false;
            User user = new User().SelectByEmail(email);
            if (String.IsNullOrEmpty(email))
            {
                Toast.error(this, "Please enter your email");
            }
            else if (String.IsNullOrEmpty(password))
            {
                Toast.error(this, "Please enter your password");
            }
            else if (user == null)
            {
                Toast.error(this, "Incorrect email or password, please try again");
            }
            else
            {
                valid = true;
            }
            return valid;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateInput(email.Value, password.Value))
            {
                User user = new User().SelectByEmail(email.Value);
                string pwd = password.Value.ToString().Trim();

                SHA512Managed hashing = new SHA512Managed();
                string dbHash = user.password;
                string dbSalt = user.passSalt;
                Tuple<string, string> pwdAndSalt = Auth.hash(pwd, dbSalt);

                if (dbHash.Equals(pwdAndSalt.Item1))
                {
                    Session["uid"] = user.Id;
                    Session["success"] = "You have logged in successfully";
                    Response.Redirect("~/Views/index.aspx");
                }
                else
                {
                    Toast.error(this, "Incorrect email or password, please try again");
                }
            }
        }
    }
}