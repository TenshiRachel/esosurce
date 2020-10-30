using System;
using System.Collections.Generic;
using System.Web;
using PayPal.Api;
using Esource.Utilities;

namespace Esource.BL.service
{
    public class Transaction
    {
        public int serviceId { get; set; }
        public string serviceName { get; set; }
        public decimal price { get; set; }
        public int uid { get; set; }
        public Transaction()
        {

        }

        public Transaction(int serviceId, string serviceName, decimal price, int uidn)
        {
            this.serviceId = serviceId;
            this.serviceName = serviceName;
            this.price = price;
            this.uid = uid;
        }

        public string createPayment()
        {
            var apiContext = Configuration.GetAPIContext() ;
            string guid = Convert.ToString((new Random()).Next(100000));
            string baseUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            string redirectUrl = baseUrl + "/Views/service/";
            string cancelUrl = baseUrl + "/Views/service/index.aspx?id=" + this.serviceId;

            RedirectUrls redirectUrls = new RedirectUrls()
            {
                cancel_url = cancelUrl,
                return_url = redirectUrl
            };

            ItemList itemList = new ItemList()
            {
                items = new List<Item>()
            {
                new Item()
                {
                    name = this.serviceName,
                    currency = "USD",
                    price = this.price.ToString(),
                    quantity = "1",
                    sku = "sku"
                }
            }
            };

            Payer payer = new Payer() { payment_method = "paypal" };

            Amount amt = new Amount()
            {
                currency = "USD",
                total = this.price.ToString()
            };

            List<PayPal.Api.Transaction> transactions = new List<PayPal.Api.Transaction>();

            transactions.Add(new PayPal.Api.Transaction()
            {
                description = "Payment for " + this.serviceName,
                amount = amt,
                item_list = itemList
            });

            Payment payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactions,
                redirect_urls = redirectUrls
            };

            var createdPayment = payment.Create(apiContext);

            var links = createdPayment.links.GetEnumerator();

            return createdPayment.id;
        }

        public int Pay(string paymentId, string payerId)
        {
            int result = 1;
            var apiContext = Configuration.GetAPIContext();

            try
            {
                PaymentExecution paymentExecution = new PaymentExecution()
                {
                    payer_id = payerId
                };

                Payment payment = new Payment()
                {
                    id = paymentId
                };

                var executePayment = payment.Execute(apiContext, paymentExecution);
            }
            catch (Exception ex)
            {
                result = 0;
            }

            return result;
        }
    }
}