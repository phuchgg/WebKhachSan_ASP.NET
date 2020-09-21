using HaLongParadise.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HaLongParadise
{
    public partial class Categorys : System.Web.UI.Page
    {

        HaLongParadiseDataContext db = new HaLongParadiseDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                FillData();
                Clear();
                LoadChuyenMucCha();

                //Kiểm tra trường hợp Thêm mới hoặc sửa
                if (Request.QueryString["ID"] != null)
                {
                    int id = 0;
                    string CategoryId = Request.QueryString["ID"];
                    if (int.TryParse(CategoryId, out id) && id != 0)
                        EditItem(id);
                }

            }
        }

        #region Method
        /// <summary>
        /// Load dữ liệu lên GridView
        /// </summary>
        void FillData()
        {
            try
            {
                gvList.DataSource = db.Categories.OrderBy(a => a.CategoryOrder);
                gvList.DataBind();
                lblTotalItem.Text = db.Categories.Count().ToString();
            }
            catch (Exception)
            {

            }

        }
        /// <summary>
        /// Kiểm tra ràng buộc trước khi thêm
        /// </summary>
        /// <param name="titleSkip">bỏ kiểm tra trùng với title này</param>
        /// <returns></returns>
        bool CheckCondition(string categoryName, string categoryNameEng)
        {
            //Clear();
            messError.Visible = false;
            messSuccess.Visible = false;
            errTitle.Visible = false;
            errCategoryName.Visible = false;
            var kt = true;
            try
            {
                if (txtTitle.Text == "")
                {
                    messError.Visible = true;
                    errTitle.Visible = true;
                    errTitle.InnerText = "Chưa nhập";
                    txtTitle.Focus();
                    kt = false;
                }
                if (txtTitleEng.Text == "")
                {
                    messError.Visible = true;
                    errTitleEng.Visible = true;
                    errTitleEng.InnerText = "Chưa nhập";
                    txtTitleEng.Focus();
                    kt = false;
                }

                if (txtCategoryNameEng.Text == "")
                {
                    messError.Visible = true;
                    errCategoryNameEng.Visible = true;
                    errCategoryNameEng.InnerText = "Chưa nhập";
                    txtCategoryNameEng.Focus();
                    kt = false;
                }

                else if (db.Categories.Any(a => a.CategoryNameEng == txtCategoryNameEng.Text && a.CategoryNameEng != categoryNameEng))
                {
                    messError.Visible = true;
                    errCategoryNameEng.Visible = true;
                    errCategoryNameEng.InnerText = "Tên chuyên mục tiếng anh tồn tại";
                    txtCategoryNameEng.Focus();
                    kt = false;
                }

                if (txtCategoryName.Text == "")
                {
                    messError.Visible = true;
                    errCategoryName.Visible = true;
                    errCategoryName.InnerText = "Chưa nhập";
                    txtCategoryName.Focus();
                    kt = false;
                }
                else if (db.Categories.Any(a => a.CategoryName == txtCategoryName.Text && a.CategoryName != categoryName))
                {
                    messError.Visible = true;
                    errCategoryName.Visible = true;
                    errCategoryName.InnerText = "Tên chuyên mục tồn tại";
                    txtCategoryName.Focus();
                    kt = false;
                }


            }
            catch (Exception)
            {

            }
            return kt;
        }
        /// <summary>
        /// Load dữ liệu nên control để edit
        /// </summary>
        /// <param name="id">item cần edit</param>
        void EditItem(int id)
        {
            try
            {
                btnEdit.Visible = true;
                btnAdd.Visible = false;

                Category cb = db.Categories.SingleOrDefault(a => a.CategoryId == id);
                txtCategoryName.Text = cb.CategoryName;
                txtCategoryNameEng.Text = cb.CategoryNameEng;
                txtNumber.Text = cb.CategoryOrder.ToString();
                txtTitle.Text = cb.Title;
                txtTitleEng.Text = cb.TitleEng;
                txtSubTitle.Text = cb.Summary;
                txtSubTitleEng.Text = cb.SummaryEng;
                fckDetail.Text = cb.Content;
                fckDetailEng.Text = cb.ContentEng;
                chkSelectView.Checked = bool.Parse(cb.IsDisplayMain.ToString());
                chkIshow.Checked = bool.Parse(cb.IsShow.ToString());
                //ddlCategory.SelectedItem 
                ddlCategory.SelectedValue = cb.CategoryParent.ToString();
            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// Lấy số thứ tự max hiện đang tồn tại
        /// </summary>
        /// <returns></returns>
        int MaxNumber()
        {
            if (db.Categories.Count() > 0)
                return int.Parse(db.Categories.Max(a => a.CategoryOrder).ToString());
            else
                return 0;
        }

        /// <summary>
        /// Khởi tạo về trạng thái ban đầu
        /// </summary>
        void Clear()
        {
            txtTitle.Text = "";
            txtTitleEng.Text = string.Empty;
            txtCategoryName.Text = string.Empty;
            txtCategoryNameEng.Text = string.Empty;
            txtSubTitle.Text = string.Empty;
            txtSubTitleEng.Text = string.Empty;
            fckDetail.Text = string.Empty;
            fckDetailEng.Text = string.Empty;
            ddlCategory.SelectedIndex = 0;
            txtNumber.Text = (MaxNumber() + 1).ToString();
            messError.Visible = false;
            messSuccess.Visible = false;
            errTitle.Visible = false;
            errCategoryNameEng.Visible = false;
            errCategoryName.Visible = false;
            errTitleEng.Visible = false;
            btnAdd.Visible = true;
            btnEdit.Visible = false;

        }
        #endregion

        /// <summary>
        /// Sửa một bản ghi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Category cb = db.Categories.SingleOrDefault(a => a.CategoryId == Convert.ToInt32(Request.QueryString["ID"]));
                if (CheckCondition(cb.CategoryName, cb.CategoryNameEng))
                {

                    cb.AccountId = Session["AccountId"] != null ? int.Parse(Session["AccountId"].ToString()) : 1;//nho fix sau khi lam xong login
                    cb.CategoryName = txtCategoryName.Text;
                    cb.CategoryNameEng = txtCategoryNameEng.Text;
                    if (ddlCategory.SelectedIndex == 0)
                        cb.CategoryParent = 0;
                    else
                        cb.CategoryParent = int.Parse(ddlCategory.SelectedValue);
                    //Tin
                    cb.Title = txtTitle.Text;
                    cb.TitleEng = txtTitleEng.Text;
                    cb.Summary = txtSubTitle.Text;
                    cb.SummaryEng = txtSubTitleEng.Text;
                    cb.Content = fckDetail.Text;
                    cb.ContentEng = fckDetailEng.Text;
                    cb.IsDisplayMain = chkSelectView.Checked ? true : false;

                    cb.IsShow = chkIshow.Checked ? true : false;
                    cb.Date = DateTime.Now;

                    if (txtNumber.Text != "")
                        cb.CategoryOrder = Convert.ToInt32(txtNumber.Text);
                    else
                        cb.CategoryOrder = (MaxNumber() + 1);
                    //
                    if (fulImage.HasFile)
                    {
                        if (ParadiseHotelPath.Category_Image_Default != cb.ImageUrl)//khác default
                            ParadiseHotelFile.DeleteFile(Setup.host + cb.ImageUrl);

                        if (ParadiseHotelFile.IsFileImage(fulImage.FileName))
                        {
                            ParadiseHotelFile.CreateFoder(Setup.host + ParadiseHotelPath.Cate_Image_Upload);
                            if (ParadiseHotelFile.StrFoder != "")
                            {
                                ParadiseHotelFile.CreateFile(ParadiseHotelFile.StrFoder,
                                                     ParadiseHotelFile.StyleFile.HOUR_MINUTE_SECOND.ToString(),
                                                     fulImage.FileName);

                                if (ParadiseHotelFile.StrFile != "")
                                {
                                    fulImage.PostedFile.SaveAs(ParadiseHotelFile.StrFile);

                                    cb.ImageUrl = ParadiseHotelFile.StrFile.Replace(Setup.host, "");
                                }
                                else cb.ImageUrl = ParadiseHotelPath.Category_Image_Default;
                            }
                            else cb.ImageUrl = ParadiseHotelPath.Category_Image_Default;

                        }
                        else
                        {
                            cb.ImageUrl = ParadiseHotelPath.Category_Image_Default;
                        }
                    }


                    db.SubmitChanges();
                    FillData();
                    Clear();
                    messSuccess.Visible = true;
                    messSuccessText.InnerText = "Sửa chuyên mục \"" + cb.CategoryName + "\" thành công";
                }
            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {


            try
            {
                if (CheckCondition("", ""))
                {
                    Category cb = new Category();
                    cb.AccountId = Session["AccountId"] != null ? int.Parse(Session["AccountId"].ToString()) : 1;//nho fix sau khi lam xong login
                    cb.CategoryName = txtCategoryName.Text;
                    cb.CategoryNameEng = txtCategoryNameEng.Text;
                    if (ddlCategory.SelectedIndex == 0)
                        cb.CategoryParent = 0;
                    else
                        cb.CategoryParent = int.Parse(ddlCategory.SelectedValue);
                    //Tin
                    cb.Title = txtTitle.Text;
                    cb.TitleEng = txtTitleEng.Text;
                    cb.Summary = txtSubTitle.Text;
                    cb.SummaryEng = txtSubTitleEng.Text;
                    cb.Content = fckDetail.Text;
                    cb.ContentEng = fckDetailEng.Text;
                    cb.IsDisplayMain = chkSelectView.Checked ? true : false;
                    cb.IsShow = chkIshow.Checked ? true : false;
                    cb.Date = DateTime.Now;

                    if (txtNumber.Text != "")
                        cb.CategoryOrder = Convert.ToInt32(txtNumber.Text);
                    else
                        cb.CategoryOrder = (MaxNumber() + 1);
                    //
                    if (fulImage.HasFile)
                    {

                        if (ParadiseHotelFile.IsFileImage(fulImage.FileName))
                        {
                            ParadiseHotelFile.CreateFoder(Setup.host + ParadiseHotelPath.Cate_Image_Upload);
                            if (ParadiseHotelFile.StrFoder != "")
                            {
                                ParadiseHotelFile.CreateFile(ParadiseHotelFile.StrFoder,
                                                     ParadiseHotelFile.StyleFile.HOUR_MINUTE_SECOND.ToString(),
                                                     fulImage.FileName);

                                if (ParadiseHotelFile.StrFile != "")
                                {
                                    fulImage.PostedFile.SaveAs(ParadiseHotelFile.StrFile);

                                    cb.ImageUrl = ParadiseHotelFile.StrFile.Replace(Setup.host, "");
                                }
                                else cb.ImageUrl = ParadiseHotelPath.Category_Image_Default;
                            }
                            else cb.ImageUrl = ParadiseHotelPath.Category_Image_Default;

                        }
                        else
                        {
                            cb.ImageUrl = ParadiseHotelPath.Category_Image_Default;
                        }
                    }
                    else cb.ImageUrl = ParadiseHotelPath.Category_Image_Default;


                    db.Categories.InsertOnSubmit(cb);
                    db.SubmitChanges();

                    FillData();
                    Clear();
                    messSuccess.Visible = true;
                    messSuccessText.InnerText = "Thêm chuyên mục \"" + cb.CategoryName + "\" thành công";

                }
            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// Hủy bỏ và trở về trạng thái thêm mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
            Response.Redirect("Categorys.aspx");
        }
        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                var cb = db.Categories.SingleOrDefault(a => a.CategoryId == Convert.ToInt32(e.CommandArgument));
                if (cb != null)
                {
                    //sửa bản ghi hiện tại
                    if (e.CommandName == "Edit")
                    {
                        Response.Redirect("Categorys.aspx?ID=" + e.CommandArgument.ToString());
                    }

                    //xóa bản ghi hiện tại
                    else if (e.CommandName == "Delete")
                    {
                        if (ParadiseHotelPath.Category_Image_Default != cb.ImageUrl)//khác default
                            ParadiseHotelFile.DeleteFile(Setup.host + cb.ImageUrl);
                        db.Categories.DeleteOnSubmit(cb);
                        db.SubmitChanges();
                        FillData();
                        Clear();
                        messSuccess.Visible = true;
                        messSuccessText.InnerText = "Xóa chuyên mục \"" + cb.CategoryName + "\" thành công";
                    }
                    else if (e.CommandName == "ShowMain")
                    {
                        cb.IsDisplayMain = !cb.IsDisplayMain;
                        db.SubmitChanges();
                        FillData();

                    }
                    else if (e.CommandName == "Show")
                    {
                        cb.IsShow = !cb.IsShow;
                        db.SubmitChanges();
                        FillData();
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        /// <summary>
        /// selected row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvList_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='" + ParadiseHotelPath.GridView_Hover_Color + "'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
            }
        }



        /// <summary>
        /// Load Chuyen Muc Cha
        /// </summary>
        private void LoadChuyenMucCha()
        {
            var categorys = db.Categories.Where(c => c.CategoryName.ToLower() != "Trang chủ" && c.CategoryParent.Equals(0)).OrderBy(c => c.CategoryOrder);
            ddlCategory.DataSource = categorys;
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataBind();
            ListItem item = new ListItem("Chuyên mục cấp 1", "0", true);
            ddlCategory.Items.Insert(0, item);
            ddlCategory.SelectedIndex = 0;
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var categoryOrder = db.Categories.Where(c => c.CategoryParent == int.Parse(ddlCategory.SelectedValue)).Max(c => c.CategoryOrder);
            if (!string.IsNullOrEmpty(categoryOrder.ToString()))
                txtNumber.Text = categoryOrder.ToString();
            else
                txtNumber.Text = "0";
            //
            if (ddlCategory.SelectedIndex == 0)

                txtNumber.Text = (db.Categories.Where(c => c.CategoryParent.Equals(0)).Max(c => c.CategoryOrder) + 1).ToString();
            else
                txtNumber.Text = (db.Categories.Where(c => c.CategoryParent.Equals(ddlCategory.SelectedValue)).Max(c => c.CategoryOrder) + 1).ToString();
        }

        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                var cn = e.Row.DataItem as Category;

                var imgShow = e.Row.FindControl("imgShow") as Image;
                var imgShowMain = e.Row.FindControl("imgShowMain") as Image;

                if (cn != null)
                {
                    if (imgShow != null)// hiển thị icon theo đúng trạng thái display
                        imgShow.ImageUrl = cn.IsShow == true ? ParadiseHotelPath.Icon_Show : ParadiseHotelPath.Icon_Hide;

                    if (imgShowMain != null)// hiển thị icon theo đúng trạng thái display
                        imgShowMain.ImageUrl = cn.IsDisplayMain == true ? ParadiseHotelPath.Icon_Show : ParadiseHotelPath.Icon_Hide;
                }
            }
            catch (Exception)
            {

            }

        }


    }
}