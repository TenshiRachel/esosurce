using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Esource.Utilities
{
    public static class Payment
    {
        public static void pay(Customer cust, Customer freelancer, string price)
        {
            CustomerBalanceTransactionCreateOptions custTrans = new CustomerBalanceTransactionCreateOptions
            {
                Currency = "sgd",
                Amount = long.Parse("-" + price)
            };
            CustomerBalanceTransactionService balanceService = new CustomerBalanceTransactionService();
            balanceService.Create(cust.Id, custTrans);

            CustomerBalanceTransactionCreateOptions freeTrans = new CustomerBalanceTransactionCreateOptions
            {
                Currency = "sgd",
                Amount = long.Parse(price)
            };
            balanceService.Create(freelancer.Id, freeTrans);
        }
    }
}