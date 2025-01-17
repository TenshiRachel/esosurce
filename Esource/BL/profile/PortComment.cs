﻿using Esource.DAL.profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Esource.BL.profile
{
    public class PortComment
    {
        public int Id { get; set; }
        public int uid { get; set; }
        public string username { get; set; }
        public string content { get; set; }
        public string date { get; set; }
        public int pid { get; set; }


        public PortComment()
        {

        }

        public PortComment(int uid, string username, string content, int pid, string date = null, int Id = -1)
        {
            this.uid = uid;
            this.username = username;
            this.content = content;
            this.date = date ?? DateTime.Today.ToString("dd/MM/yyyy");
            this.pid = pid;
        }

        public int AddComment()
        {
            int result = new PortCommentDAO().Insert(this);
            return result;
        }

        public List<PortComment> SelectByPid(int pid)
        {
            List<PortComment> comments = new PortCommentDAO().SelectByPid(pid);
            return comments;
        }
    }
}