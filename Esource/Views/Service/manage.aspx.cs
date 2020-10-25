using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.service;

namespace Esource.Views.service
{
    public partial class manage : System.Web.UI.Page
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
            List<BL.service.Service> uservices = new BL.service.Service().SelectByUid("1");
            managelist.DataSource = uservices;
            managelist.DataBind();
        }

        public void toast(Page page, string message, string title, string type)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        protected void managelist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                Response.Redirect("~/Views/service/edit.aspx?id=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "view")
            {
                Response.Redirect("~/Views/service/index.aspx?id=" + e.CommandArgument.ToString());
            }
        }
    }
}