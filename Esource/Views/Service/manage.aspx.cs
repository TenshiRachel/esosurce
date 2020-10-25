using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.service;

namespace Esource.Views.service
{
    public partial class manage : System.Web.UI.Page
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
                List<BL.service.Service> uservices = new BL.service.Service().SelectByUid("1");
                managelist.DataSource = uservices;
                managelist.DataBind();
            }
        }

        public void toast(Page page, string message, string title, string type)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        protected void managelist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                Response.Redirect("~/Views/service/edit.aspx?id=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "delete")
            {
                int result = new BL.service.Service().Delete(e.CommandArgument.ToString());
                if (result == 1)
                {
                    toast(this, "Service deleted successfully", "Success", "success");
                }
                else
                {
                    toast(this, "An error occured while deleting service", "Error", "error");
                }
                List<BL.service.Service> services = new BL.service.Service().SelectByUid("1");
                managelist.DataSource = services;
                managelist.DataBind();
            }
            if (e.CommandName == "view")
            {
                Response.Redirect("~/Views/service/index.aspx?id=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "favourite")
            {
                string serviceId = e.CommandArgument.ToString();
                List<BL.service.Service> service = new BL.service.Service().SelectById(serviceId);
                BL.service.Service curr = new BL.service.Service();
                List<string> userfavs = new Fav().SelectUserFavs("1");
                if (!userfavs.Contains(serviceId))
                {
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
                List<BL.service.Service> services = new BL.service.Service().SelectByUid("1");
                managelist.DataSource = services;
                managelist.DataBind();
            }
        }

        protected void managelist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer && managelist.Items.Count < 1)
            {
                e.Item.FindControl("LbErr").Visible = true;
            }
        }
    }
}