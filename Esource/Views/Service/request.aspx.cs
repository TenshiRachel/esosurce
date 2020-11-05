using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.profile;

namespace Esource.Views.service
{
    public partial class request : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] != null)
            {
                LblUid.Value = Session["uid"].ToString();
                User curruser = new User().SelectById(LblUid.Value);
                if (curruser.type == "client")
                {
                    if (reqlist.Items.Count > 0)
                    {
                        end.Visible = true;
                    }
                }
                else
                {
                    Session["error"] = "You need to be a client to have requests";
                    Response.Redirect("~/Views/index.aspx");
                }
            }
            else
            {
                Session["error"] = "Please log in to view requests";
                Response.Redirect("~/Views/auth/login.aspx");
            }
        }

        protected void reqlist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "viewprofile")
            {
                Response.Redirect("~/Views/profile/view.aspx?uid=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "pay")
            {
                Response.Redirect("~/Views/service/payment.aspx?sid=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "cancel")
            {

            }
        }
    }
}