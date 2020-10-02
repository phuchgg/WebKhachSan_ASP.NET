using HaLongParadise.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HaLongParadise
{
    public partial class Home : BasePage
    {
        HaLongParadiseDataContext db = new HaLongParadiseDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadTopHome();
                Contact info = db.Contacts.FirstOrDefault();
                if (info != null)
                {
                    imgHotel.Src = "/" + info.ImageUrl;
                    if (Session["lang"] != null && Session["lang"].ToString() == "en")
                    {
                        txtInfo.Text = info.DescriptionEng;
                    }
                    else
                    {
                        txtInfo.Text = info.Description;
                    }
                }
            }
        }
        void loadTopHome()
        {
            var lst = db.Categories.Where(a => a.IsDisplayMain==true).Take(3).OrderBy(a => a.CategoryOrder);
            rptTopHome.DataSource = lst;
            rptTopHome.DataBind();

        }


    }
}