using HaLongParadise.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HaLongParadise
{
    public partial class Login : System.Web.UI.Page
    {
        HaLongParadiseDataContext db = new HaLongParadiseDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                messAccount.Visible = false;
                Response.Cookies["UserName"].Value = "";

            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtAccount.Text == "" || txtPassword.Text == "")
            {
                messAccount.Visible = true;
                messAccount.InnerText = "Chưa nhập đầy đủ thông tin";
                return;
            }
            Account admin = db.Accounts.SingleOrDefault(a => a.AccountName == txtAccount.Text && a.PassWord == MD5Hash.getMd5Hash(txtPassword.Text));
            if (admin == null)
            {
                messAccount.Visible = true;
                messAccount.InnerText = "Thông tin tài khoản không hợp lệ";

            }
            else
            {
                Response.Cookies["UserName"].Value = txtAccount.Text;
                Session["AccountId"] = admin.AccountId;
                Response.Redirect("Categorys.aspx");
            }

        }
    }
}