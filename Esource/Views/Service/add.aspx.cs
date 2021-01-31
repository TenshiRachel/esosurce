using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.service;
using Esource.BL.profile;
using System.IO;
using Esource.Utilities;

namespace Esource.Views.service
{
    public partial class add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] == null)
            {
                Session["error"] = "Please log in to add a service";
                Response.Redirect("~/Views/auth/login.aspx");
            }
            else
            {
                LblUid.Text = Session["uid"].ToString();
                User user = new User().SelectById(LblUid.Text);
                if (user.type == "client")
                {
                    Session["error"] = "You need to be a service provider to add a service";
                    Response.Redirect("~/Views/index.aspx");
                }
            }
        }

        public bool ValidateInput(string name, string desc, string price)
        {
            bool valid = false;
            if (String.IsNullOrEmpty(name))
            {
                Toast.error(this, "Please enter a name");
            }
            else if (String.IsNullOrEmpty(desc))
            {
                Toast.error(this, "Please enter a description");
            }
            else if (String.IsNullOrEmpty(price))
            {
                Toast.error(this, "Please enter a price");
            }
            else
            {
                valid = true;
            }
            return valid;
        }

        public string storeFile()
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
                string dirPath = Server.MapPath("~/Content/uploads/services/" + LblUid.Text + "/");
                Directory.CreateDirectory(dirPath);
                upPoster.SaveAs(dirPath + fileName);

                img_path = "~/Content/uploads/services/" + LblUid.Text + "/" + fileName;
            }

            else
            {
                Toast.error(this, "Only image files are accepted");
            }

            return img_path;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
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
            
            if (count == 0) {
                Toast.error(this, "Please check at least one category");
            }
            else if (ValidateInput(tbName.Text, tbDesc.Text, tbPrice.Text))
            {
                categories.Remove(categories.Length - 1);
                string name = tbName.Text;
                string desc = tbDesc.Text;
                decimal price = decimal.Parse(tbPrice.Text);
                string img_path = "~/Content/img/placeholder.jpg";
                if (upPoster.HasFile)
                {
                    img_path = storeFile();
                }
                User curruser = new User().SelectById(LblUid.Text);
                BL.service.Service service = new BL.service.Service(name, desc, price, categories, img_path, curruser.Id, curruser.username);

                int result = service.AddService();
                if (result == 0)
                {
                    Toast.error(this, "Error occured while adding service");
                }
                else
                {
                    Session["success"] = "Service added";
                    Response.Redirect("~/Views/service/manage.aspx");
                }
            }
        }
    }
}