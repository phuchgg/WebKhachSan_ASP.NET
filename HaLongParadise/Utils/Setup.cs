using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaLongParadise.Utils
{
    public class Setup
    {
        public Setup()
        {
        }
        public static string domain = "http://" + HttpContext.Current.Request.ServerVariables.Get("SERVER_NAME") + "/";

        
        //public static string host = "E:/Project/WEBSITE/sharecode/Code/ShareCode/ShareCode/";
        public static string host = HttpContext.Current.Request.MapPath(HttpContext.Current.Request.ApplicationPath.ToString()).Replace('\\', '/');

        // CHÚ Ý KHI ĐẨY NÊN WEB CẦN CẤU HÌNH LẠI ĐƯỜNG DẪN TRONG FILE: \ckeditor\config.js => var path = 'http://' + window.location.hostname;
    }
}