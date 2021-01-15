using Esource.BL.profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
    }
}