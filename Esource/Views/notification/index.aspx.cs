using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.profile;
using Esource.BL.notification;
using Esource.Utilities;

namespace Esource.Views.notification
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["uid"] != null)
                {
                    LblUid.Value = Session["uid"].ToString();
                    bind();
                    user();
                    showContent();
                }
                else
                {
                    Session["error"] = "Please log in to view notifications";
                    Response.Redirect("~/Views/auth/login.aspx");
                }
            }
        }

        public User user()
        {
            User user = new User().SelectById(LblUid.Value);
            return user;
        }

        public void bind()
        {
            Notification notif = new Notification();
            List<Notification> notiflist = notif.UserNotifs(LblUid.Value, "fav");
            favs.DataSource = notiflist;
            favs.DataBind();
            notiflist = notif.UserNotifs(LblUid.Value, "follow");
            follows.DataSource = notiflist;
            follows.DataBind();
            notiflist = notif.UserNotifs(LblUid.Value, "job");
            jobs.DataSource = notiflist;
            jobs.DataBind();
            notiflist = notif.UserNotifs(LblUid.Value, "job_cancel");
            jobscancel.DataSource = notiflist;
            jobscancel.DataBind();
            notiflist = notif.UserNotifs(LblUid.Value, "job_paid");
            jobpaid.DataSource = notiflist;
            jobpaid.DataBind();
            notiflist = notif.UserNotifs(LblUid.Value, "file");
            files.DataSource = notiflist;
            files.DataBind();
            notiflist = notif.UserNotifs(LblUid.Value, "request");
            requests.DataSource = notiflist;
            requests.DataBind();
            notiflist = notif.UserNotifs(LblUid.Value, "req_cancel");
            reqcancel.DataSource = notiflist;
            reqcancel.DataBind();
            notiflist = notif.UserNotifs(LblUid.Value, "complete");
            reqcomplete.DataSource = notiflist;
            reqcomplete.DataBind();
        }

        public void showContent()
        {
            if (favs.Items.Count > 0)
            {
                favclear.Visible = true;
                favalert.Visible = true;
            }
            if (follows.Items.Count > 0)
            {
                followclear.Visible = true;
                followalert.Visible = true;
            }
            if (jobs.Items.Count > 0 || jobpaid.Items.Count > 0 || jobscancel.Items.Count > 0)
            {
                jobclear.Visible = true;
                jobalert.Visible = true;
            }
            if (files.Items.Count > 0)
            {
                fileclear.Visible = true;
                falert.Visible = true;
            }
            if (requests.Items.Count > 0 || reqcomplete.Items.Count > 0 || reqcancel.Items.Count > 0)
            {
                reqclear.Visible = true;
                ralert.Visible = true;
            }
        }

        public void clear(string id)
        {
            Notification notif = new Notification();
            int result = notif.Remove(id);
            if (result == 1)
            {
                Toast.success(this, "Notification cleared successfully");
                bind();
            }
            else
            {
                Toast.error(this, "An error occured while removing notification");
            }
        }

        protected void favs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer && favs.Items.Count < 1)
            {
                favErr.Visible = true;
            }
        }

        protected void jobs_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "viewprofile")
            {
                Response.Redirect("~/Views/profile/view.aspx?id=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "viewservice")
            {
                Response.Redirect("~/Views/service/index.aspx?id=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "viewjob")
            {
                Response.Redirect("~/Views/jobs/index.aspx");
            }
            if (e.CommandName == "clear")
            {
                clear(e.CommandArgument.ToString());
            }
        }

        protected void jobs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (jobs.Items.Count < 1 && jobpaid.Items.Count < 1 && jobscancel.Items.Count < 1)
            {
                jobErr.Visible = true;
            }
        }

        protected void files_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "viewprofile")
            {
                Response.Redirect("~/Views/profile/view.aspx?id=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "viewfile")
            {
                Response.Redirect("~/Views/file/index.aspx");
            }
            if (e.CommandName == "clear")
            {
                clear(e.CommandArgument.ToString());
            }
        }

        protected void files_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer && files.Items.Count < 1)
            {
                fileErr.Visible = true;
            }
        }

        protected void requests_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (requests.Items.Count < 1 && reqcancel.Items.Count < 1 && reqcomplete.Items.Count < 1)
            {
                reqErr.Visible = true;
            }
        }

        protected void clearAll(object sender, CommandEventArgs e)
        {
            Notification notif = new Notification();
            string typelist = e.CommandArgument.ToString();
            string[] types = typelist.Split(',');

            foreach(string type in types)
            {
                int result = notif.ClearAll(LblUid.Value, type);
                if (result == 1)
                {
                    Toast.success(this, "Notifications cleared successfully");
                }
                else
                {
                    Toast.error(this, "An error occured while removing notifications");
                }
            }
            bind();
            
        }

        protected void common_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "viewprofile")
            {
                Response.Redirect("~/Views/profile/view.aspx?id=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "viewservice")
            {
                Response.Redirect("~/Views/service/index.aspx?id=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "clear")
            {
                clear(e.CommandArgument.ToString());
            }
        }

        protected void follows_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "viewprofile")
            {
                Response.Redirect("~/Views/profile/view.aspx?id=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "clear")
            {
                clear(e.CommandArgument.ToString());
            }
        }

        protected void follows_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer && follows.Items.Count < 1)
            {
                followErr.Visible = true;
            }
        }
    }
}