﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.profile;
using Esource.BL.service;
using Esource.BL.jobs;
using Esource.BL.notification;
using Esource.Utilities;
using Stripe;

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
            if (Request.QueryString["jid"] == null)
            {
                Session["error"] = "Please select a request to pay for";
                Response.Redirect("~/Views/service/request.aspx");
            }
            else if (Session["uid"] == null)
            {
                Session["error"] = "Please log in to pay for service";
                Response.Redirect("~/Views/service/index.aspx");
            }
            else
            {
                LblUid.Text = Session["uid"].ToString();
                LblJid.Text = Request.QueryString["jid"].ToString();
                User user = new User().SelectById(LblUid.Text);
                if (user.type == "freelancer")
                {
                    Session["error"] = "You need to be a client to pay for a service";
                    Response.Redirect("~/Views/service/index.aspx");
                }
                Jobs job = new Jobs().SelectById(LblJid.Text);
                if (job.status == "paid")
                {
                    Session["error"] = "Request has already been paid";
                    Response.Redirect("~/Views/service/index.aspx");
                }
                client_email.InnerHtml = user.email;
                client_name.InnerHtml = user.username;
                string dirPath = "~/Content/uploads/profile/" + user.Id + "/";
                if (System.IO.File.Exists(Server.MapPath(dirPath + "profilePic.png")))
                {
                    clientAvatar.ImageUrl = Page.ResolveUrl(dirPath + "profilePic.png");
                }
                if (System.IO.File.Exists(Server.MapPath(dirPath + "banner.png")))
                {
                    clientBanner.ImageUrl = Page.ResolveUrl(dirPath + "banner.png");
                }

                string sid = Request.QueryString["sid"].ToString();
                List<BL.service.Service> service = new BL.service.Service().SelectById(sid);
                servprice.InnerHtml =  "$" + service[0].price.ToString();

                User freelancer = new User().SelectById(service[0].uid.ToString());
                freelance_email.InnerHtml = freelancer.email;
                freelance_name.InnerHtml = freelancer.username;
                dirPath = "~/Content/uploads/profile/" + freelancer.Id + "/";
                if (System.IO.File.Exists(Server.MapPath(dirPath + "profilePic.png")))
                {
                    freelanceAvatar.ImageUrl = Page.ResolveUrl(dirPath + "profilePic.png");
                }
                if (System.IO.File.Exists(Server.MapPath(dirPath + "banner.png")))
                {
                    freelanceBanner.ImageUrl = Page.ResolveUrl(dirPath + "banner.png");
                }
            }
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            User user = new User().SelectById(LblUid.Text);
            string sid = Request.QueryString["sid"].ToString();
            List<BL.service.Service> service = new BL.service.Service().SelectById(sid);
            User freelancer = new User().SelectById(service[0].uid.ToString());

            string price = servprice.InnerHtml.Replace("$", string.Empty);
            string token = Auth.generateToken();
            new User().UpdatePaymentToken(user.Id.ToString(), Auth.encrypt(token, Convert.FromBase64String(user.IV)), (DateTime.Now.AddHours(1).Ticks).ToString());
            string link = "https://localhost:44309/Views/service/paymentSuccess.aspx?sid=" + sid + "&fid=" + freelancer.Id + "&jid=" + Request.QueryString["jid"].ToString() + "&token=" + token;
            Email.Send(user.email, user.username, "Outsource Service payment",
                "<p>You are receiving this because you (or someone else) is trying to pay for a service on Outsource.</p>" +
                "<p>Service Name: " + service[0].name + "</p>" +
                "<p>Price: $" + service[0].price + "</p>" +
                "<p>Please click on the following link or paste it into your browser to complete the payment.</p>" +
                "<a href='" + link + "'>" + link + "</a>" +
                "<p>If you did not request this, please ignore this email and your balance will not be deducted.</p>");
            Toast.success(this, "A confirmation email has been sent to your email account");
        }
    }
}