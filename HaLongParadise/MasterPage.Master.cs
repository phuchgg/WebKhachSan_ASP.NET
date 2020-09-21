using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HaLongParadise
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Download source code mien phi tai Sharecode.vn
            if (Request.Cookies["UserName"] == null || string.IsNullOrEmpty(Request.Cookies["UserName"].Value))
                Response.Redirect("Login.aspx");
            aUserName.InnerText = Request.Cookies["UserName"].Value;
        }
    }
}