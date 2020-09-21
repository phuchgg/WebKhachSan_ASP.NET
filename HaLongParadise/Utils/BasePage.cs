using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace HaLongParadise.Utils
{
    public class BasePage : System.Web.UI.Page
    {
        protected override void InitializeCulture()
        {
            string culture = string.Empty;
            if (Session["lang"] == null || (Session["lang"] != null && Session["lang"].ToString() == "vi"))
            {
                culture = "";
            }
            else
            {
                culture = "en";
            }
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            base.InitializeCulture();
        }
    }
}
