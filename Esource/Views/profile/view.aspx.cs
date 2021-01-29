using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.notification;
using Esource.BL.profile;
using Esource.BL.service;
using Esource.Utilities;

namespace Esource.Views.profile
{
    public partial class view : System.Web.UI.Page
    {
        string currUserId = null;
        string targetUserId = null;
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
                    string dirPath = "~/Content/uploads/profile/" + targetUserId + "/";
                    if (File.Exists(Server.MapPath(dirPath) + "banner.png"))
                    {
                        userBanner.ImageUrl = Page.ResolveUrl(dirPath + "banner.png");
                    }
                    if (File.Exists(Server.MapPath(dirPath) + "profilePic.png"))
                    {
                        viewuserProfilePic.ImageUrl = Page.ResolveUrl(dirPath + "profilePic.png");
                    }

                    followers.InnerHtml = user.followers.ToString();
                    following.InnerHtml = user.following.ToString();
                    followerTitle.InnerHtml = user.username + "'s followers";
                    followingTitle.InnerHtml = user.username + "'s following";

                    bool isFollowed = new Follow().isFollowed(currUserId, targetUserId);
                    if (isFollowed)
                    {
                        unfollowButton.Visible = true;
                        followButton.Visible = false;
                    }

                    List<string> userFavs = new Fav().SelectUserFavs(targetUserId);
                    List<BL.service.Service> servFavs = new List<BL.service.Service>();
                    foreach (string favs in userFavs)
                    {
                        List<BL.service.Service> service = new BL.service.Service().SelectById(favs);
                        servFavs.Add(service[0]);
                    }
                    favList.DataSource = servFavs;
                    favList.DataBind();

                    List<BL.service.Service> services = new BL.service.Service().SelectByUid(targetUserId);
                    servList.DataSource = services;
                    servList.DataBind();
                    List<string> followingIds = new Follow().SelectFollowing(targetUserId);
                    List<User> usersFollowing = new List<User>();
                    foreach (string id in followingIds)
                    {
                        User followingUser = new User().SelectById(id);
                        usersFollowing.Add(followingUser);
                    }
                    followingRepeater.DataSource = usersFollowing;
                    followingRepeater.DataBind();
                    List<string> followerIds = new Follow().SelectFollowers(targetUserId);
                    List<User> usersFollower = new List<User>();
                    foreach (string id in followerIds)
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
                    if (!Page.IsPostBack)
                    {
                        List<Portfolio> projs = new Portfolio().SelectByUid(int.Parse(targetUserId));
                        projects.DataSource = projs;
                        projects.DataBind();
                        if (projs.Count < 1)
                        {
                            noProj.Visible = true;
                        }
                    }
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
                    int favres = fav.Remove(int.Parse(currUserId), int.Parse(serviceId));
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
            var img = e.Item.FindControl("poster") as Image;
            HiddenField path = (HiddenField)e.Item.FindControl("img_path");
            img.ImageUrl = Page.ResolveUrl(path.Value);
        }

        protected void projects_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            User targetUser = new User().SelectById(targetUserId);
            User currUser = new User().SelectById(currUserId);
            HiddenField projIdField = e.Item.FindControl("projectId") as HiddenField;

            string projectCoverUrl = "~/Content/uploads/profile/" + targetUser.Id.ToString() + "/projects/" + projIdField.Value + ".png";
            string pathToFile = Server.MapPath(projectCoverUrl);
            if (System.IO.File.Exists(pathToFile))
            {
                Image projImg = e.Item.FindControl("projCover") as Image;
                projImg.ImageUrl = Page.ResolveUrl(projectCoverUrl);
                projImg = e.Item.FindControl("projModalCover") as Image;
                projImg.ImageUrl = Page.ResolveUrl(projectCoverUrl);
            }

            string profilePicUrl = "~/Content/uploads/profile/" + targetUser.Id.ToString() + "/profilePic.png";
            string currUserPic = "~/Content/uploads/profile/" + currUser.Id.ToString() + "/profilePic.png";
            pathToFile = Server.MapPath(profilePicUrl);
            if (System.IO.File.Exists(pathToFile))
            {
                Image profilePic = e.Item.FindControl("profilePic") as Image;
                profilePic.ImageUrl = Page.ResolveUrl(profilePicUrl);
            }

            if (System.IO.File.Exists(Server.MapPath(currUserPic)))
            {
                Image profilePic = e.Item.FindControl("modal_profilePic") as Image;
                profilePic.ImageUrl = Page.ResolveUrl(profilePicUrl);
            }

            Label LblUsername = e.Item.FindControl("modal_username") as Label;
            LblUsername.Text = targetUser.username;
            LblUsername = e.Item.FindControl("modal_username2") as Label;
            LblUsername.Text = targetUser.username;
            LblUsername = e.Item.FindControl("formUsername") as Label;
            LblUsername.Text = currUser.username;

            Portfolio currProj = new Portfolio().SelectById(int.Parse(projIdField.Value));
            string[] usersLiked = currProj.likeslist.Split(',');
            if (usersLiked.Contains(currUserId))
            {
                e.Item.FindControl("likeButton").Visible = false;
                e.Item.FindControl("unlikeButton").Visible = true;
            }

            Repeater servicerepeater = e.Item.FindControl("userServices") as Repeater;
            List<BL.service.Service> userServices = new BL.service.Service().SelectByUid(targetUser.Id.ToString());
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
            if (e.CommandName == "comment")
            {
                TextBox tbcomment = e.Item.FindControl("tbComment") as TextBox;
                if (!string.IsNullOrEmpty(tbcomment.Text))
                {
                    string pid = e.CommandArgument.ToString();
                    User user = new User().SelectById(currUserId);
                    PortComment comment = new PortComment(user.Id, user.username, tbcomment.Text, int.Parse(pid));
                    int result = comment.AddComment();
                    if (result == 0)
                    {
                        Toast.error(this, "An error occured while adding comment");
                    }
                    else
                    {
                        Toast.success(this, "Comment added");
                        Portfolio currPort = new Portfolio().SelectById(int.Parse(pid));
                        new Portfolio().UpdateComm(pid, currPort.comments + 1);
                        if (currPort.uid.ToString() != currUserId)
                        {
                            Notification notif = new Notification(int.Parse(currUserId), user.username, int.Parse(pid), currPort.title, targetUserId, "project");
                            notif.AddNotif();
                        }
                        Repeater commentrepeater = e.Item.FindControl("comments") as Repeater;
                        List<PortComment> comments = new PortComment().SelectByPid(int.Parse(pid));
                        commentrepeater.DataSource = comments;
                        commentrepeater.DataBind();
                    }
                }
                else
                {
                    Toast.error(this, "Please enter a comment");
                }
            }
            if (e.CommandName == "like")
            {
                Portfolio currPort = new Portfolio().SelectById(int.Parse(e.CommandArgument.ToString()));
                User currUser = new User().SelectById(currUserId);
                int result = new Portfolio().UpdateLikes(currPort.likes + 1, currPort.likeslist + currUserId + ",", currPort.Id.ToString());
                if (result == 0)
                {
                    Toast.error(this, "An error occured while liking project");
                }
                else
                {
                    Toast.success(this, "Project liked");
                    Notification notif = new Notification(int.Parse(currUserId), currUser.username, currPort.Id, currPort.title, targetUserId, "project_like");
                    notif.AddNotif();
                    List<Portfolio> projs = new Portfolio().SelectByUid(int.Parse(targetUserId));
                    projects.DataSource = projs;
                    projects.DataBind();
                }
            }
            if (e.CommandName == "unlike")
            {
                Portfolio currPort = new Portfolio().SelectById(int.Parse(e.CommandArgument.ToString()));
                List<string> usersLiked = new List<string>(currPort.likeslist.Split(','));
                usersLiked.Remove(currUserId);
                string final = string.Join(",", usersLiked);
                int result = new Portfolio().UpdateLikes(currPort.likes - 1, final, currPort.Id.ToString());
                if (result == 0)
                {
                    Toast.error(this, "An error occured while unliking project");
                }
                else
                {
                    Toast.success(this, "Project unliked");
                    List<Portfolio> projs = new Portfolio().SelectByUid(int.Parse(targetUserId));
                    projects.DataSource = projs;
                    projects.DataBind();
                }
            }
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
                if (string.IsNullOrEmpty(currUserId))
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
                    int favres = fav.Remove(int.Parse(currUserId), int.Parse(serviceId));
                    if (favres == 1 && servres == 1)
                    {
                        Toast.success(this, "Service unfavourited");
                    }
                    else
                    {
                        Toast.error(this, "An error occured while unfavouriting the service");
                    }
                }
                List<string> userFavs = new Fav().SelectUserFavs(currUserId);
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

        protected void followButton_Click(object sender, EventArgs e)
        {
            User currUser = new User().SelectById(currUserId);
            User viewedUser = new User().SelectById(targetUserId);
            currUser.UpdateFollowing(currUser.Id.ToString(), currUser.following + 1);
            viewedUser.UpdateFollower(viewedUser.Id.ToString(), viewedUser.followers + 1);
            Follow follow = new Follow(currUser.Id, viewedUser.Id);
            follow.Insert();
            Notification notif = new Notification(viewedUser.Id, viewedUser.username, currUser.Id, currUser.username, viewedUser.Id.ToString(), "follow");
            notif.AddNotif();
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

        protected void followerRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Response.Redirect("~/Views/profile/view.aspx?id=" + e.CommandArgument.ToString());
        }

        protected void userServices_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}