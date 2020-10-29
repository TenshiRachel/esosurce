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
    public partial class payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["sid"] == null)
            {
                Session["error"] = "Please select a service to pay for";
                Response.Redirect("~/Views/service/index.aspx");
            }
            else if (Request.QueryString["uid"] == null)
            {
                Session["error"] = "Please log in to pay for service";
                Response.Redirect("~/Views/service/index.aspx");
            }
            else
            {
                User user = new User();
                string sid = Request.QueryString["sid"].ToString();
                List<BL.service.Service> service = new BL.service.Service().SelectById(sid);
                servprice.InnerText =  "$" + service[0].price.ToString();
            }
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            string payerId = Request.Params["PayerID"];
            string sid = Request.QueryString["sid"];
            string uid = Request.QueryString["uid"];
            List<BL.service.Service> service = new BL.service.Service().SelectById(sid);
            Transaction transaction = new Transaction(int.Parse(sid), service[0].name, service[0].price, int.Parse(uid), "");
            if (string.IsNullOrEmpty(payerId))
            {
                string paymentId = transaction.createPayment();
                Session.Add("guid", paymentId);
            }
            else
            {
                string guid = Request.Params["guid"];

                string paymentId = Session[guid].ToString();
                int result = transaction.Pay(paymentId, payerId);

            }
        }
    }
}