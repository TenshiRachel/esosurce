using Esource.BL.profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.service;
using Esource.BL.notification;
using Esource.Utilities;

namespace Esource.Views.profile
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
            if (Session["uid"] != null)
            {
                LblUid.Text = Session["uid"].ToString();
                User user = getCurrUser();
                bio.InnerHtml = user.bio;
                website.InnerHtml = user.website;
                dob.InnerHtml = user.birthday;
                gender.InnerHtml = user.gender;
                location.InnerHtml = user.location;
                occupation.InnerHtml = user.occupation;
                email.InnerHtml = user.email;
                currUsername.InnerHtml = user.username;
                if (user.type == "client")
                {
                    usertype.InnerHtml = "Client";
                }
                followers.InnerHtml = user.followers.ToString();
                following.InnerHtml = user.following.ToString();
                followerTitle.InnerHtml = user.username + "'s followers";
                followingTitle.InnerHtml = user.username + "'s following";
                List<string> userFavs = new Fav().SelectUserFavs(LblUid.Text);
                List<BL.service.Service> servFavs = new List<BL.service.Service>();
                foreach(string favs in  userFavs)
                {
                    List<BL.service.Service> service = new BL.service.Service().SelectById(favs);
                    servFavs.Add(service[0]);
                }
                List < BL.service.Service > services = new BL.service.Service().SelectByUid(LblUid.Text);
                servList.DataSource = services;
                servList.DataBind();
                favList.DataSource = servFavs;
                favList.DataBind();
                List<string> followingIds = new Follow().SelectFollowing(LblUid.Text);
                List<User> usersFollowing = new List<User>();
                foreach(string id in followingIds)
                {
                    User followingUser = new User().SelectById(id);
                    usersFollowing.Add(followingUser);
                }
                followingRepeater.DataSource = usersFollowing;
                followingRepeater.DataBind();
                List<string> followerIds = new Follow().SelectFollowers(LblUid.Text);
                List<User> usersFollower = new List<User>();
                foreach(string id in followerIds)
                {
                    User followerUser = new User().SelectById(id);
                    usersFollower.Add(followerUser);
                }
                followerRepeater.DataSource = usersFollower;
                followerRepeater.DataBind();
                if (followingRepeater.Items.Count == 0)
                {
                    noFollowing.Visible = true;
                }
                if (followerRepeater.Items.Count == 0)
                {
                    noFollower.Visible = true;
                }
                List<Portfolio> portfolios = new Portfolio().SelectByUid(int.Parse(LblUid.Text));
                projects.DataSource = portfolios;
                projects.DataBind();
            }
            else
            {
                Session["error"] = "You need to be logged in to edit your profile";
                Response.Redirect("~/Views/index.aspx");
            }
        }

        public User getCurrUser()
        {
            return new User().SelectById(LblUid.Text);
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
                if (string.IsNullOrEmpty(LblUid.Text))
                {
                    Session["error"] = "Please log in to favourite a service";
                    Response.Redirect("~/Views/auth/login.aspx");
                }

                string serviceId = e.CommandArgument.ToString();
                List<BL.service.Service> service = new BL.service.Service().SelectById(serviceId);
                BL.service.Service curr = new BL.service.Service();
                User curruser = getCurrUser();
                User freelancer = new User().SelectById(service[0].uid.ToString());

                List<string> userfavs = new Fav().SelectUserFavs(LblUid.Text);

                if (!userfavs.Contains(serviceId))
                {
                    int servres = curr.Favourite(serviceId, service[0].favs + 1);
                    Fav fav = new Fav(int.Parse(LblUid.Text), int.Parse(serviceId));
                    int favres = fav.Add();
                    if (favres == 1 && servres == 1)
                    {
                        Notification notif = new Notification(int.Parse(LblUid.Text), curruser.username, service[0].Id, service[0].name, freelancer.Id.ToString(), "fav");
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

        protected void favList_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                if (string.IsNullOrEmpty(LblUid.Text))
                {
                    Session["error"] = "Please log in to favourite a service";
                    Response.Redirect("~/Views/auth/login.aspx");
                }

                string serviceId = e.CommandArgument.ToString();
                List<BL.service.Service> service = new BL.service.Service().SelectById(serviceId);
                BL.service.Service curr = new BL.service.Service();
                User curruser = getCurrUser();
                User freelancer = new User().SelectById(service[0].uid.ToString());

                List<string> userfavs = new Fav().SelectUserFavs(LblUid.Text);

                if (!userfavs.Contains(serviceId))
                {
                    int servres = curr.Favourite(serviceId, service[0].favs + 1);
                    Fav fav = new Fav(int.Parse(LblUid.Text), int.Parse(serviceId));
                    int favres = fav.Add();
                    if (favres == 1 && servres == 1)
                    {
                        Notification notif = new Notification(int.Parse(LblUid.Text), curruser.username, service[0].Id, service[0].name, freelancer.Id.ToString(), "fav");
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
                List<string> userFavs = new Fav().SelectUserFavs(LblUid.Text);
                List<BL.service.Service> servFavs = new List<BL.service.Service>();
                foreach (string favs in userFavs)
                {
                    List<BL.service.Service> serv = new BL.service.Service().SelectById(favs);
                    servFavs.Add(serv[0]);
                }
                favList.DataSource = servFavs;
                favList.DataBind();
            }
        }

        protected void followerRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Response.Redirect("~/Views/profile/view.aspx?id=" + e.CommandArgument.ToString());
        }

        protected void projects_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (projects.Items.Count < 1)
            {
                noProj.Visible = true;
            }
            User currUser = getCurrUser();
            HiddenField projIdField = e.Item.FindControl("projectId") as HiddenField;

            string projectCoverUrl = "~/Content/uploads/profile/" + currUser.Id.ToString() + "/projects/" + projIdField.Value + ".png";
            string pathToFile = Server.MapPath(projectCoverUrl);
            if (System.IO.File.Exists(pathToFile))
            {
                Image projImg = e.Item.FindControl("projCover") as Image;
                projImg.ImageUrl = Page.ResolveUrl(projectCoverUrl);
                projImg = e.Item.FindControl("projModalCover") as Image;
                projImg.ImageUrl = Page.ResolveUrl(projectCoverUrl);
            }

            string profilePicUrl = "~/Content/uploads/profile/" + currUser.Id.ToString() + "/profilePic.png";
            pathToFile = Server.MapPath(profilePicUrl);
            if (System.IO.File.Exists(pathToFile))
            {
                Image profilePic = e.Item.FindControl("profilePic") as Image;
                profilePic.ImageUrl = Page.ResolveUrl(profilePicUrl);
                profilePic = e.Item.FindControl("modal_profilePic") as Image;
                profilePic.ImageUrl = Page.ResolveUrl(profilePicUrl);
            }

            Label LblUsername = e.Item.FindControl("modal_username") as Label;
            LblUsername.Text = currUser.username;
            LblUsername = e.Item.FindControl("modal_username2") as Label;
            LblUsername.Text = currUser.username;
            LblUsername = e.Item.FindControl("formUsername") as Label;
            LblUsername.Text = currUser.username;

            Repeater servicerepeater = e.Item.FindControl("userServices") as Repeater;
            List<BL.service.Service> userServices = new BL.service.Service().SelectByUid(currUser.Id.ToString());
            servicerepeater.DataSource = userServices;
            servicerepeater.DataBind();
            if (userServices.Count < 1)
            {
                e.Item.FindControl("noService").Visible = true;
            }

            Repeater commentrepeater = e.Item.FindControl("comments") as Repeater;
            List<PortComment> comments = new PortComment().SelectByPid(int.Parse(projIdField.Value));
            commentrepeater.DataSource = comments;
            commentrepeater.DataBind();
            if (comments.Count < 1)
            {
                e.Item.FindControl("noComments").Visible = true;
            }
        }

        protected void projects_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                Response.Redirect("~/Views/profile/editProject.aspx?id=" + e.CommandArgument.ToString());
            }
        }

        protected void userServices_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}