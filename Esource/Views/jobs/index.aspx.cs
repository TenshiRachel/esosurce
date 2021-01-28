using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.jobs;
using Esource.BL.profile;
using Esource.BL.notification;
using Esource.Utilities;

namespace Esource.Views.jobs
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["success"] != null)
            {
                Toast.success(this, Session["success"].ToString());
                Session["success"] = null;
            }
            if (Session["uid"] != null)
            {
                LblUid.Text = Session["uid"].ToString();
                User user = new User().SelectById(LblUid.Text);
                if (user.type == "client")
                {
                    Session["error"] = "You need to be a service provider to view jobs";
                    Response.Redirect("~/Views/index.aspx");
                }
                if(Session["authenticated"] == null && !string.IsNullOrEmpty(user.jobPin)) {           
                    Session["error"] = "Please enter your Job PIN to view jobs";
                    Response.Redirect("~/Views/jobs/auth.aspx");
                }
                Session["authenticated"] = null;
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
                    Toast.error(this, "An error occured while accepting job");
                }
                else
                {
                    Notification notif = new Notification(int.Parse(LblUid.Text), freelancer.username, int.Parse(ids[1]), service[0].name, ids[2], "request");
                    notif.AddNotif();
                    bind();
                    Toast.success(this, "Job accepted");
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
                    Toast.error(this, "An error occured while cancelling job");
                }
                else
                {
                    Notification notif = new Notification(int.Parse(LblUid.Text), freelancer.username, int.Parse(ids[1]), service[0].name, ids[2], "req_cancel");
                    notif.AddNotif();
                    bind();
                    Toast.success(this, "Job cancelled");
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
                    Toast.error(this, "An error occured while completing job");
                }
                else
                {
                    Notification notif = new Notification(int.Parse(LblUid.Text), freelancer.username, int.Parse(ids[1]), service[0].name, ids[2], "complete");
                    notif.AddNotif();
                    bind();
                    Toast.success(this, "Job completed");
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