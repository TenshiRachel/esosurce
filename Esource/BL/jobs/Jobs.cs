﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Esource.DAL.jobs;

namespace Esource.BL.Jobs
{
    public class Jobs
    {
        public int Id { get; set; }
        public int cid { get; set; }
        public int uid { get; set; }
        public int sid { get; set; }
        public string date_created { get; set; }
        public string sName { get; set; }
        public string cName { get; set; }
        public string username { get; set; }
        public string status { get; set; }
        public string remarks { get; set; }
        public decimal price { get; set; }
    }

    public Jobs()
    {

    }

    public Jobs(int Id = -1, int cid, int uid, int sid, string date_created, string sName, string cName, string username, string status = "pending", string remarks, decimal price)
    {
        this.Id = Id;
        this.cid = cid;
        this.uid = uid;
        this.sid = sid;
        this.date_created = date_created;
        this.sName = sName;
        this.cName = cName;
        this.username = username;
        this.status = status;
        this.remarks = remarks;
        this.price = price;
    }

    public int AddJob()
    {
        int result = new JobsDAO().Insert(this);
        return result;
    }

    public List<Jobs> SelectByUid(string uid)
    {
        List<Jobs> jobs = new JobsDAO().SelectByUid(uid);
        return jobs;
    }

    public List<Jobs> SelectByCid(string cid)
    {
        List<Jobs> jobs = new JobsDAO().SelectByCid(cid);
        return jobs;
    }

    public int UpdateStatus(int id, string status)
    {
        int result = new JobsDAO().UpdateStatus(id, status);
        return result;
    }
}