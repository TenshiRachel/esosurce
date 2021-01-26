using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.profile;
using Esource.Utilities;

namespace Esource.Views.jobs
{
    public partial class auth : System.Web.UI.Page
    {
        public string currUserId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["error"] != null)
            {
                Toast.error(this, Session["error"].ToString());
                Session["error"] = null;
            }
            if (Session["uid"] == null)
            {
                Session["error"] = "Please log in to authenticate jobs/requests";
                Response.Redirect("~/Views/index.aspx");
            }
            currUserId = Session["uid"].ToString();
            User user = new User().SelectById(currUserId);
            if (string.IsNullOrEmpty(user.jobPin))
            {
                if (user.type == "client")
                {
                    Response.Redirect("~/Views/service/request.aspx");
                }
                Response.Redirect("~/Views/jobs/index.aspx");
            }
        }
        protected void enterPIN_Click(object sender, EventArgs e)
        {
            User user = new User().SelectById(currUserId);
            if (user.jobPin == jobPin.Value)
            {
                Session["success"] = "PIN accepted";
                if (user.type == "client")
                {
                    Response.Redirect("~/Views/service/request.aspx");
                }
                Response.Redirect("~/Views/jobs/index.aspx");
            }
            else
            {
                Toast.error(this, "Incorrect PIN");
            }
        }
    }
}