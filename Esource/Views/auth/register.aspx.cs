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
using Stripe;

namespace Esource.Views.auth
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["error"] != null)
            {
                Toast.error(this, Session["error"].ToString());
                Session["error"] = null;
            }
            if (Session["success"] != null)
            {
                Toast.success(this, Session["success"].ToString());
                Session["success"] = null;
            }
        }

        public bool ValidateInput(string name, string email, string password, string confirm_password)
        {
            bool valid = false;
            User user = new User().SelectByEmail(email);
            if (String.IsNullOrEmpty(name))
            {
                Toast.error(this, "Please enter a username");
            }
            else if (String.IsNullOrEmpty(email))
            {
                Toast.error(this, "Please enter an email");
            }
            else if (!email.Contains("@"))
            {
                Toast.error(this, "Please enter a valid email");
            }
            else if (String.IsNullOrEmpty(password))
            {
                Toast.error(this, "Please enter a password");
            }
            else if (password.Length < 8)
            {
                Toast.error(this, "Your password must be 8 characters or longer");
            }
            else if (password != confirm_password)
            {
                Toast.error(this, "The passwords do not match");
            }
            else if (user != null)
            {
                Toast.error(this, "Account already exists");
            }
            else
            {
                valid = true;
            }
            return valid;
        }

        public void registerUser(string username, string email, string pwd, string accType)
        {
            byte[] IV = null;
            Tuple<string, string> pwdAndSalt = Auth.hash(pwd);
            RijndaelManaged cipher = new RijndaelManaged();
            cipher.GenerateIV();
            IV = cipher.IV;

            StripeConfiguration.ApiKey = "sk_test_51Hnjg6K2AIXSM7wrvlwz0S8eQSrtxjb7irpnIhvWGSKSsbWJzUymiC3tHbwxYQCumbmK5gC06kRIw7wr1eHEpj6D00CDgHmOpO";
            Customer cust = new Customer();
            CustomerService serv = new CustomerService();
            CustomerCreateOptions options = new CustomerCreateOptions
            {
                Description = username,
                Balance = 5000
            };
            cust = serv.Create(options);

            User user = new User(username, email, pwdAndSalt.Item1, pwdAndSalt.Item2, "", accType, Convert.ToBase64String(IV), Auth.encrypt(cust.Id, IV));
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