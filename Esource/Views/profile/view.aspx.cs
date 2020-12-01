using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.notification;
using Esource.BL.profile;
using Esource.BL.service;

namespace Esource.Views.profile
{
    public partial class view : System.Web.UI.Page
    {
        string currUserId = null;
        string targetUserId = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["error"] != null)
            {
                toast(this, Session["error"].ToString(), "Error", "error");
                Session["error"] = null;
            }
            if (Session["success"] != null)
            {
                toast(this, Session["success"].ToString(), "Success", "success");
                Session["success"] = null;
            }
            if (Session["uid"] != null)
            {
                currUserId = Session["uid"].ToString();
                if (Request.QueryString["id"] != null)
                {
                    targetUserId = Request.QueryString["id"].ToString();
                    if (currUserId == targetUserId)
                    {
                        Response.Redirect("~/Views/profile/index.aspx");
                    }
                    User user = new User().SelectById(targetUserId);
                    bio.InnerHtml = user.bio;
                    website.InnerHtml = user.website;
                    dob.InnerHtml = user.birthday;
                    gender.InnerHtml = user.gender;
                    location.InnerHtml = user.location;
                    occupation.InnerHtml = user.occupation;
                    email.InnerHtml = user.email;
                    viewUsername.InnerHtml = user.username;
                    if (user.type == "client")
                    {
                        viewUsertype.InnerHtml = "Client";
                    }
                    bool isFollowed = new Follow().isFollowed(targetUserId, currUserId);
                    if (isFollowed)
                    {
                        unfollowButton.Visible = true;
                        followButton.Visible = false;
                    }

                    List<BL.service.Service> services = new BL.service.Service().SelectByUid(targetUserId);
                    servList.DataSource = services;
                    servList.DataBind();
                }
                else
                {
                    Session["error"] = "Please select a profile to view";
                    Response.Redirect("~/Views/profile/index.aspx");
                }
            }
            else
            {
                Session["error"] = "Please log in to view other's profile";
                Response.Redirect("~/Views/index.aspx");
            }
        }

        public void toast(Page page, string message, string title, string type)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        protected void servList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
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
                if (string.IsNullOrEmpty(targetUserId))
                {
                    Session["error"] = "Please log in to favourite a service";
                    Response.Redirect("~/Views/auth/login.aspx");
                }

                string serviceId = e.CommandArgument.ToString();
                List<BL.service.Service> service = new BL.service.Service().SelectById(serviceId);
                BL.service.Service curr = new BL.service.Service();
                User curruser = new User().SelectById(currUserId);
                User freelancer = new User().SelectById(service[0].uid.ToString());

                List<string> userfavs = new Fav().SelectUserFavs(currUserId);

                if (!userfavs.Contains(serviceId))
                {
                    int servres = curr.Favourite(serviceId, service[0].favs + 1);
                    Fav fav = new Fav(int.Parse(currUserId), int.Parse(serviceId));
                    int favres = fav.Add();
                    if (favres == 1 && servres == 1)
                    {
                        Notification notif = new Notification(int.Parse(currUserId), curruser.username, service[0].Id, service[0].name, freelancer.Id.ToString(), "fav");
                        notif.AddNotif();
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
                    int favres = fav.Remove(int.Parse(currUserId), int.Parse(serviceId));
                    if (favres == 1 && servres == 1)
                    {
                        toast(this, "Service unfavourited", "Success", "success");
                    }
                    else
                    {
                        toast(this, "An error occured while unfavouriting the service", "Error", "error");
                    }
                }
                List<BL.service.Service> services = new BL.service.Service().SelectAll();
                servList.DataSource = services;
                servList.DataBind();
            }
        }

        protected void servList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var img = e.Item.FindControl("poster") as Image;
            HiddenField path = (HiddenField)e.Item.FindControl("img_path");
            img.ImageUrl = Page.ResolveUrl(path.Value);
        }

        protected void followButton_Click(object sender, EventArgs e)
        {
            User currUser = new User().SelectById(currUserId);
            User viewedUser = new User().SelectById(targetUserId);
            currUser.UpdateFollowing(currUser.Id.ToString(), currUser.following + 1);
            viewedUser.UpdateFollower(viewedUser.Id.ToString(), viewedUser.followers + 1);
            Follow follow = new Follow(currUser.Id, viewedUser.Id);
            follow.Insert();
            Session["success"] = viewedUser.username + " followed";
            Response.Redirect("~/Views/profile/view.aspx?id=" + viewedUser.Id);
        }

        protected void unfollowButton_Click(object sender, EventArgs e)
        {
            User currUser = new User().SelectById(currUserId);
            User viewedUser = new User().SelectById(targetUserId);
            currUser.UpdateFollowing(currUser.Id.ToString(), currUser.following - 1);
            viewedUser.UpdateFollower(viewedUser.Id.ToString(), viewedUser.followers - 1);
            new Follow().Remove(currUser.Id.ToString(), viewedUser.Id.ToString());
            Session["success"] = viewedUser.username + " unfollowed";
            Response.Redirect("~/Views/profile/view.aspx?id=" + viewedUser.Id);
        }
    }
}