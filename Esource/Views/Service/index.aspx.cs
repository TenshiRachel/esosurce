using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.service;

namespace Esource.Views.service
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null) {
                List<BL.service.Service> service = new BL.service.Service().SelectById(Request.QueryString["id"].ToString());
                serviceview.DataSource = service;
                serviceview.DataBind();
            }
            else
            {
                Session["error"] = "Please select a service to view";
                Response.Redirect("~/Views/service/servicelist.aspx");
            }
        }

        protected void serviceview_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "request")
            {

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
        }
    }
}