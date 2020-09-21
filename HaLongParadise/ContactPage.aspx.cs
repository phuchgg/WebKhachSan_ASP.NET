using HaLongParadise.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HaLongParadise
{
    public partial class ContactPage : BasePage
    {
        HaLongParadiseDataContext db = new HaLongParadiseDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Contact info = db.Contacts.FirstOrDefault();
                if (info != null)
                {
                    if (Session["lang"] != null && Session["lang"].ToString() == "en")
                    {
                        ltrContact.Text = info.ContactDetailEng;
                    }
                    else
                    {
                        ltrContact.Text = info.ContactDetail;
                    }
                 
  
                }
            }
        }
     
    }
}