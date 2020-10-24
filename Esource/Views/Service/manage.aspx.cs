using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.service;

namespace Esource.Views.service
{
    public partial class manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<BL.service.Service> uservices = new BL.service.Service().SelectByUid("1");
            managelist.DataSource = uservices;
            managelist.DataBind();
        }

        protected void managelist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}