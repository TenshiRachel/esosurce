using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.service;

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
                        List<BL.service.Service> service = new BL.service.Service().SelectById(Request.QueryString["id"]);
                        tbName.Text = service[0].name;
                        tbDesc.Text = service[0].desc;
                        tbPrice.Text = service[0].price.ToString();
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
                BL.service.Service service = new BL.service.Service();
                int result = service.UpdateService(tbName.Text, tbDesc.Text, decimal.Parse(tbPrice.Text), categories, "", Id);
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