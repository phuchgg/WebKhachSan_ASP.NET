using HaLongParadise.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HaLongParadise
{
    public partial class AddNews : System.Web.UI.Page
    {
        HaLongParadiseDataContext db = new HaLongParadiseDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            messError.Visible = false;
            messSuccess.Visible = false;
            errTitle.Visible = false;
            errSubTitle.Visible = false;
            errDetail.Visible = false;
            errImage.Visible = false;

            if (!IsPostBack)
            {
                //Set maxlength cho texbox dạng multiline
                txtTitle.Attributes.Add("maxlength", txtTitle.MaxLength.ToString());
                txtSubTitle.Attributes.Add("maxlength", txtSubTitle.MaxLength.ToString());
                //Load chuyen muc
                LoadChuyenMuc();
                ddlCategory.SelectedIndex = 0;
                //Download source code mien phi tai Sharecode.vn
            }
        }

        #region Method

        /// <summary>
        /// Kiểm tra ràng buộc trước khi thêm
        /// </summary>
        /// <returns></returns>
        bool CheckCondition()
        {
            var kt = true;
            try
            {

                if (!fulImage.HasFile)
                {
                    messError.Visible = true;
                    errImage.Visible = true;
                    kt = false;
                }
                if (fckDetail.Text == "")
                {
                    messError.Visible = true;
                    errDetail.Visible = true;

                    kt = false;
                }




                if (txtSubTitle.Text == "")
                {
                    messError.Visible = true;
                    errSubTitle.Visible = true;
                    txtSubTitle.Focus();
                    kt = false;
                }
                if (txtTitle.Text == "")
                {
                    messError.Visible = true;
                    errTitle.Visible = true;
                    txtTitle.Focus();
                    kt = false;
                }
            }
            catch (Exception)
            {

            }
            return kt;
        }
        void Clear()
        {
            txtTitle.Text = "";
            txtSubTitle.Text = "";
            fckDetail.Text = "";

            messError.Visible = false;
            messSuccess.Visible = false;
            errTitle.Visible = false;
            errSubTitle.Visible = false;
            errDetail.Visible = false;
            errImage.Visible = false;

        }
        #endregion
        /// <summary>
        /// Hủy bỏ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        /// <summary>
        /// Thêm mới tin tức
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //try
            //{

            //    if (CheckCondition())
            //    {
            //        var cn = new New();
            //        cn.Title = txtTitle.Text;
            //        cn.Summary = txtSubTitle.Text;
            //        cn.Content = fckDetail.Text;
            //        cn.Date = DateTime.Now;
            //        cn.IsShow = chkShow.Checked ? true : false;
            //        cn.CategoryId = int.Parse(ddlCategory.SelectedValue);
            //        string accountName = "hoang";//Response.Cookies["UserName"].Value;
            //        cn.AccountId = db.Accounts.SingleOrDefault(c => c.AccountName.Equals(accountName)).AccountId;
            //        // xu ly anh

            //        if (fulImage.HasFile)
            //        {
            //            if (ParadiseHotelFile.IsFileImage(fulImage.FileName))
            //            {
            //                ParadiseHotelFile.CreateFoder(Setup.host + ParadiseHotelPath.News_Image_Upload);
            //                if (ParadiseHotelFile.StrFoder != "")
            //                {
            //                    ParadiseHotelFile.CreateFile(ParadiseHotelFile.StrFoder,
            //                                         ParadiseHotelFile.StyleFile.HOUR_MINUTE_SECOND.ToString(),
            //                                         fulImage.FileName);

            //                    if (ParadiseHotelFile.StrFile != "")
            //                    {
            //                        fulImage.PostedFile.SaveAs(ParadiseHotelFile.StrFile);

            //                        cn.ImageUrl = ParadiseHotelFile.StrFile.Replace(Setup.host, "");
            //                    }
            //                    else cn.ImageUrl = ParadiseHotelPath.News_Image_Default;
            //                }
            //                else cn.ImageUrl = ParadiseHotelPath.News_Image_Default;

            //            }
            //            else
            //            {
            //                cn.ImageUrl = ParadiseHotelPath.News_Image_Default;
            //            }
            //        }
            //        else cn.ImageUrl = ParadiseHotelPath.News_Image_Default;

            //        db.News.InsertOnSubmit(cn);
            //        db.SubmitChanges();
            //        Clear();
            //        messError.Visible = false;
            //        messSuccess.Visible = true;

            //    }
            //}
            //catch (Exception)
            //{

            //}
        }

        /// <summary>
        /// Load Chuyen Muc
        /// </summary>
        private void LoadChuyenMuc()
        {
            var categorys = db.Categories.OrderBy(c => c.CategoryOrder);
            ddlCategory.DataSource = categorys;
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataBind();
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}