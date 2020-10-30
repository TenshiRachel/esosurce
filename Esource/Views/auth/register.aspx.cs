using Esource.BL.profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Esource.Views.auth
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void toast(Page page, string message, string title, string type)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        public bool ValidateInput(string name, string email, string password, string confirm_password)
        {
            bool valid = false;
            if (String.IsNullOrEmpty(name))
            {
                toast(this, "Please enter a name", "Error", "error");
            }
            else if (String.IsNullOrEmpty(email))
            {
                toast(this, "Please enter an email", "Error", "error");
            }
            else if (String.IsNullOrEmpty(password))
            {
                toast(this, "Please enter a password", "Error", "error");
            }
            else if (password != confirm_password)
            {
                toast(this, "Passwords do not match", "Error", "error");
            }
            else
            {
                valid = true;
            }
            return valid;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (ValidateInput(name.Value, email.Value, password.Value, confirm_password.Value))
            {
                User user = new User(name.Value, email.Value, password.Value, "", "", "client");
                user.AddUser();
                Response.Redirect("login.aspx");
            }
            else
            {
                toast(this, "Missing fields", "Error", "error");
            }
        }
    }
}