using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.profile;
using Esource.BL.jobs;

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
                    List<Jobs> jobs = new Jobs().SelectByCid(LblUid.Value);
                    reqlist.DataSource = jobs;
                    reqlist.DataBind();

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

        public void toast(Page page, string message, string title, string type)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
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
                string jobId = e.CommandArgument.ToString();
                int result = new Jobs().UpdateStatus(jobId, "cancelled");
                if (result == 0)
                {
                    toast(this, "An error occured while cancelling request", "Error", "error");
                }
                else
                {
                    toast(this, "Request cancelled", "Success", "success");
                }
            }
        }

        protected void reqlist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField statusField = (HiddenField)e.Item.FindControl("status");
            string status = statusField.Value;
            if (status == "accepted")
            {
                e.Item.FindControl("btnPay").Visible = true;
            }
            if (status == "pending")
            {
                e.Item.FindControl("btnCancel").Visible = true;
            }
            if (status == "paid")
            {
                e.Item.FindControl("await").Visible = true;
            }
            if (status == "done")
            {
                e.Item.FindControl("completed").Visible = true;
            }
        }
    }
}