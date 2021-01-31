using Esource.BL.profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.service;
using Esource.Utilities;
using System.IO;

namespace Esource.Views
{
    public partial class index : System.Web.UI.Page
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
                List<BL.service.Service> services = new BL.service.Service().OrderedSelectAll("favs");
                topServiceFavs.DataSource = services;
                topServiceFavs.DataBind();
                services = new BL.service.Service().OrderedSelectAll("views");
                topViewServ.DataSource = services;
                topViewServ.DataBind();
            }
            if (topServiceFavs.Items.Count < 1)
            {
                servFavErr.Visible = true;
            }
            if (topViewServ.Items.Count < 1)
            {
                servViewsSection.Attributes["class"] = servViewsSection.Attributes["class"] + " d-flex align-items-center";
                servViewsDiv.Attributes["class"] = "flex-fill mt-4";
                servViewsDiv.Attributes["style"] = "z-index-1;";
                servViewErr.Visible = true;
            }
        }

        protected void topServiceFavs_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "viewprofile")
            {
                Response.Redirect("~/Views/profile/view.aspx?id=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "fav")
            {
                favourite(e.CommandArgument.ToString());
                List<BL.service.Service> services = new BL.service.Service().OrderedSelectAll("favs");
                topServiceFavs.DataSource = services;
                topServiceFavs.DataBind();
            }
            if (e.CommandName == "view")
            {
                Response.Redirect("~/Views/service/index.aspx?id=" + e.CommandArgument.ToString());
            }
        }

        protected void topViewServ_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "viewprofile")
            {
                Response.Redirect("~/Views/profile/view.aspx?id=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "fav")
            {
                favourite(e.CommandArgument.ToString());
                List<BL.service.Service> services = new BL.service.Service().OrderedSelectAll("views");
                topViewServ.DataSource = services;
                topViewServ.DataBind();
            }
            if (e.CommandName == "view")
            {
                Response.Redirect("~/Views/service/index.aspx?id=" + e.CommandArgument.ToString());
            }
        }

        public void favourite(string sid)
        {
            if (Session["uid"] != null)
            {
                string currUserId = Session["uid"].ToString();
                List<string> userFavs = new Fav().SelectUserFavs(currUserId);
                List<BL.service.Service> serv = new BL.service.Service().SelectById(sid);
                if (!userFavs.Contains(sid))
                {
                    new BL.service.Service().Favourite(sid, serv[0].favs + 1);
                    Fav fav = new Fav(int.Parse(currUserId), int.Parse(sid));
                    int result = fav.Add();
                    if (result == 1)
                    {
                        Toast.success(this, "Service favourited");
                    }
                    else
                    {
                        Toast.error(this, "An error occured while favouriting service");
                    }
                }
                else
                {
                    new BL.service.Service().Favourite(sid, serv[0].favs - 1);
                    int result = new Fav().Remove(int.Parse(currUserId), int.Parse(sid));
                    if (result == 1)
                    {
                        Toast.success(this, "Service unfavourited");
                    }
                    else
                    {
                        Toast.error(this, "An error occured while unfavouriting service");
                    }
                }
            }
            else
            {
                Toast.error(this, "You need to be logged in to favourite a service");
            }
        }

        public void renderImages(RepeaterItemEventArgs e)
        {
            Image img = e.Item.FindControl("poster") as Image;
            HiddenField serviceId = (HiddenField)e.Item.FindControl("serviceId");
            HiddenField providerId = (HiddenField)e.Item.FindControl("provider_ID");
            User servProvider = new User().SelectById(providerId.Value);

            string dirPath = "~/Content/uploads/services/" + servProvider.Id + "/";
            string servPath = dirPath + serviceId.Value + ".png";
            if (File.Exists(Server.MapPath(servPath)))
            {
                img.ImageUrl = Page.ResolveUrl(servPath);
            }

            dirPath = "~/Content/uploads/profile/" + servProvider.Id + "/";
            if (File.Exists(Server.MapPath(dirPath) + "profilePic.png")){
                img = e.Item.FindControl("userImg") as Image;
                img.ImageUrl = Page.ResolveUrl(dirPath + "profilePic.png");
                img = e.Item.FindControl("profileImg") as Image;
                img.ImageUrl = Page.ResolveUrl(dirPath + "profilePic.png");
            }

            var occupation = e.Item.FindControl("occupation") as Label;
            var location = e.Item.FindControl("country") as Label;
            var bio = e.Item.FindControl("bio") as Label;
            if (servProvider.occupation == "Not set")
            {
                occupation.Text = servProvider.occupation;
            }
            else
            {
                occupation.Text = "Freelancer";
            }
            if (servProvider.location == "Not set")
            {
                location.Text = servProvider.location;
            }
            if (!string.IsNullOrEmpty(servProvider.bio))
            {
                bio.Text = servProvider.bio;
            }
            else
            {
                bio.Text = "This user needs no introduction";
            }
        }

        protected void topServiceFavs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            renderImages(e);
        }

        protected void topViewServ_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            renderImages(e);
        }
    }
}