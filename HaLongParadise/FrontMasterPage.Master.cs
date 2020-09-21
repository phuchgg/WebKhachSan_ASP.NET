using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HaLongParadise
{
    public partial class FrontMasterPage : System.Web.UI.MasterPage
    {
        HaLongParadiseDataContext db = new HaLongParadiseDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadMenu();

                int tmp;
                string Id = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
                if (int.TryParse(Id, out tmp))//hiển thị slide theo một danh mục
                    LoadSlideImage(tmp);
                else//hiển thị theo trang chủ
                    LoadSlideImage(0);
                //Download source code mien phi tai Sharecode.vn
                //info
                Contact info = db.Contacts.FirstOrDefault();
                if (info != null)
                {
                    if (Session["lang"] != null && Session["lang"].ToString() == "en")
                    {
                        txtAddress.InnerText = info.ContactAddressEng;
                        txtPhone.InnerText = info.phone;
                        txtFax.InnerText = "Fax: " + info.Fax;
                        txtEmail.InnerText = info.Email;
                        txtEmail.HRef = "mailto:" + info.Email;
                        txtDescription.InnerText = info.DescriptionSortEng;
                    }
                    else
                    {
                        txtAddress.InnerText = info.ContactAddress;
                        txtPhone.InnerText =  info.phone;
                        txtFax.InnerText = "Fax: "+info.Fax;
                        txtEmail.InnerText = info.Email;
                        txtEmail.HRef = "mailto:" + info.Email;
                        txtDescription.InnerText = info.DescriptionSort;
                    }
                   
                }
            }
        }

        void loadMenu()
        {
            var lst = db.Categories.Where(a =>a.IsShow==true&& a.CategoryParent == 0 && a.CategoryName != "Trang chủ").OrderBy(a => a.CategoryOrder);
            rptMenus.DataSource = lst;
            rptMenus.DataBind();

            rptFooterMenu.DataSource = lst;
            rptFooterMenu.DataBind();
        }
        protected void rptMenus_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Category cate = (Category)e.Item.DataItem;

            //menu con
            var lstSubMenu = db.Categories.Where(a => a.IsShow == true && a.CategoryParent == cate.CategoryId).OrderBy(a => a.CategoryOrder);
            if (lstSubMenu != null && lstSubMenu.Count() > 0)
            {
                Repeater rptSubMenu = (Repeater)e.Item.FindControl("rptSubMenus");
                rptSubMenu.DataSource = lstSubMenu;
                rptSubMenu.DataBind();
            }
        }

        protected void lbtEnglish_Click(object sender, EventArgs e)
        {
            String url = this.Page.Request.Url.AbsoluteUri;

            Session["lang"] = "en";
            Response.Redirect(ResolveUrl(url));
        }

        protected void lbtVietNam_Click(object sender, EventArgs e)
        {
            String url = this.Page.Request.Url.AbsoluteUri;
            Session["lang"] = "vi";
            Response.Redirect(ResolveUrl(url));
        }
        void LoadSlideImage(int CategoryId)
        {
            if (CategoryId == 0 || (CategoryId != 0 && db.ImageAlbums.Any(a => a.Ishow == true && a.CategoryId == CategoryId)==false))//slide ảnh của trang chủ, nếu danh mục chưa có ảnh hoặc page
            {
                var lst = db.ImageAlbums.Where(a => a.Ishow == true && a.Category.CategoryName == "Trang chủ").OrderBy(a => a.ImageOrder);
                rptSlide.DataSource = lst;
                rptSlide.DataBind();
            }
            else
            {
                var lst = db.ImageAlbums.Where(a => a.Ishow == true && a.CategoryId == CategoryId).OrderBy(a => a.ImageOrder);
                rptSlide.DataSource = lst;
                rptSlide.DataBind();
            }
        }
    }
}