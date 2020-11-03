using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.service;

namespace Esource.Views.Service
{
    public partial class servicelist : System.Web.UI.Page
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
            if (!Page.IsPostBack)
            {
                List<BL.service.Service> services = new BL.service.Service().SelectAll();
                if (services.Count < 1)
                {
                    LbErr.Visible = true;
                }
                servList.DataSource = services;
                servList.DataBind();
            }
        }

        public void toast(Page page, string message, string title, string type)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
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
                string serviceId = e.CommandArgument.ToString();
                List<BL.service.Service> service = new BL.service.Service().SelectById(serviceId);
                BL.service.Service curr = new BL.service.Service();
                List<string> userfavs = new Fav().SelectUserFavs("1");
                if (!userfavs.Contains(serviceId)) {
                    int servres = curr.Favourite(serviceId, service[0].favs + 1);
                    Fav fav = new Fav(1, int.Parse(serviceId));
                    int favres = fav.Add();
                    if (favres == 1 && servres == 1)
                    {
                        toast(this, "Service favourited", "Success", "success");
                    }
                    else
                    {
                        toast(this, "An error occured while favouriting the service", "Error", "error");
                    }
                }
                else
                {
                    int servres = curr.Favourite(serviceId, service[0].favs - 1);
                    Fav fav = new Fav();
                    int favres = fav.Remove(1, int.Parse(serviceId));
                    if (favres == 1 && servres == 1)
                    {
                        toast(this, "Service unfavourited", "Success", "success");
                    }
                    else
                    {
                        toast(this, "An error occured while unfavouriting the service", "Error", "error");
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
    }
}