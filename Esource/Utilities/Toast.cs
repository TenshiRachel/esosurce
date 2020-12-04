using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Esource.Utilities
{
    public static class Toast
    {
        public static void success(Page page, string message)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','Success','success');", true);
        }

        public static void error(Page page, string message)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','Error','error');", true);
        }
    }
}