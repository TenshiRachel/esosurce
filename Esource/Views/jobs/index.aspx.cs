using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.jobs;
using Esource.BL.profile;

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
                List<Jobs> jobs = new Jobs().SelectByUid(LblUid.Text);
                joblist.DataSource = jobs;
                joblist.DataBind();
            }
            else
            {
                Session["error"] = "You need to log in to view jobs";
                Response.Redirect("~/Views/index.aspx");
            }
        }

        protected void joblist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

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