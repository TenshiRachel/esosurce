using Esource.BL.profile;
using Esource.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Esource.Views.profile
{
    public partial class addProject : System.Web.UI.Page
    {
        public string currUserId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] == null)
            {
                Session["error"] = "Please log in to add a project";
                Response.Redirect("~/Views/index.aspx");
            }
            currUserId = Session["uid"].ToString();
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

        public bool storeTemp()
        {
            List<string> acceptedTypes = new List<string>() {
                "image/png",
                "image/jpeg",
                "image/jpg"
            };

            if (acceptedTypes.Contains(upPoster.PostedFile.ContentType))
            {
                string dirPath = Server.MapPath("~/Content/uploads/services/" + currUserId + "/");
                Directory.CreateDirectory(dirPath);
                upPoster.SaveAs(dirPath + "temp.png");
                return true;
            }

            else
            {
                Toast.error(this, "Only image files are accepted");
                return false;
            }
        }

        public void storeFile(string pid)
        {
            List<string> acceptedTypes = new List<string>() {
                "image/png",
                "image/jpeg",
                "image/jpg"
            };

            if (acceptedTypes.Contains(upPoster.PostedFile.ContentType))
            {
                string dirPath = Server.MapPath("~/Content/uploads/services/" + currUserId + "/");
                if (File.Exists(dirPath + "temp.png"))
                {
                    File.Copy(dirPath + "temp.png", dirPath + pid + ".png");
                    File.Delete(dirPath + "temp.png");
                }
            }

            else
            {
                Toast.error(this, "Only image files are accepted");
            }
        }

        protected void submitProj_Click(object sender, EventArgs e)
        {
            string categories = "";
            int count = 0;
            bool valid = true;
            int result = 0;

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
                User user = new User().SelectById(currUserId);
                Portfolio port = new Portfolio(user.Id, title.Value, categories, tbcontent.Value, "");

                if (upPoster.HasFile)
                {
                    valid = storeTemp();
                }

                if (valid)
                {
                    result = port.AddPortfolio();
                }

                if (upPoster.HasFile)
                {
                    storeFile(result.ToString());
                }

                if (result == 0)
                {
                    Toast.error(this, "An error occured while adding project");
                }
                else
                {
                    if (upPoster.HasFile)
                    {
                        storeFile(result.ToString());
                    }
                    Session["success"] = "Project created successfully";
                    Response.Redirect("~/Views/profile/index.aspx");
                }
            }
        }
    }
}