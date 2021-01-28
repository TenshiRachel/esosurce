using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.profile;
using Esource.BL.jobs;
using Esource.BL.notification;
using Esource.Utilities;

namespace Esource.Views.service
{
    public partial class request : System.Web.UI.Page
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
            
            if (Session["uid"] != null)
            {
                LblUid.Value = Session["uid"].ToString();
                User curruser = new User().SelectById(LblUid.Value);
                if (Session["authenticated"] == null && !string.IsNullOrEmpty(curruser.jobPin))
                {
                    Session["error"] = "Please enter your Job PIN to view jobs";
                    Response.Redirect("~/Views/jobs/auth.aspx");                 
                }
                Session["authenticated"] = null;
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

        protected void reqlist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "viewprofile")
            {
                Response.Redirect("~/Views/profile/view.aspx?uid=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "pay")
            {
                string idList = e.CommandArgument.ToString();
                string[] ids = idList.Split(',');
                Response.Redirect("~/Views/service/payment.aspx?sid=" + ids[0] + "&jid=" + ids[1]);
            }
            if (e.CommandName == "cancel")
            {
                string idList = e.CommandArgument.ToString();
                string[] ids = idList.Split(',');
                User curr = new User().SelectById(LblUid.Value);
                List<BL.service.Service> service = new BL.service.Service().SelectById(ids[2]);
                int result = new Jobs().UpdateStatus(ids[0], "cancelled");
                if (result == 0)
                {

                    Toast.error(this, "An error occured while cancelling request");
                }
                else
                {
                    Notification notif = new Notification(int.Parse(LblUid.Value), curr.username, int.Parse(ids[2]), service[0].name, ids[1], "job_cancel");
                    notif.AddNotif();
                    List<Jobs> jobs = new Jobs().SelectByCid(LblUid.Value);
                    reqlist.DataSource = jobs;
                    reqlist.DataBind();
                    Toast.success(this, "Request cancelled");
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