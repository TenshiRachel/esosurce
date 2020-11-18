using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Esource.DAL.service;

namespace Esource.BL.service
{
    public class Transaction
    {
        public string serviceProvider { get; set; }
        public string service { get; set; }
        public string currency { get; set; }
        public decimal price { get; set; }
        public string date { get; set; }
        public int uid { get; set; }
        public int Id { get; set; }

        public Transaction()
        {

        }

        public Transaction(string serviceProvider, string service, string currency, decimal price, string date, int uid, int Id = -1)
        {
            this.serviceProvider = serviceProvider;
            this.service = service;
            this.currency = currency;
            this.price = price;
            this.date = date;
            this.uid = uid;
            this.Id = Id;
        }

        public int AddTrans()
        {
            int result = new TransactionDAO().Insert(this);
            return result;
        }

        public List<Transaction> SelectByUid(string uid)
        {
            List<Transaction> trans = new TransactionDAO().SelectByUid(uid);
            return trans;
        }
    }
}