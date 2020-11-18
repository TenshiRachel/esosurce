using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.profile;
using Esource.BL.service;

namespace Esource.Views.service
{
    public partial class paymentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["success"] != null)
            {
                toast(this, Session["success"].ToString(), "Success", "success");
                Session["success"] = null;
            }
            if (Session["error"] != null)
            {
                toast(this, Session["error"].ToString(), "Error", "error");
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

                List<Transaction> trans = new Transaction().SelectByUid(LblUid.Text);
                translist.DataSource = trans;
                translist.DataBind();
            }
        }

        public void toast(Page page, string message, string title, string type)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
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