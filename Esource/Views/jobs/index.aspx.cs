using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.jobs;
using Esource.BL.profile;
using Esource.BL.notification;

namespace Esource.Views.jobs
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] != null)
            {
                LblUid.Text = Session["uid"].ToString();
                User user = new User().SelectById(LblUid.Text);
                if (user.type == "client")
                {
                    Session["error"] = "You need to be a service provider to view jobs";
                    Response.Redirect("~/Views/index.aspx");
                }
                if (!Page.IsPostBack)
                {
                    bind();
                }
            }
            else
            {
                Session["error"] = "You need to log in to view jobs";
                Response.Redirect("~/Views/index.aspx");
            }
        }

        public void bind()
        {
            List<Jobs> jobs = new Jobs().SelectByUid(LblUid.Text);
            joblist.DataSource = jobs;
            joblist.DataBind();
        }

        public void toast(Page page, string message, string title, string type)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        protected void joblist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "viewprofile")
            {
                Response.Redirect("~/Views/profile/view.aspx?id=" + e.CommandArgument.ToString());
            }

            if (e.CommandName == "accept")
            {
                string idList = e.CommandArgument.ToString();
                string[] ids = idList.Split(',');
                User freelancer = new User().SelectById(LblUid.Text);
                List<BL.service.Service> service = new BL.service.Service().SelectById(ids[1]);
                int result = new Jobs().UpdateStatus(ids[0], "accepted");
                if (result == 0)
                {
                    Notification notif = new Notification(int.Parse(LblUid.Text), freelancer.username, int.Parse(ids[1]), service[0].name, ids[2], "request");
                    notif.AddNotif();
                    bind();
                    toast(this, "An error occured while accepting job", "Error", "error");
                }
                else
                {
                    toast(this, "Job accepted", "Success", "success");
                }
            }

            if (e.CommandName == "reject")
            {
                string idList = e.CommandArgument.ToString();
                string[] ids = idList.Split(',');
                User freelancer = new User().SelectById(LblUid.Text);
                List<BL.service.Service> service = new BL.service.Service().SelectById(ids[1]);
                int result = new Jobs().UpdateStatus(ids[0], "cancelled");
                if (result == 0)
                {
                    Notification notif = new Notification(int.Parse(LblUid.Text), freelancer.username, int.Parse(ids[1]), service[0].name, ids[2], "req_cancel");
                    notif.AddNotif();
                    bind();
                    toast(this, "An error occured while cancelling job", "Error", "error");
                }
                else
                {
                    toast(this, "Job cancelled", "Success", "success");
                }
            }

            if(e.CommandName == "submit")
            {
                string idList = e.CommandArgument.ToString();
                string[] ids = idList.Split(',');
                User freelancer = new User().SelectById(LblUid.Text);
                List<BL.service.Service> service = new BL.service.Service().SelectById(ids[1]);
                int result = new Jobs().UpdateStatus(ids[0], "done");
                if (result == 0)
                {
                    Notification notif = new Notification(int.Parse(LblUid.Text), freelancer.username, int.Parse(ids[1]), service[0].name, ids[2], "complete");
                    notif.AddNotif();
                    bind();
                    toast(this, "An error occured while completing job", "Error", "error");
                }
                else
                {
                    toast(this, "Job completed", "Success", "success");
                }
            }
        }

        protected void joblist_ItemDataBound(object source, RepeaterItemEventArgs e)
        {
            if (joblist.Items.Count > 0)
            {
                end.Visible = true;
            }
            HiddenField statusField = (HiddenField)e.Item.FindControl("status");
            string status = statusField.Value;
            if (status == "pending")
            {
                e.Item.FindControl("btnAccept").Visible = true;
                e.Item.FindControl("btnReject").Visible = true;
            }
            if(status == "paid")
            {
                e.Item.FindControl("btnSubmit").Visible = true;
            }
            if(status == "accepted")
            {
                e.Item.FindControl("await").Visible = true;
            }
            if(status == "completed")
            {
                e.Item.FindControl("completed").Visible = true;
            }
        }
    }
}