using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using PayPal.AdaptivePayments;
using PayPal.AdaptivePayments.Model;

namespace Esource.Utilities
{
    public static class Payment
    {
        public static void pay(string clientEmail, string amnt, string freelancerEmail)
        {
            ReceiverList receiverList = new ReceiverList();
            receiverList.receiver = new List<Receiver>();

            string[] amount = new string[] { amnt };
            string[] receiverEmail = new string[] { freelancerEmail };

            for (int i = 0; i < amount.Length; i++)
            {
                Receiver rec = new Receiver(Convert.ToDecimal(amount[i]));
                if (receiverEmail[i] != string.Empty)
                {
                    rec.email = receiverEmail[i];
                }

                receiverList.receiver.Add(rec);
            }

            string baseUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            string cancelUrl = baseUrl + "/service/";
            string redUrl = baseUrl + "/service/paymentSuccess/";

            PayRequest request = new PayRequest(new RequestEnvelope("en_US"), "PAY", cancelUrl, "USD", receiverList, redUrl);

            request.senderEmail = clientEmail;

            AdaptivePaymentsService service = null;
            PayResponse response = null;
            try
            {
                Dictionary<string, string> configurationMap = Configuration.GetAcctAndConfig();

                service = new AdaptivePaymentsService(configurationMap);

                response = service.Pay(request);
            }
            catch (System.Exception e)
            {
                return;
            }

            Dictionary<string, string> responseValues = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(response.responseEnvelope.ack == AckCode.FAILURE) &&
                !(response.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                redirectUrl = ConfigurationManager.AppSettings["PAYPAL_REDIRECT_URL"]
                                     + "_ap-payment&paykey=" + response.payKey;
            }
        }
    }
}