using Esource.BL.profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Esource.Views.profile
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void updateProfile_Click(object sender, EventArgs e)
        {
            //User user = new User().UpdateUser();
            Session["success"] = "Your profile changes have been saved successfully";
            Response.Redirect("~/Views/profile/index.aspx");
        }
    }
}