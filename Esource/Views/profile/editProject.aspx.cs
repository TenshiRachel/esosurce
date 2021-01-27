using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using Esource.BL.profile;
using Esource.Utilities;

namespace Esource.Views.profile
{
    public partial class editProject : System.Web.UI.Page
    {
        public string currUserId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] == null)
            {
                Session["error"] = "You need to be logged in to edit a project";
                Response.Redirect("~/Views/index.aspx");
            }
            if (Request.QueryString["id"] == null)
            {
                Session["error"] = "Please select a project to edit";
                Response.Redirect("~/Views/profile/index.aspx");
            }
            currUserId = Session["uid"].ToString();
            Portfolio port = new Portfolio().SelectById(int.Parse(Request.QueryString["id"].ToString()));
            title.Value = port.title;
            tbcontent.Value = port.content;
            string[] categories = port.category.Split(' ');
            foreach (ListItem item in cblCat.Items)
            {
                foreach (string category in categories)
                {
                    if (category == item.Value)
                    {
                        item.Selected = true;
                    }
                }
            }
            string coverPath = "~/Content/uploads/profile/" + currUserId + "/projects/" + port.Id + ".png";
            if (File.Exists(Server.MapPath(coverPath)))
            {
                poster.ImageUrl = Page.ResolveUrl(coverPath);
            }
        }

        public bool ValidateInput(string title, string content)
        {
            bool valid = false;
            if (string.IsNullOrEmpty(title))
            {
                Toast.error(this, "Please enter a title");
            }
            else if (string.IsNullOrEmpty(content))
            {
                Toast.error(this, "Please enter some content");
            }
            else
            {
                valid = true;
            }

            return valid;
        }

        public string storeFile(string pid)
        {
            string img_path = "";
            List<string> acceptedTypes = new List<string>() {
                "image/png",
                "image/jpeg",
                "image/jpg"
            };

            if (acceptedTypes.Contains(upPoster.PostedFile.ContentType))
            {
                string fileName = Path.GetFileName(upPoster.FileName);
                string dirPath = Server.MapPath("~/Content/uploads/profile/" + currUserId + "/projects/");
                Directory.CreateDirectory(dirPath);
                upPoster.SaveAs(dirPath + pid + ".png");

                img_path = "~/Content/uploads/profile/" + currUserId + "/projects/" + pid + ".png";
            }

            else
            {
                Toast.error(this, "Only image files are accepted");
            }

            return img_path;
        }

        protected void saveProj_Click(object sender, EventArgs e)
        {
            string categories = "";
            int count = 0;
            foreach (ListItem item in cblCat.Items)
            {
                if (item.Selected)
                {
                    categories += item.Value + " ";
                    count++;
                }
            }

            if (count == 0)
            {
                Toast.error(this, "Please check at least one category");
            }
            if (ValidateInput(title.Value, tbcontent.Value))
            {
                Portfolio port = new Portfolio().SelectById(int.Parse(Request.QueryString["id"].ToString()));
                if (upPoster.HasFile)
                {
                    storeFile(port.Id.ToString());
                }
                int result = new Portfolio().UpdatePortfolio(title.Value, categories, tbcontent.Value, port.Id.ToString());
                if (result == 0)
                {
                    Toast.error(this, "An error occured while updating the project");
                }
                else
                {
                    Session["success"] = "Saved changes successfully";
                    Response.Redirect("~/Views/profile/index.aspx");
                }
            }
        }
    }
}