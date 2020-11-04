using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.profile;
using Esource.BL.notification;

namespace Esource.Views.Masters
{
    public partial class index : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] != null)
            {
                LblUid.Text = Session["uid"].ToString();
                user();
                notifCount();
            }
        }

        public User user()
        {
            User user = new User().SelectById(LblUid.Text);
            return user;
        }

        public int notifCount()
        {
            int count = new Notification().GetNotifCount(LblUid.Text);
            return count;
        }
    }
}