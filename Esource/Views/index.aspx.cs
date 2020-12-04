using Esource.BL.profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.Utilities;

namespace Esource.Views
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["success"] != null)
            {
                Toast.success(this, Session["success"].ToString());
                Session["success"] = null;
            }
            if (Session["error"] != null)
            {
                Toast.error(this, Session["error"].ToString());
                Session["error"] = null;
            }
        }

    }
}