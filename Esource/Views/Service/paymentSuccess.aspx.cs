using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.Utilities;
using Esource.BL.profile;
using Esource.BL.jobs;
using Esource.BL.notification;
using Stripe;
using Esource.BL.service;

namespace Esource.Views.service
{
    public partial class paymentSuccess : System.Web.UI.Page
    {
        public string currUserId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] == null)
            {
                Session["error"] = "Unauthorized";
                Response.Redirect("~/Views/index.aspx");
            }
            else
            {
                StripeConfiguration.ApiKey = "sk_test_51Hnjg6K2AIXSM7wrvlwz0S8eQSrtxjb7irpnIhvWGSKSsbWJzUymiC3tHbwxYQCumbmK5gC06kRIw7wr1eHEpj6D00CDgHmOpO";
                currUserId = Session["uid"].ToString();
                User user = new User().SelectById(currUserId);
                User freelancer = new User().SelectById(Request.QueryString["fid"].ToString());
                List<BL.service.Service> service = new BL.service.Service().SelectById(Request.QueryString["sid"].ToString());
                Customer cust = new Customer();
                Customer freelance = new Customer();
                CustomerService serv = new CustomerService();

                if (string.IsNullOrEmpty(user.stripeId))
                {
                    CustomerCreateOptions options = new CustomerCreateOptions
                    {
                        Description = user.username,
                        Balance = 5000
                    };
                    cust = serv.Create(options);
                    user.UpdateStripe(user.Id.ToString(), cust.Id);
                }
                else
                {
                    cust = serv.Get(user.stripeId);
                }
                if (string.IsNullOrEmpty(freelancer.stripeId))
                {
                    CustomerCreateOptions options = new CustomerCreateOptions
                    {
                        Description = freelancer.username,
                        Balance = 5000
                    };
                    freelance = serv.Create(options);
                    user.UpdateStripe(freelancer.Id.ToString(), freelance.Id);
                }
                else
                {
                    freelance = serv.Get(freelancer.stripeId);
                }
                bool tokenValid = new User().CheckTokenValid("payment", Request.QueryString["token"].ToString());

                if (tokenValid)
                {
                    Payment.pay(cust, freelance, service[0].ToString());
                    new Jobs().UpdateStatus(Request.QueryString["jid"].ToString(), "paid");
                    Notification notif = new Notification(user.Id, user.username, int.Parse(Request.QueryString["sid"].ToString()), service[0].name, freelancer.Id.ToString(), "job_paid");
                    notif.AddNotif();
                    Transaction trans = null;
                    trans = new Transaction(freelancer.username, service[0].name, "SGD", service[0].price, user.Id);
                    trans.AddTrans();
                    trans = new Transaction(user.username, service[0].name, "SGD", service[0].price, freelancer.Id);
                    trans.AddTrans();
                    Session["success"] = "Transaction successful";
                    Response.Redirect("~/Views/service/paymentList.aspx");
                }
                else
                {
                    Session["error"] = "Payment token is invalid or has expired";
                    Response.Redirect("~/Views/index.aspx");
                }
            }
        }
    }
}