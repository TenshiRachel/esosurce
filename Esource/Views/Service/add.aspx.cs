using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.service;

namespace Esource.Views.service
{
    public partial class add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
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
                toast(this, "Please check at least one category", "Error", "error");
            }
            else if (ValidateInput(tbName.Text, tbDesc.Text, tbPrice.Text))
            {
                categories.Remove(categories.Length - 1);
                string name = tbName.Text;
                string desc = tbDesc.Text;
                decimal price = decimal.Parse(tbPrice.Text);
                BL.service.Service service = new BL.service.Service(name, desc, price, categories, "", 1);
                int result = service.AddService();
                if (result == 0)
                {
                    toast(this, "Error occured while adding service", "Error", "error");
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