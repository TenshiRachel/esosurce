using Esource.BL.profile;
using Esource.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Esource.Views.auth
{
    public partial class forgot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnForgot_Click(object sender, EventArgs e)
        {
            User user = new User().SelectByEmail(email.Value);
            if (user != null)
            {
                string token = Auth.generateToken();
                new User().UpdateReset(user.Id.ToString(), Auth.encrypt(token, Convert.FromBase64String(user.IV)), (DateTime.Now.Ticks + 3600000).ToString());
                string link = "https://localhost:44309/Views/auth/reset.aspx?uid=" + user.Id.ToString() + "&token=" + token;
                Email.Send(user.email, user.username, "Outsource Reset password",
                    "<p>You are receiving this because you (or someone else) have requested the reset of the password for your account.</p>" +
                    "<p>Please click on the following link, or paste this into your browser to complete the process:</p>" +
                    "<a href='" + link + "'>" + link + "</a>" +
                    "<p>If you did not request this, please ignore this email and your password will remain unchanged..</p>");
                Toast.success(this, "A confirmation email has been sent to your email account. Click the link in it to complete the process");
            }
            else
            {
                Toast.error(this, "Invalid credentials, please try again");
            }
        }
    }
}