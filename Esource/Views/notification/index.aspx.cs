﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.notification;

namespace Esource.Views.notification
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bind();
                showContent();
            }
        }

        public void bind()
        {
            Notification notif = new Notification();
            List<Notification> favnotifs = notif.UserNotifs("1", "fav");
            favs.DataSource = favnotifs;
            favs.DataBind();
            List<Notification> jnotifs = notif.UserNotifs("1", "job");
            jobs.DataSource = jnotifs;
            jobs.DataBind();
            List<Notification> fnotifs = notif.UserNotifs("1", "file");
            files.DataSource = fnotifs;
            files.DataBind();
            List<Notification> rnotifs = notif.UserNotifs("1", "request");
            requests.DataSource = rnotifs;
            requests.DataBind();
        }

        public void showContent()
        {
            if (favs.Items.Count > 0)
            {
                favclear.Visible = true;
                favalert.Visible = true;
            }
            if (jobs.Items.Count > 0)
            {
                jobclear.Visible = true;
                jobalert.Visible = true;
            }
            if (files.Items.Count > 0)
            {
                fileclear.Visible = true;
                falert.Visible = true;
            }
            if (requests.Items.Count > 0)
            {
                reqclear.Visible = true;
                ralert.Visible = true;
            }
        }

        public void toast(Page page, string message, string title, string type)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        public void clear(string id)
        {
            Notification notif = new Notification();
            int result = notif.Remove(id);
            if (result == 1)
            {
                toast(this, "Notification cleared successfully", "Success", "success");
            }
            else
            {
                toast(this, "An error occured while removing notification", "Error", "error");
            }
        }

        protected void favs_ItemCommand(object source, RepeaterCommandEventArgs e)
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

        protected void favs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer && favs.Items.Count < 1)
            {
                e.Item.FindControl("LbErr").Visible = true;
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
                Response.Redirect("~/Views/job/index.aspx");
            }
            if (e.CommandName == "clear")
            {
                clear(e.CommandArgument.ToString());
            }
        }

        protected void jobs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer && jobs.Items.Count < 1)
            {
                e.Item.FindControl("LbErr").Visible = true;
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
                Response.Redirect("~/Views/file/index.aspx?id=" + e.CommandArgument.ToString());
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
                e.Item.FindControl("LbErr").Visible = true;
            }
        }

        protected void requests_ItemCommand(object source, RepeaterCommandEventArgs e)
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

        protected void requests_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer && requests.Items.Count < 1)
            {
                e.Item.FindControl("LbErr").Visible = true;
            }
        }

        protected void clearAll(object sender, CommandEventArgs e)
        {
            Notification notif = new Notification();
            int result = notif.ClearAll("1", e.CommandArgument.ToString());
            if (result == 1)
            {
                toast(this, "Notifications cleared successfully", "Success", "success");
            }
            else
            {
                toast(this, "An error occured while removing notifications", "Error", "error");
            }
        }
    }
}