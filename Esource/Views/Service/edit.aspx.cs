using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.service;
using Esource.BL.profile;
using Esource.Utilities;

namespace Esource.Views.service
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                if (!Page.IsPostBack)
                {
                    if (Session["uid"] != null)
                    {
                        LblUid.Text = Session["uid"].ToString();
                        User user = new User().SelectById(LblUid.Text);
                        if (user.type == "client")
                        {
                            Session["error"] = "You need to be a service provider to edit a service";
                            Response.Redirect("~/Views/index.aspx");
                        }
                        List<BL.service.Service> service = new BL.service.Service().SelectById(Request.QueryString["id"]);
                        if (user.Id != service[0].uid)
                        {
                            Session["error"] = "You are not allowed to edit other's services";
                            Response.Redirect("~/Views/profile/index.aspx");
                        }
                        tbName.Text = service[0].name;
                        tbDesc.Text = service[0].desc;
                        tbPrice.Text = service[0].price.ToString();
                        string posterPath = "~/Content/uploads/services/" + LblUid.Text + "/" + service[0].Id + ".png";
                        if (File.Exists(Server.MapPath(posterPath)))
                        {
                            poster.ImageUrl = Page.ResolveUrl(posterPath);
                        }
                        string[] categories = service[0].categories.Split(' ');
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
                    }
                    else
                    {
                        Session["error"] = "Please log in to edit service";
                        Response.Redirect("~/Views/auth/login.aspx");
                    }
                }
            }
            else
            {
                Session["error"] = "Please select a service to edit";
                Response.Redirect("~/Views/service/manage.aspx");
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

        public void storeFile(string id)
        {
            List<string> acceptedTypes = new List<string>() {
                "image/png",
                "image/jpeg",
                "image/jpg"
            };

            if (acceptedTypes.Contains(upPoster.PostedFile.ContentType))
            {
                string dirPath = Server.MapPath("~/Content/uploads/services/" + LblUid.Text + "/");
                Directory.CreateDirectory(dirPath);
                string imgPath = dirPath + id + ".png";
                if (File.Exists(imgPath))
                {
                    File.Delete(imgPath);
                }
                upPoster.SaveAs(imgPath);
            }

            else
            {
                Toast.error(this, "Only image files are accepted");
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
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
            else if (ValidateInput(tbName.Text, tbDesc.Text, tbPrice.Text))
            {
                categories.Remove(categories.Length - 1);
                int Id = int.Parse(Request.QueryString["id"].ToString());
                List<BL.service.Service> curr = new BL.service.Service().SelectById(Id.ToString());

                BL.service.Service service = new BL.service.Service();
                int result = service.UpdateService(tbName.Text, tbDesc.Text, decimal.Parse(tbPrice.Text), categories, Id);
                if (result == 0)
                {
                    Toast.error(this, "An error occured while updating service");
                }
                else
                {
                    if (upPoster.HasFile)
                    {
                        storeFile(curr[0].Id.ToString());
                    }
                    Session["success"] = "Service updated successfully";
                    Response.Redirect("~/Views/service/manage.aspx");
                }
            }
        }
    }
}