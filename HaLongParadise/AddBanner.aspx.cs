using HaLongParadise.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HaLongParadise
{
    public partial class AddBanner : System.Web.UI.Page
    {
        HaLongParadiseDataContext db = new HaLongParadiseDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {

            messError.Visible = false;
            messSuccess.Visible = false;
            errImage.Visible = false;
            errImageTag.Visible = false;
            if (!IsPostBack)
            {
                LoadChuyenMuc();
                spanImage.InnerText = "Chọn ảnh (min 1366 x min 350)";
                txtImageTag.Attributes.Add("maxlength", txtImageTag.MaxLength.ToString());
                Clear();
            }
        }
        #region Method
        /// <summary>
        /// Lấy số thứ tự max hiện đang tồn tại
        /// </summary>
        /// <returns></returns>
        int MaxNumber()
        {
            //Download source code mien phi tai Sharecode.vn
            //if (ddlCategory.SelectedValue != "")
            return db.ImageAlbums.Where(a => a.CategoryId == Convert.ToInt32(ddlCategory.SelectedValue)).Max(a => a.ImageOrder) != null ? (int)db.ImageAlbums.Where(a => a.CategoryId == Convert.ToInt32(ddlCategory.SelectedValue)).Max(a => a.ImageOrder) : 0;
            //else return 0;
        }

        /// <summary>
        /// Kiểm tra ràng buộc trước khi thêm
        /// </summary>
        /// <returns></returns>
        bool CheckCondition()
        {
            var kt = true;
            try
            {
                if (txtImageTag.Text == "")
                {
                    messError.Visible = true;
                    errImageTag.Visible = true;
                    txtImageTag.Focus();
                    kt = false;
                }
                if (!fulImage.HasFile)
                {
                    messError.Visible = true;
                    errImage.Visible = true;
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
            txtNote.Text = "";
            messError.Visible = false;
            messSuccess.Visible = false;
            errImage.Visible = false;
            txtNumber.Text = (MaxNumber() + 1).ToString();
            txtImageTag.Text = "";

            errImageTag.Visible = false;

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
        /// Thêm mới 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //try
            //{

            if (CheckCondition())
            {

                var cn = new ImageAlbum();
                string index = ddlCategory.SelectedValue.Trim();
                if (index != "-1")
                {
                    cn.CategoryId = Convert.ToInt32(ddlCategory.SelectedValue);
                }


                cn.ImageAlbumText = txtNote.Text;
                cn.ImageOrder = Convert.ToInt32(txtNumber.Text);
                cn.Ishow = true;
                cn.ImageTag = txtImageTag.Text;
                // xu ly anh

                if (fulImage.HasFile)
                {
                    if (ParadiseHotelFile.IsFileImage(fulImage.FileName))
                    {
                        ParadiseHotelFile.CreateFoder(Setup.host + ParadiseHotelPath.Banner_Image_Small_Upload);
                        ParadiseHotelFile.CreateFoder(Setup.host + ParadiseHotelPath.Banner_Image_Upload);
                        if (ParadiseHotelFile.StrFoder != "")
                        {
                            ParadiseHotelFile.CreateFile(ParadiseHotelFile.StrFoder,
                                                 ParadiseHotelFile.StyleFile.HOUR_MINUTE_SECOND.ToString(),
                                                 fulImage.FileName);



                            if (ParadiseHotelFile.StrFile != "")
                            {
                                fulImage.PostedFile.SaveAs(ParadiseHotelFile.StrFile);
                                ParadiseHotelFile.ThayDoiKichThuocAnhNho(ParadiseHotelFile.StrFoder + "Small", ParadiseHotelFile.StrFile.Substring(ParadiseHotelFile.StrFile.LastIndexOf('/') + 1), 200, fulImage.PostedFile.InputStream);
                                cn.ImageAlbumUrlSmall = ParadiseHotelFile.StrFile.Replace(Setup.host, "").Replace("Banner", "BannerSmall");
                                cn.ImageAlbumUrl = ParadiseHotelFile.StrFile.Replace(Setup.host, "");
                            }
                            else
                            {
                                cn.ImageAlbumUrl = ParadiseHotelPath.Banner_Image_Default;
                                cn.ImageAlbumUrlSmall = ParadiseHotelPath.Banner_Image_Default;
                            }
                        }
                        else
                        {
                            cn.ImageAlbumUrl = ParadiseHotelPath.Banner_Image_Default;
                            cn.ImageAlbumUrlSmall = ParadiseHotelPath.Banner_Image_Default;
                        }

                    }
                    else
                    {
                        cn.ImageAlbumUrl = ParadiseHotelPath.Banner_Image_Default;
                        cn.ImageAlbumUrlSmall = ParadiseHotelPath.Banner_Image_Default;
                    }
                }
                else
                {
                    cn.ImageAlbumUrl = ParadiseHotelPath.Banner_Image_Default;
                    cn.ImageAlbumUrlSmall = ParadiseHotelPath.Banner_Image_Default;
                }

                db.ImageAlbums.InsertOnSubmit(cn);
                db.SubmitChanges();
                Clear();
                messError.Visible = false;
                messSuccess.Visible = true;

            }
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
            var categorys = db.Categories;
            ddlCategory.DataSource = categorys;
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataBind();
            ddlCategory.SelectedIndex = 0;
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNumber.Text = (MaxNumber() + 1).ToString();
        }
    }
}