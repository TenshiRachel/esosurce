using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Esource.Utilities
{
    public static class Configuration
    {
        public static Dictionary<string, string> GetAcctAndConfig()
        {
            Dictionary<string, string> configMap = new Dictionary<string, string>();

            configMap = GetConfig();

            // Signature Credential
            configMap.Add("account1.apiUsername", "sb-ku7dx3700424_api1.business.example.com");
            configMap.Add("account1.apiPassword", "DH6J6HC4R6X5LRGN");
            configMap.Add("account1.apiSignature", "AVO4ngS4QK8KXIH04mEbcSuZHWY4A2wmVkHxabVnpAk8xFZ1fmjp.oZu");
            configMap.Add("account1.applicationId", "APP-80W284485P519543T");


            configMap.Add("sandboxEmailAddress", "joshfreelance@business.example.com");

            return configMap;
        }

        public static Dictionary<string, string> GetConfig()
        {
            Dictionary<string, string> configMap = new Dictionary<string, string>();

            configMap.Add("mode", "sandbox");

            // These values are defaulted in SDK. If you want to override default values, uncomment it and add your value.
            // configMap.Add("connectionTimeout", "5000");
            // configMap.Add("requestRetries", "2");

            return configMap;
        }
    }
}