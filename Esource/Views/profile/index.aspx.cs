using Esource.BL.profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Esource.Views.profile
{
    public partial class index : System.Web.UI.Page
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
            if (Session["uid"] != null)
            {
                LblUid.Text = Session["uid"].ToString();
                User user = new User().SelectById(LblUid.Text);
                bio.InnerHtml = user.bio;
                website.InnerHtml = user.website;
                dob.InnerHtml = user.birthday;
                gender.InnerHtml = user.gender;
                location.InnerHtml = user.location;
                occupation.InnerHtml = user.occupation;
                email.InnerHtml = user.email;
            }
            else
            {
                Session["error"] = "You need to be logged in to edit your profile";
                Response.Redirect("~/Views/index.aspx");
            }
        }

        public void toast(Page page, string message, string title, string type)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }
    }
}