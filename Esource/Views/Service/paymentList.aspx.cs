using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.profile;
using Esource.BL.service;
using Esource.Utilities;

namespace Esource.Views.service
{
    public partial class paymentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["success"] != null)
            {
                Toast.success(this, Session["success"].ToString());
                Session["success"] = null;
            }
            if (Session["error"] != null)
            {
                Toast.error(this, Session["error"].ToString());
                Session["error"] = null;
            }
            if (Session["uid"] == null)
            {
                Session["error"] = "Please log in to view payment details";
                Response.Redirect("~/Views/index.aspx");
            }
            else
            {
                LblUid.Text = Session["uid"].ToString();
                User user = new User().SelectById(LblUid.Text);
                if (user.type == "freelancer")
                {
                    provider.InnerHtml = "Client";
                }

                List<Transaction> trans = new Transaction().SelectByUid(LblUid.Text);
                translist.DataSource = trans;
                translist.DataBind();
            }
        }

        protected void translist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "details")
            {
                Response.Redirect("~/Views/service/paymentDetails.aspx?tid=" + e.CommandArgument.ToString());
            }
        }

        protected void translist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (translist.Items.Count > 0)
            {
                end.Visible = true;
            }
        }
    }
}