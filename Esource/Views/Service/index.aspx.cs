using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.service;
using Esource.BL.profile;
using Esource.BL.jobs;
using Esource.BL.notification;

namespace Esource.Views.service
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null) {
                if (!Page.IsPostBack)
                {
                    List<BL.service.Service> service = new BL.service.Service().SelectById(Request.QueryString["id"].ToString());
                    serviceview.DataSource = service;
                    serviceview.DataBind();
                }
            }
            else
            {
                Session["error"] = "Please select a service to view";
                Response.Redirect("~/Views/service/servicelist.aspx");
            }
            if (Session["uid"] != null)
            {
                LblUid.Value = Session["uid"].ToString();
            }
        }

        protected void serviceview_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "request")
            {
                string freelancerId = e.CommandArgument.ToString();
                string serviceId = Request.QueryString["id"].ToString();
                List<BL.service.Service> service = new BL.service.Service().SelectById(serviceId);
                User curruser = new User().SelectById(LblUid.Value);
                User freelancer = new User().SelectById(freelancerId);
                Jobs existjob = new Jobs().SelectByCidSid(curruser.Id.ToString(), service[0].Id.ToString());

                if (int.Parse(freelancerId) == curruser.Id)
                {
                    Session["error"] = "You cannot purchase your own service";
                    Response.Redirect("~/Views/service/servicelist.aspx");
                }

                if (existjob == null)
                {
                    TextBox tbRemark = (TextBox)e.Item.FindControl("tbRemarks");
                    Jobs job = new Jobs(int.Parse(LblUid.Value), int.Parse(freelancerId), int.Parse(serviceId), service[0].name, curruser.username, freelancer.username, tbRemark.Text, service[0].price);
                    int result = job.AddJob();

                    if (result == 0)
                    {
                        Session["error"] = "An error occured while requesting the service";
                        Response.Redirect("~/Views/service/servicelist.aspx");
                    }
                    else
                    {
                        Notification notif = new Notification(int.Parse(LblUid.Value), curruser.username, int.Parse(serviceId), service[0].name, freelancer.Id.ToString(), "job");
                        notif.AddNotif();
                        Session["success"] = "Service requested successfully, please wait for " + freelancer.username + "\\'s response";
                        Response.Redirect("~/Views/service/servicelist.aspx");
                    }
                }
                else
                {
                    Session["error"] = "You cannot request for this service until completion of previous request";
                    Response.Redirect("~/Views/service/servicelist.aspx");
                }

            }
            if (e.CommandName == "viewprofile")
            {
                Response.Redirect("~/Views/profile/view.aspx?id=" + e.CommandArgument.ToString());
            }
        }

        protected void serviceview_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var img = e.Item.FindControl("poster") as Image;
            HiddenField path = (HiddenField)e.Item.FindControl("img_path");
            img.ImageUrl = Page.ResolveUrl(path.Value);

            HiddenField providerField = (HiddenField)e.Item.FindControl("LblFid");
            User freelancer = new User().SelectById(providerField.Value);
            var email = e.Item.FindControl("email") as Label;
            email.Text = freelancer.email;
        }
    }
}