using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.service;
using Esource.BL.notification;
using Esource.BL.profile;
using Esource.Utilities;
using System.IO;

namespace Esource.Views.Service
{
    public partial class servicelist : System.Web.UI.Page
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
                List<BL.service.Service> services = new BL.service.Service().SelectAll();
                if (services.Count < 1)
                {
                    LbErr.Visible = true;
                }
                servList.DataSource = services;
                servList.DataBind();
                if (Session["uid"] != null)
                {
                    LblUid.Value = Session["uid"].ToString();
                }
            }
        }

        protected void servList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "viewprofile")
            {
                Response.Redirect("~/Views/profile/view.aspx?id=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "view")
            {
                string serviceId = e.CommandArgument.ToString();
                List<BL.service.Service> service = new BL.service.Service().SelectById(serviceId);
                BL.service.Service curr = new BL.service.Service();
                curr.UpdateViews(serviceId, service[0].views + 1);
                Response.Redirect("~/Views/service/index.aspx?id=" + serviceId);
            }
            if (e.CommandName == "favourite")
            {
                if (string.IsNullOrEmpty(LblUid.Value))
                {
                    Session["error"] = "Please log in to favourite a service";
                    Response.Redirect("~/Views/auth/login.aspx");
                }

                string serviceId = e.CommandArgument.ToString();
                List<BL.service.Service> service = new BL.service.Service().SelectById(serviceId);
                BL.service.Service curr = new BL.service.Service();
                User curruser = new User().SelectById(LblUid.Value);
                User freelancer = new User().SelectById(service[0].uid.ToString());
                
                List<string> userfavs = new Fav().SelectUserFavs(LblUid.Value);

                if (!userfavs.Contains(serviceId)) {
                    int servres = curr.Favourite(serviceId, service[0].favs + 1);
                    Fav fav = new Fav(int.Parse(LblUid.Value), int.Parse(serviceId));
                    int favres = fav.Add();
                    if (favres == 1 && servres == 1)
                    {
                        Notification notif = new Notification(int.Parse(LblUid.Value), curruser.username, service[0].Id, service[0].name, freelancer.Id.ToString(), "fav");
                        notif.AddNotif();
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
                    int favres = fav.Remove(int.Parse(LblUid.Value), int.Parse(serviceId));
                    if (favres == 1 && servres == 1)
                    {
                        Toast.success(this, "Service unfavourited");
                    }
                    else
                    {
                        Toast.error(this, "An error occured while unfavouriting the service");
                    }
                }
                List<BL.service.Service> services = new BL.service.Service().SelectAll();
                servList.DataSource = services;
                servList.DataBind();
            }
        }

        protected void servList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField providerId = (HiddenField)e.Item.FindControl("providerId");
            HiddenField serviceId = (HiddenField)e.Item.FindControl("serviceId");
            string dirPath = "~/Content/uploads/profile/" + providerId.Value + "/";
            string servPath = dirPath + serviceId + ".png";
            Image img = e.Item.FindControl("poster") as Image;
            if (File.Exists(Server.MapPath(servPath)))
            {
                img.ImageUrl = Page.ResolveUrl(servPath);
            }
            img = e.Item.FindControl("providerPic") as Image;
            if (File.Exists(Server.MapPath(dirPath) + "profilePic.png"))
            {
                img.ImageUrl = Page.ResolveUrl(dirPath + "profilePic.png");
            }
        }
    }
}