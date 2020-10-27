using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.notification;

namespace Esource.Views.notification
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bind();
            }
        }

        public void bind()
        {
            Notification notif = new Notification();
            List<Notification> favnotifs = notif.UserNotifs("1", "fav");
            favs.DataSource = favnotifs;
            favs.DataBind();
            List<Notification> jnotifs = notif.UserNotifs("1", "job");
            jobs.DataSource = jnotifs;
            jobs.DataBind();
            List<Notification> fnotifs = notif.UserNotifs("1", "file");
            files.DataSource = fnotifs;
            files.DataBind();
            List<Notification> rnotifs = notif.UserNotifs("1", "request");
            requests.DataSource = rnotifs;
            requests.DataBind();
        }
    }
}