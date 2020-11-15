using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.profile;
using Esource.BL.service;
using Esource.Utilities;

namespace Esource.Views.service
{
    public partial class payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["sid"] == null)
            {
                Session["error"] = "Please select a service to pay for";
                Response.Redirect("~/Views/service/index.aspx");
            }
            else if (Session["uid"] == null)
            {
                Session["error"] = "Please log in to pay for service";
                Response.Redirect("~/Views/service/index.aspx");
            }
            else
            {
                LblUid.Text = Session["uid"].ToString();
                User user = new User().SelectById(LblUid.Text);
                client_email.InnerHtml = user.email;
                client_name.InnerHtml = user.username;
                client_avatar.Src = Page.ResolveUrl(user.profile_src);
                if (string.IsNullOrEmpty(user.profile_src))
                {
                    client_avatar.Src = Page.ResolveUrl("~/Content/img/placeholder.jpg");
                }

                string sid = Request.QueryString["sid"].ToString();
                List<BL.service.Service> service = new BL.service.Service().SelectById(sid);
                servprice.InnerHtml =  "$" + service[0].price.ToString();

                User freelancer = new User().SelectById(service[0].uid.ToString());
                freelance_email.InnerHtml = freelancer.email;
                freelance_name.InnerHtml = freelancer.username;
                freelance_avatar.Src = Page.ResolveUrl(freelancer.profile_src);
                if (string.IsNullOrEmpty(freelancer.profile_src))
                {
                    freelance_avatar.Src = Page.ResolveUrl("~/Content/img/placeholder.jpg");
                }
            }
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            string price = servprice.InnerHtml.Replace("$", string.Empty);
            Payment.pay(client_email.InnerHtml, price, freelance_email.InnerHtml);
        }
    }
}