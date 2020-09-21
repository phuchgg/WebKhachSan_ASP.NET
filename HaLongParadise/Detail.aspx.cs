using HaLongParadise.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HaLongParadise
{
    public partial class Detail : BasePage
    {
        HaLongParadiseDataContext db = new HaLongParadiseDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            ListRoom.Visible=false;
            if (!IsPostBack)
            {
                int tmp;
            string Id = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (int.TryParse(Id, out tmp))
            {

                Category cate = db.Categories.SingleOrDefault(a => a.CategoryId == tmp);
                if (cate != null)
                {
                    if (Session["lang"] != null && Session["lang"].ToString() == "en")
                    {
                        ltrTitle.Text = cate.TitleEng;
                        ltrDetail.Text = cate.ContentEng;
                    }
                    else
                    {
                        ltrTitle.Text = cate.Title;
                        ltrDetail.Text = cate.Content;
                    }
                  

                    if (cate.IsRoom == true)
                    {
                        //Load ds ListRoom dạng Button ngang
                        ListRoom.Visible = true;
                        var lst = db.Categories.Where(a => a.CategoryParent == cate.CategoryId).OrderBy(a => a.CategoryOrder);
                        rptRoomList.DataSource = lst;
                        rptRoomList.DataBind();
                    }
                }
            }
            }
        }

      
    }
}