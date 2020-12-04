using Esource.BL.profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Esource.Views.profile
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] != null)
            {
                LblUid.Text = Session["uid"].ToString();
                User user = new User().SelectById(LblUid.Text);
                string [] socialList = user.social.Split(',');
                if (!Page.IsPostBack)
                {
                    bio.Value = user.bio;
                    website.Value = user.website;
                    dob.Value = user.birthday;
                    gender.Value = user.gender;
                    location.Value = user.location;
                    occupation.Value = user.occupation;
                    currUsername.InnerHtml = user.username;
                    if (socialList.Any())
                    {
                        twitter.Value = socialList[0];
                        instagram.Value = socialList[1];
                        facebook.Value = socialList[2];
                        youtube.Value = socialList[3];
                        deviantart.Value = socialList[4];
                    }
                    if (user.type == "client")
                    {
                        usertype.InnerHtml = "Client";
                    }
                }
            }
            else
            {
                Session["error"] = "You need to be logged in to edit your profile";
                Response.Redirect("~/Views/index.aspx");
            }
        }

        public string UpdateSocial(string twitter, string instagram, string facebook, string youtube, string deviantart)
        {
            string social = twitter + "," + instagram + "," + facebook + "," + youtube + "," + deviantart;
            return social;
        }

        protected void updateProfile_Click(object sender, EventArgs e)
        {
            string social = UpdateSocial(twitter.Value, instagram.Value, facebook.Value, youtube.Value, deviantart.Value);
            int result = new User().UpdateUser(LblUid.Text, bio.Value, "", website.Value, dob.Value, gender.Value, location.Value, occupation.Value, social);
            if (result == 1)
            {
                Session["success"] = "Your profile changes have been saved successfully";
                Response.Redirect("~/Views/profile/index.aspx");
            }
            else
            {
                toast(this, "An error occurred while updating profile", "Error", "error");
            }
        }

        public void toast(Page page, string message, string title, string type)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }
    }
}