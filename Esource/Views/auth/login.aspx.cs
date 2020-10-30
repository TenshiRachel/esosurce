using Esource.BL.profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Esource.Views.auth
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void toast(Page page, string message, string title, string type)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        public bool ValidateInput(string email, string password)
        {
            bool valid = false;
            User user = new User().SelectByEmail(email);
            if (String.IsNullOrEmpty(email))
            {
                toast(this, "Please enter your email.", "Error", "error");
            }
            else if (String.IsNullOrEmpty(password))
            {
                toast(this, "Please enter your password.", "Error", "error");
            }
            else if (user == null)
            {
                toast(this, "Account does not exist, please register.", "Error", "error");
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
                Session["uid"] = user.Id;
                Session["success"] = "You have logged in successfully";
                Response.Redirect("~/Views/index.aspx");
            }
        }
    }
}