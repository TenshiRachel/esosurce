using Esource.BL.profile;
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
    public partial class register : System.Web.UI.Page
    {
        static string finalHash;
        static string salt;
        byte[] Key;
        byte[] IV;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["error"] != null)
            {
                toast(this, Session["error"].ToString(), "Error", "error");
                Session["error"] = null;
            }
        }

        public void toast(Page page, string message, string title, string type)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        public bool ValidateInput(string name, string email, string password, string confirm_password)
        {
            bool valid = false;
            User user = new User().SelectByEmail(email);
            if (String.IsNullOrEmpty(name))
            {
                toast(this, "Please enter a username", "Error", "error");
            }
            else if (String.IsNullOrEmpty(email))
            {
                toast(this, "Please enter an email", "Error", "error");
            }
            else if (!email.Contains("@"))
            {
                toast(this, "Please enter a valid email", "Error", "error");
            }
            else if (String.IsNullOrEmpty(password))
            {
                toast(this, "Please enter a password", "Error", "error");
            }
            else if (password.Length < 8)
            {
                toast(this, "Password must have 8 characters or more", "Error", "error");
            }
            else if (password != confirm_password)
            {
                toast(this, "Passwords do not match", "Error", "error");
            }
            else if (user != null)
            {
                toast(this, "Account already exists", "Error", "error");
            }
            else
            {
                valid = true;
            }
            return valid;
        }

        public void registerUser(string username, string email, string pwd, string accType)
        {
            string pwd_hash = "";
            if (!String.IsNullOrEmpty(password.Value))
            {
                pwd_hash = password.Value.ToString().Trim();
            }
            else if (!String.IsNullOrEmpty(svc_password.Value))
            {
                pwd_hash = svc_password.Value.ToString().Trim();
            }

            //Generate random "salt"
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] saltByte = new byte[8];

            //Fills array of bytes with a cryptographically strong sequence of random values.
            rng.GetBytes(saltByte);
            salt = Convert.ToBase64String(saltByte);

            SHA512Managed hashing = new SHA512Managed();

            string pwdWithSalt = pwd_hash + salt;
            byte[] plainHash = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwd_hash));
            byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));

            finalHash = Convert.ToBase64String(hashWithSalt);

            RijndaelManaged cipher = new RijndaelManaged();
            cipher.GenerateKey();
            Key = cipher.Key;
            IV = cipher.IV;
            pwd = finalHash;

            User user = new User(username, email, pwd, salt, "", "", accType);
            user.AddUser();
            Session["success"] = "Registered successfully";
            Response.Redirect("~/Views/auth/login.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (ValidateInput(name.Value, email.Value, password.Value, confirm_password.Value))
            {
                registerUser(name.Value, email.Value, password.Value, "client");
            }
            if (ValidateInput(svc_name.Value, svc_email.Value, svc_password.Value, svc_confirm_password.Value))
            {
                registerUser(svc_name.Value, svc_email.Value, svc_password.Value, "freelancer");
            }
        }
    }
}