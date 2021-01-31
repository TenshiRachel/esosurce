using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.service;
using Esource.Utilities;

namespace Esource.Views.service
{
    public partial class manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["success"] != null)
            {
                Toast.success(this, Session["success"].ToString());
                Session["success"] = null;
            }
            if (Session["error"] != null)
            {
                Toast.error(this, Session["error"].ToString());
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
                    Toast.success(this, "Service deleted successfully");
                }
                else
                {
                    Toast.error(this, "An error occured while deleting service");
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
                        Toast.success(this, "Service favourited");
                    }
                    else
                    {
                        Toast.error(this, "An error occured while favouriting the service");
                    }
                }
                else
                {
                    int servres = curr.Favourite(serviceId, service[0].favs - 1);
                    Fav fav = new Fav();
                    int favres = fav.Remove(int.Parse(LblUid.Text), int.Parse(serviceId));
                    if (favres == 1 && servres == 1)
                    {
                        Toast.success(this, "Service unfavourited");
                    }
                    else
                    {
                        Toast.error(this, "An error occured while unfavouriting the service");
                    }
                }
                List<BL.service.Service> services = new BL.service.Service().SelectByUid(LblUid.Text);
                managelist.DataSource = services;
                managelist.DataBind();
            }
        }

        protected void managelist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField providerId = (HiddenField)e.Item.FindControl("providerId");
            HiddenField serviceId = (HiddenField)e.Item.FindControl("serviceId");
            string dirPath = "~/Content/uploads/services/" + providerId.Value + "/";
            string servPath = dirPath + serviceId.Value + ".png";
            Image img = e.Item.FindControl("poster") as Image;
            if (File.Exists(Server.MapPath(servPath)))
            {
                img.ImageUrl = Page.ResolveUrl(servPath);
            }

            dirPath = "~/Content/uploads/profile/" + providerId.Value + "/";
            img = e.Item.FindControl("providerPic") as Image;
            if (File.Exists(Server.MapPath(dirPath) + "profilePic.png"))
            {
                img.ImageUrl = Page.ResolveUrl(dirPath + "profilePic.png");
            }
        }
    }
}