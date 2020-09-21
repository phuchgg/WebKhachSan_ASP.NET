using HaLongParadise.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HaLongParadise
{
    public partial class Banners : System.Web.UI.Page
    {
        HaLongParadiseDataContext db = new HaLongParadiseDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

            messSuccess.Visible = false;
            if (!IsPostBack)
            {
                LoadGridView(0);
                LoadChuyenMuc();
            }
        }

        //phương thức load tất cả tin  lên gridview
        public void LoadGridView(int categoryID)
        {
            var deve = db.ImageAlbums.Where(a => a.CategoryId == categoryID || categoryID == 0).OrderBy(n => n.ImageOrder).ThenBy(n => n.ImageAlbumText);
            gvList.DataSource = deve;
            lblTotalItem.Text = deve.Count().ToString();
            gvList.DataBind();

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //phương thức xóa nhiều tin

                int i = 0;

                foreach (GridViewRow row in gvList.Rows)
                {

                    CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                    if (chk != null)
                    {
                        if (chk.Checked)
                        {
                            LinkButton lbt = (LinkButton)row.FindControl("lbtDelete");
                            ImageAlbum banner = db.ImageAlbums.SingleOrDefault(c => c.ImageAlbumId.ToString() == lbt.CommandArgument.ToString());
                            if (banner != null)
                            {
                                //delete ảnh nếu có
                                if (ParadiseHotelPath.Banner_Image_Default != banner.ImageAlbumUrl)//khác default
                                    ParadiseHotelFile.DeleteFile(Setup.host + banner.ImageAlbumUrl);
                                if (ParadiseHotelPath.Banner_Image_Default != banner.ImageAlbumUrlSmall)//khác default
                                    ParadiseHotelFile.DeleteFile(Setup.host + banner.ImageAlbumUrlSmall);
                            }
                            db.ImageAlbums.DeleteOnSubmit(banner);
                            i++;



                        }
                    }
                }
                messSuccess.Visible = true;
                messSuccessText.InnerText = "Xóa " + i + " bản ghi thành công!";
                db.SubmitChanges();


                LoadGridView(Convert.ToInt32(ddlCategory.SelectedValue));

            }
            catch (Exception)
            {

            }
        }

        protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }


        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                var cn = e.Row.DataItem as ImageAlbum;

                var imgShow = e.Row.FindControl("imgShow") as Image;

                if (cn != null)
                {
                    if (imgShow != null)// hiển thị icon theo đúng trạng thái display
                        imgShow.ImageUrl = cn.Ishow == true ? ParadiseHotelPath.Icon_Show : ParadiseHotelPath.Icon_Hide;
                }
            }
            catch (Exception)
            {

            }
            //check all
            if (e.Row.RowType == DataControlRowType.Header)
            {

                ((CheckBox)e.Row.FindControl("chkHeadSelect")).Attributes.Add("onclick", "javascript:SelectAll('" +
                        ((CheckBox)e.Row.FindControl("chkHeadSelect")).ClientID + "','" + gvList.ClientID + "')");
            }

        }
        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                ImageAlbum banner = db.ImageAlbums.SingleOrDefault(c => c.ImageAlbumId.ToString() == e.CommandArgument.ToString());

                if (e.CommandName == "Show")
                {
                    banner.Ishow = !banner.Ishow;
                    db.SubmitChanges();

                    LoadGridView(Convert.ToInt32(ddlCategory.SelectedValue));
                }
                if (e.CommandName == "Delete")
                {

                    if (banner != null)
                    {
                        //delete ảnh nếu có
                        if (ParadiseHotelPath.Banner_Image_Default != banner.ImageAlbumUrl)//khác default
                            ParadiseHotelFile.DeleteFile(Setup.host + banner.ImageAlbumUrl);
                        if (ParadiseHotelPath.Banner_Image_Default != banner.ImageAlbumUrlSmall)//khác default
                            ParadiseHotelFile.DeleteFile(Setup.host + banner.ImageAlbumUrlSmall);

                        db.ImageAlbums.DeleteOnSubmit(banner);
                        db.SubmitChanges();
                        messSuccess.Visible = true;
                        messSuccessText.InnerText = "Xóa 1 bản ghi thành công!";
                        LoadGridView(Convert.ToInt32(ddlCategory.SelectedValue));
                    }
                }
                if (e.CommandName == "Edit")
                {
                    Response.Redirect("UpdateBanner.aspx?ID=" + e.CommandArgument.ToString());

                }
                //if (e.CommandName == "Preview")
                //{
                //    Response.Redirect("ChiTietTin.aspx?ID= " + e.CommandArgument.ToString());
                //}



            }
            catch (Exception)
            {

            }
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
        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int pageindex = e.NewPageIndex;
            {
                LoadGridView(Convert.ToInt32(ddlCategory.SelectedValue));
                gvList.PageIndex = pageindex;
                gvList.DataBind();
            }
        }



        protected void gvList_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGridView(Convert.ToInt32(ddlCategory.SelectedValue));
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
            var item = new ListItem("Tất cả", "0");
            ddlCategory.Items.Insert(0, item);
            ddlCategory.SelectedIndex = 0;
        }
    }
}