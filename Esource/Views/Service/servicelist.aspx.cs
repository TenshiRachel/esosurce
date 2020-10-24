using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esource.BL.service;

namespace Esource.Views.Service
{
    public partial class servicelist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<BL.service.Service> services = new BL.service.Service().SelectAll();
            servList.DataSource = services;
            servList.DataBind();
        }

        protected void servList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}