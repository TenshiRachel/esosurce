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
            if (!Page.IsPostBack)
            {
                if (Session["uid"] != null)
                {
                    LblUid.Text = Session["uid"].ToString();
                    List<BL.service.Service> uservices = new BL.service.Service().SelectByUid(LblUid.Text);
                    if (uservices.Count < 1)
                    {
                        LbErr.Visible = true;
                    }
                    managelist.DataSource = uservices;
                    managelist.DataBind();
                }
                else
                {
                    Session["error"] = "Please log in to manage services";
                    Response.Redirect("~/Views/auth/login/aspx");
                }
            }
        }

        public void toast(Page page, string message, string title, string type)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        protected void managelist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "viewprofile")
            {
                Response.Redirect("~/Views/profile/index.aspx");
            }
            if (e.CommandName == "edit")
            {
                Response.Redirect("~/Views/service/edit.aspx?id=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "delete")
            {
                int result = new BL.service.Service().Delete(e.CommandArgument.ToString());
                if (result == 1)
                {
                    toast(this, "Service deleted successfully", "Success", "success");
                }
                else
                {
                    toast(this, "An error occured while deleting service", "Error", "error");
                }
                List<BL.service.Service> services = new BL.service.Service().SelectByUid(LblUid.Text);
                managelist.DataSource = services;
                managelist.DataBind();
            }
            if (e.CommandName == "view")
            {
                Response.Redirect("~/Views/service/index.aspx?id=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "favourite")
            {
                string serviceId = e.CommandArgument.ToString();
                List<BL.service.Service> service = new BL.service.Service().SelectById(serviceId);
                BL.service.Service curr = new BL.service.Service();
                List<string> userfavs = new Fav().SelectUserFavs(LblUid.Text);
                if (!userfavs.Contains(serviceId))
                {
                    int servres = curr.Favourite(serviceId, service[0].favs + 1);
                    Fav fav = new Fav(int.Parse(LblUid.Text), int.Parse(serviceId));
                    int favres = fav.Add();
                    if (favres == 1 && servres == 1)
                    {
                        toast(this, "Service favourited", "Success", "success");
                    }
                    else
                    {
                        toast(this, "An error occured while favouriting the service", "Error", "error");
                    }
                }
                else
                {
                    int servres = curr.Favourite(serviceId, service[0].favs - 1);
                    Fav fav = new Fav();
                    int favres = fav.Remove(int.Parse(LblUid.Text), int.Parse(serviceId));
                    if (favres == 1 && servres == 1)
                    {
                        toast(this, "Service unfavourited", "Success", "success");
                    }
                    else
                    {
                        toast(this, "An error occured while unfavouriting the service", "Error", "error");
                    }
                }
                List<BL.service.Service> services = new BL.service.Service().SelectByUid(LblUid.Text);
                managelist.DataSource = services;
                managelist.DataBind();
            }
        }

        protected void managelist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var img = e.Item.FindControl("poster") as Image;
            HiddenField path = (HiddenField)e.Item.FindControl("img_path");
            img.ImageUrl = Page.ResolveUrl(path.Value);
        }
    }
}