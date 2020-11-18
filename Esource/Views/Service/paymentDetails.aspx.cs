using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.profile;
using Esource.BL.service;

namespace Esource.Views.service
{
    public partial class paymentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] != null)
            {
                LblUid.Text = Session["uid"].ToString();
                if (Request.QueryString["tid"] == null)
                {
                    Session["error"] = "Please select a transaction to view";
                    Response.Redirect("~/Views/service/paymentList.aspx");
                }
                else if (trans().uid != int.Parse(LblUid.Text))
                {
                    Session["error"] = "Unauthorized access";
                    Response.Redirect("~/Views/service/paymentList.aspx");
                }
                else
                {
                    provider.InnerHtml = "Service provider:  " + trans().serviceProvider;
                    service.InnerHtml = trans().service;
                    price.InnerHtml = "$" + trans().price + " " + trans().currency;
                    date.InnerHtml = trans().date;
                }
            }
            else
            {
                Session["error"] = "Please log in to view payment details";
                Response.Redirect("~/Views/index.aspx");
            }
            trans();
        }

        public Transaction trans()
        {
            Transaction transaction = new Transaction().SelectById(Request.QueryString["tid"].ToString());
            return transaction;
        }
    }
}