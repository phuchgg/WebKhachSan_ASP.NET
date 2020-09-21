using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
namespace HaLongParadise.Utils
{
    public class ParadiseHotelFile
    {
        private static string strFile = "";
        private static string strExtenSion = "";
        private static string strVideo = "";
        private static string strVideoExtenSion = "";
        private static string strFoder = "";

        public static string StrExtenSion
        {
            get { return strExtenSion; }
            set { strExtenSion = value; }
        }
        public static bool DeleteFileInFck(string strFCK)
        {
            return _DeleteFileInFck(strFCK);
        }
        private static bool _DeleteFileInFck(string strFCK)
        {
            bool havedo = false;
            if (!string.IsNullOrEmpty(strFCK))
            {
                List<string> list = new List<string>();
                string s = strFCK;
                int i = -1, j = 0;
                i = s.IndexOf("<img");
                while (i > -1)
                {
                    s = s.Substring(i);
                    j = s.IndexOf("/>");
                    if (j > -1)
                    {
                        list.Add(s.Substring(0, (j + 2)));
                        s = s.Substring(j + 1);
                    }
                    else
                    {
                        s = s.Substring(1);
                    }
                    i = s.IndexOf("<img");

                }

                if (list.Count > 0)
                {
                    havedo = true;
                    string item = "", path = "";
                    HttpApplication a = new HttpApplication();
                    HttpServerUtility h = null;
                    for (int k = 0; k < list.Count; k++)
                    {
                        i = list[k].IndexOf("src=");
                        if (i != -1)
                        {
                            item = list[k].Substring(i + 5);
                            j = item.IndexOf('"');
                            if (j != -1)
                            {
                                item = item.Substring(0, j);
                                path = h.MapPath(item);
                                if (File.Exists(path))
                                {
                                    File.Delete(path);
                                }
                            }
                        }

                    }

                }
            }
            return havedo;
        }
        public static string StrFile
        {
            get { return strFile; }
            set { strFile = value; }
        }
        public static string StrVideo
        {
            get { return strVideo; }
            set { strVideo = value; }
        }
        public static string StrVideoExtenSion
        {
            get { return strVideoExtenSion; }
            set { strVideoExtenSion = value; }
        }
        public static string StrFoder
        {
            get { return strFoder; }
            set { strFoder = value; }
        }
        public enum StyleFile
        {
            HOUR_MINUTE_SECOND,
            YEAR_MONTH_DAY_SECOND
        }
        public enum StyleFoder
        {
            YEAR_MONTH_DAY, YEAR_MONTH
        }
        /// <summary>
        /// Check is Image file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsFileImage(string fileName)
        {

            try
            {
                string[] strEX = new string[] { ".bmp", ".gif", ".jpeg", ".jpg", ".png" };
                if (strEX.Contains(Path.GetExtension(fileName).ToLower()))
                {
                    strExtenSion = Path.GetExtension(fileName).ToLower();
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }
        public static bool FileVideo(string fileName)
        {
            try
            {
                string[] strEX = new string[] { "7z", "aiff", "asf", "avi", "bmp", "csv", "doc", "fla", "flv", "gif", "gz", "gzip", "jpeg", "jpg", "mid", "mov", "mp3", "mp4", "mpc", "mpeg", "mpg", "ods", "odt", "pdf", "png", "ppt", "pxd", "qt", "ram", "rar", "rm", "rmi", "rmvb", "rtf", "sdc", "sitd", "swf", "sxc", "sxw", "tar", "tgz", "tif", "tiff", "txt", "vsd", "wav", "wma", "wmv", "xls", "xml", "zip" };
                if (strEX.Contains(Path.GetExtension(fileName).ToLower()))
                {
                    strVideoExtenSion = Path.GetExtension(fileName).ToLower();
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;

            }
        }
        /// <summary>
        /// Create foder 
        /// </summary>
        /// <param name="paht"></param>
        public static void CreateFoder(string paht)
        {
            try
            {
                DirectoryInfo dtinfo = new DirectoryInfo(paht);
                if (!dtinfo.Exists)
                {
                    dtinfo.Create();
                }
                StrFoder = paht;

            }
            catch
            {
                StrFoder = "";
            }

        }

        public static void CreateFoder(string paht, string styleFoder)
        {
            try
            {
                if (StyleFoder.YEAR_MONTH_DAY.ToString() == styleFoder)
                {
                    string strFoder1 = paht + "/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day;
                    DirectoryInfo dtinfo = new DirectoryInfo(strFoder1);
                    if (!dtinfo.Exists)
                    {
                        dtinfo.Create();

                    }
                    StrFoder = strFoder1;
                }
                if (StyleFoder.YEAR_MONTH.ToString() == styleFoder)
                {
                    string strFoder1 = paht + "/" + DateTime.Now.Year + "/" + DateTime.Now.Month;
                    DirectoryInfo dtinfo = new DirectoryInfo(strFoder1);
                    if (!dtinfo.Exists)
                    {
                        dtinfo.Create();

                    }
                    StrFoder = strFoder1;
                }

            }
            catch
            {

                StrFoder = "";
            }


        }
        public static void DeleteFile(string path)
        {
            try
            {
                FileInfo file = new FileInfo(path);
                if (file.Exists)
                {
                    file.IsReadOnly = false;
                    file.Delete();
                }
            }
            catch
            {


            }
        }
        public static void CreateFile(string strpath, string styleFile, string strWordEnd)
        {
            try
            {
                string fi = "";
                if (StyleFile.HOUR_MINUTE_SECOND.ToString() == styleFile)
                {
                    while (true)
                    {
                        fi = strpath + "/" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + "_" + strWordEnd;
                        FileInfo file = new FileInfo(fi);
                        if (!file.Exists)
                        {
                            break;

                        }

                    }
                }
                else
                {
                    if (StyleFile.YEAR_MONTH_DAY_SECOND.ToString() == styleFile)
                    {
                        while (true)
                        {
                            fi = strpath + "/" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Second + "_" + strWordEnd;
                            FileInfo file = new FileInfo(fi);
                            if (!file.Exists)
                            {
                                break;

                            }

                        }
                    }

                }
                StrFile = fi;
            }
            catch
            {
                StrFile = "";
            }

        }
        public static string FolderNoSpaces(string strInput)
        {
            try
            {

                string input = strInput.ToLower();
                char[] ch = new char[] 
            { 
                'a','à','ả','ã','á',
                'ạ','ă','ằ','ẳ','ẵ',
                'ắ','ặ','â','ầ','ẩ',
                'ẫ','ấ','ậ','e','è',
                'ẻ','ẽ','é','ẹ','ê',
                'ề','ể','ễ','ế','ệ',
                'i','ì','ỉ','ĩ','í',
                'ị','o','ò','ỏ','õ',
                'ó','ọ','ô','ồ','ổ',
                'ỗ','ố','ộ','ơ','ờ',
                'ở','ỡ','ớ','ợ','u',
                'ù','ủ','ũ','ú','ụ',
                'ư','ừ','ử','ữ','ứ',
                'ự','y','ỳ','ỷ','ỹ',
                'ý','ỵ','d','đ'
            };
                string[] str = new string[] 
            { 
                "a","a","a","a","a",
                 "a","a","a","a","a",
                "a","a","a","a","a",
               "a","a","a","e","e",
                "e","e", "e","e","e",
                 "e","e", "e","e","e",
                "i","i","i","i","i",
                 "i", "o","o","o","o",
                "o","o","o","o","o",
               "o","o","o","o","o",
               "o","o","o","o","u",
               "u","u","u","u","u",
                "u","u","u","u","u",
               "u","y","y","y","y",
               "y","y","d","d"
            };
                string strTmp = "";
                for (int i = 0; i < input.Length; i++)
                {
                    bool ok = false;
                    int index = 0;
                    for (int j = 0; j < ch.GetLength(0); j++)
                    {
                        if (input[i] == ch[j])
                        {
                            index = j;
                            ok = true; break;
                        }

                    }
                    if (ok)
                        strTmp += str[index];
                    else strTmp += input[i];
                }
                // execute Standardized
                string[] strStandar = strTmp.Split(new char[] { ' ' });
                strTmp = "";
                for (int i = 0; i < strStandar.Length; i++)
                {
                    string tmp = strStandar[i];
                    if (i != strStandar.Length - 1)
                        strTmp += tmp[0].ToString().ToUpper() + tmp.Substring(1, tmp.Length - 1) + "-";
                    else strTmp += tmp[0].ToString().ToUpper() + tmp.Substring(1, tmp.Length - 1);
                }
                return strTmp;
            }
            catch
            {

                string strError = DateTime.Now.Year + "-" + DateTime.Now.Month;
                return strError;
            }
        }
        public static string NoSpaces(string strInput)
        {
            try
            {

                string input = strInput.ToLower().Replace(" ", "");
                char[] ch = new char[] 
            { 
                'a','à','ả','ã','á',
                'ạ','ă','ằ','ẳ','ẵ',
                'ắ','ặ','â','ầ','ẩ',
                'ẫ','ấ','ậ','e','è',
                'ẻ','ẽ','é','ẹ','ê',
                'ề','ể','ễ','ế','ệ',
                'i','ì','ỉ','ĩ','í',
                'ị','o','ò','ỏ','õ',
                'ó','ọ','ô','ồ','ổ',
                'ỗ','ố','ộ','ơ','ờ',
                'ở','ỡ','ớ','ợ','u',
                'ù','ủ','ũ','ú','ụ',
                'ư','ừ','ử','ữ','ứ',
                'ự','y','ỳ','ỷ','ỹ',
                'ý','ỵ','d','đ'
            };
                string[] str = new string[] 
            { 
                "a","a","a","a","a",
                 "a","a","a","a","a",
                "a","a","a","a","a",
               "a","a","a","e","e",
                "e","e", "e","e","e",
                 "e","e", "e","e","e",
                "i","i","i","i","i",
                 "i", "o","o","o","o",
                "o","o","o","o","o",
               "o","o","o","o","o",
               "o","o","o","o","u",
               "u","u","u","u","u",
                "u","u","u","u","u",
               "u","y","y","y","y",
               "y","y","d","d"
            };
                string strTmp = "";
                for (int i = 0; i < input.Length; i++)
                {
                    bool ok = false;
                    int index = 0;
                    for (int j = 0; j < ch.GetLength(0); j++)
                    {
                        if (input[i] == ch[j])
                        {
                            index = j;
                            ok = true; break;
                        }

                    }
                    if (ok)
                        strTmp += str[index];
                    else strTmp += input[i];
                }
                return strTmp;
            }
            catch
            {

                return "";
            }
        }

        private static readonly string[] VietnameseSigns = new string[]
         {
          "aAeEoOuUiIdDyY",
          "áàạảãâấầậẩẫăắằặẳẵ",
          "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
          "éèẹẻẽêếềệểễ",
          "ÉÈẸẺẼÊẾỀỆỂỄ",
          "óòọỏõôốồộổỗơớờợởỡ",
          "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
          "úùụủũưứừựửữ",
          "ÚÙỤỦŨƯỨỪỰỬỮ",
          "íìịỉĩ",
          "ÍÌỊỈĨ",
          "đ",
          "Đ",
          "ýỳỵỷỹ",
          "ÝỲỴỶỸ"
         };

        public static string RemoveSign4VietnameseString(string str)
        {

            //Tiến hành thay thế , lọc bỏ dấu cho chuỗi
            str = RemoveReservedCharacters(str);
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }
            return str.ToLower();

        }
        public static string ConvertString(string str)
        {
            return RemoveSign4VietnameseString(str).Replace(' ', '-');

        }
        public static string RemoveReservedCharacters(string strValue)
        {

            char[] ReservedChars = { '/', ':', '*', '?', '"', '<', '>', '|', '&', ',', '(', ')', '-', '.', '%', '$', '#', '@', '!', '~', ';', '+' };

            foreach (char strChar in ReservedChars)
            {
                strValue = strValue.Replace(strChar + "", "");
            }
            //bo dau trang
            while (strValue.Contains("  "))
            {
                strValue = strValue.Replace("  ", " ");
            }
            return strValue;
        }
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;

        }
        public static void ThayDoiKichThuocAnhNho(string StrFoder, string StrFileName, int MaxWidthSideSize, Stream Buffer)
        {

            ThayDoiKichThuocAnh(StrFoder + "/", StrFileName, MaxWidthSideSize, Buffer);
        }
        public static void ThayDoiKichThuocAnh(string ImageSavePath, string fileName,
         int MaxWidthSideSize, Stream Buffer)
        {
            int intNewWidth;
            int intNewHeight;
            System.Drawing.Image imgInput = System.Drawing.Image.FromStream(Buffer);
            ImageCodecInfo myImageCodecInfo;
            myImageCodecInfo = GetEncoderInfo("image/jpeg");
            //
            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            EncoderParameter myEncoderParameter;
            //Giá trị width và height nguyên thủy của ảnh;
            int intOldWidth = imgInput.Width;
            int intOldHeight = imgInput.Height;

            //Kiểm tra xem ảnh ngang hay dọc;
            int intMaxSide;
            /*if (intOldWidth >= intOldHeight)
            {
            intMaxSide = intOldWidth;
            }
            else
            {
            intMaxSide = intOldHeight;
            }*/
            //Để xác định xử lý ảnh theo width hay height thì bạn bỏ note phần trên;
            //Ở đây mình chỉ sử dụng theo width nên gán luôn intMaxSide= intOldWidth; ^^;
            intMaxSide = intOldWidth;
            if (intMaxSide > MaxWidthSideSize)
            {
                //Gán width và height mới.
                double dblCoef = MaxWidthSideSize / (double)intMaxSide;
                intNewWidth = Convert.ToInt32(dblCoef * intOldWidth);
                intNewHeight = Convert.ToInt32(dblCoef * intOldHeight);
            }
            else
            {
                //Nếu kích thước width/height (intMaxSide) cũ ảnh nhỏ hơn MaxWidthSideSize thì giữ nguyên //kích thước cũ;
                intNewWidth = intOldWidth;
                intNewHeight = intOldHeight;
            }

            //Tạo một ảnh bitmap mới;
            Bitmap bmpResized = new Bitmap(imgInput, intNewWidth, intNewHeight);
            //Phần EncoderParameter cho phép bạn chỉnh chất lượng hình ảnh ở đây mình để chất lượng tốt //nhất là 100L;
            myEncoderParameter = new EncoderParameter(myEncoder, 100L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            //Lưu ảnh;
            bmpResized.Save(ImageSavePath + fileName, myImageCodecInfo, myEncoderParameters);

            //Giải phóng tài nguyên;
            //Buffer.Close();
            imgInput.Dispose();
            bmpResized.Dispose();
        }
    }
}