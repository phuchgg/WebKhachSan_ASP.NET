using HaLongParadise.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HaLongParadise
{
    public partial class UpdateBanner : System.Web.UI.Page
    {
        HaLongParadiseDataContext db = new HaLongParadiseDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

            messError.Visible = false;
            messSuccess.Visible = false;
            errImageTag.Visible = false;
            if (!IsPostBack)
            {
                LoadChuyenMuc();
                //hiển thị thông tin của bản ghi đang sửa
                LoadItem();
                txtImageTag.Attributes.Add("maxlength", txtImageTag.MaxLength.ToString());
            }


        }
        #region Method
        /// <summary>
        /// Lấy số thứ tự max hiện đang tồn tại
        /// </summary>
        /// <returns></returns>
        int MaxNumber()
        {
            return db.ImageAlbums.Where(a => a.CategoryId == Convert.ToInt32(ddlCategory.SelectedValue)).Max(a => a.ImageOrder) != null ? (int)db.ImageAlbums.Where(a => a.CategoryId == Convert.ToInt32(ddlCategory.SelectedValue)).Max(a => a.ImageOrder) : 0;
        }
        /// <summary>
        /// Kiểm tra ràng buộc trước khi sửa
        /// </summary>
        /// <returns></returns>
        bool CheckCondition()
        {
            var kt = true;
            if (txtImageTag.Text == "")
            {
                messError.Visible = true;
                errImageTag.Visible = true;
                txtImageTag.Focus();
                kt = false;
            }
            return kt;
        }

        /// <summary>
        /// Hiển thị thông tin của bản ghi đang sửa
        /// </summary>
        void LoadItem()
        {
            if (Request.QueryString["ID"] != null)
            {
                int id = 0;
                string CategoryId = Request.QueryString["ID"];
                if (int.TryParse(CategoryId, out id))
                {
                    var cn = db.ImageAlbums.SingleOrDefault(a => a.ImageAlbumId == id);
                    if (cn != null)
                    {

                        ddlCategory.SelectedValue = cn.ImageAlbumId.ToString();
                        txtNote.Text = cn.ImageAlbumText;
                        txtLink.Text = cn.ImageAlbumUrl;
                        txtImageTag.Text = cn.ImageTag;
                        txtNumber.Text = cn.ImageOrder.ToString();
                        //show ảnh cũ
                        imgImage.ImageUrl = "~/" + cn.ImageAlbumUrl;
                        ddlCategory.SelectedValue = cn.CategoryId.ToString();
                        pLink.Visible = false;

                    }
                }
            }
        }
        void Clear()
        {
            txtNote.Text = "";
            txtLink.Text = "";
            messError.Visible = false;
            messSuccess.Visible = false;
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
            LoadItem();
        }

        /// <summary>
        /// Thêm mới tin tức
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                if (CheckCondition())
                {

                    int id = 0;
                    string CategoryId = Request.QueryString["ID"];
                    if (int.TryParse(CategoryId, out id))
                    {
                        var cn = db.ImageAlbums.SingleOrDefault(a => a.ImageAlbumId == id);
                        cn.CategoryId = Convert.ToInt32(ddlCategory.SelectedValue);
                        cn.ImageAlbumText = txtNote.Text;
                        cn.ImageAlbumUrl = txtLink.Text;
                        cn.ImageOrder = Convert.ToInt32(txtNumber.Text);
                        cn.ImageTag = txtImageTag.Text;
                        //thay thế ảnh mới nếu có
                        if (fulImage.HasFile)
                        {
                            //delete ảnh nếu có
                            if (ParadiseHotelPath.Banner_Image_Default != cn.ImageAlbumUrl)//khác default
                                ParadiseHotelFile.DeleteFile(Setup.host + cn.ImageAlbumUrl);
                            if (ParadiseHotelPath.Banner_Image_Default != cn.ImageAlbumUrlSmall)//khác default
                                ParadiseHotelFile.DeleteFile(Setup.host + cn.ImageAlbumUrlSmall);

                            // thêm ảnh mới
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
                                    
                                }
                              

                            }
                            
                        }

                        db.SubmitChanges();
                        messError.Visible = false;
                        messSuccess.Visible = true;
                        LoadItem();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            pLink.Visible = false;
            txtNumber.Text = (MaxNumber() + 1).ToString();
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
          
        }
    }
}