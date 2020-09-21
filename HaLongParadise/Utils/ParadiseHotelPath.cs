using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaLongParadise.Utils
{
    public class ParadiseHotelPath
    {
        /// <summary>
        /// Setup.domain + "Images/Common/avanta.png"
        /// </summary>
        //public static string Admin_Avanta_Default = "../Images/Common/avanta.png";

        public static string Banner_Image_Default = "image/banner.jpg";
        public static string Contact_Image_Default = "image/contact.jpg";
        public static string Category_Image_Default = "image/banner.jpg";

        /// <summary>
        /// Setup.host+ "FilesUpload/Images/Admin"
        /// </summary>
        //public static string Admin_Image_Upload = "FilesUpload/Images/Admin";
        public static string Cate_Image_Upload = "FilesUpload/Category";
        public static string Contact_Image_Upload = "FilesUpload/Contact";
        public static string Banner_Image_Upload = "FilesUpload/Banner";
        public static string Banner_Image_Small_Upload = "FilesUpload/BannerSmall";



        //Link button
        public static string Icon_Show = "/images/show.png";
        public static string Icon_Hide = "/images/hide.png";

        //
        public const string GridView_Hover_Color = "#FFEFD5";
    }
}