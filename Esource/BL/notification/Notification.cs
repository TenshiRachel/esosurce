using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Esource.DAL.notification;

namespace Esource.BL.notification
{
    public class Notification
    {
        public int Id { get; set; }
        public int uid { get; set; }
        public string username { get; set; }
        public string title { get; set; }
        public int pid { get; set; }
        public string userId { get; set; }
        public string type { get; set; }
        public string date_created { get; set; }
        public string status { get; set; }

        public Notification()
        {

        }

        public Notification(int uid, string username, int pid, string title, string userId, string type, string date_created = null, string status = "", int Id = -1)
        {
            this.uid = uid;
            this.username = username;
            this.pid = pid;
            this.title = title;
            this.userId = userId;
            this.type = type;
            this.date_created = date_created ?? DateTime.Today.ToString("dd/MM/yyyy");
            this.status = status;
            this.Id = Id;
        }

        public int AddNotif()
        {
            int result = new NotificationDAO().Insert(this);
            return result;
        }

        public List<Notification> UserNotifs(string uid, string type)
        {
            List <Notification> notifs = new NotificationDAO().SelectUserNotifs(uid, type);
            return notifs;
        }

        public int GetNotifCount(string uid)
        {
            int count = new NotificationDAO().GetNotifCount(uid);
            return count;
        }

        public int Remove(string id)
        {
            int result = new NotificationDAO().UpdateStatus(id, "deleted");
            return result;
        }

        public int ClearAll(string uid, string type)
        {
            int result = new NotificationDAO().UpdateByType(uid, type, "deleted");
            return result;
        }
    }
}