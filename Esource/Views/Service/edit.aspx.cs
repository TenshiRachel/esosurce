using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.service;
using Esource.BL.profile;

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
                        string posterPath = service[0].img_path;
                        poster.Src = Page.ResolveUrl(posterPath);
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

        public void toast(Page page, string message, string title, string type)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        public bool ValidateInput(string name, string desc, string price)
        {
            bool valid = false;
            if (String.IsNullOrEmpty(name))
            {
                toast(this, "Please enter a name", "Error", "error");
            }
            else if (String.IsNullOrEmpty(desc))
            {
                toast(this, "Please enter a description", "Error", "error");
            }
            else if (String.IsNullOrEmpty(price))
            {
                toast(this, "Please enter a price", "Error", "error");
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
                toast(this, "Only image files are accepted", "Error", "error");
            }

            return img_path;
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
                toast(this, "Please check at least one category", "Error", "error");
            }
            else if (ValidateInput(tbName.Text, tbDesc.Text, tbPrice.Text))
            {
                categories.Remove(categories.Length - 1);
                int Id = int.Parse(Request.QueryString["id"].ToString());
                List<BL.service.Service> curr = new BL.service.Service().SelectById(Id.ToString());
                string img_path = curr[0].img_path;
                if (upPoster.HasFile)
                {
                    img_path = storeFile();
                }
                BL.service.Service service = new BL.service.Service();
                int result = service.UpdateService(tbName.Text, tbDesc.Text, decimal.Parse(tbPrice.Text), categories, img_path, Id);
                if (result == 0)
                {
                    toast(this, "An error occured while updating service", "Error", "error");
                }
                else
                {
                    Session["success"] = "Service updated successfully";
                    Response.Redirect("~/Views/service/manage.aspx");
                }
            }
        }
    }
}