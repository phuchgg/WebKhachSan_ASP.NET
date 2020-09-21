using HaLongParadise.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HaLongParadise
{
    public partial class Booking : BasePage
    {
        HaLongParadiseDataContext db = new HaLongParadiseDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadRooms();
        }
        //Download source code mien phi tai Sharecode.vn
        private void SendMail(string toEmail, string title, string body)
        {
            string fromEmail = "hoanggiaphuc.engonow@gmail.com";
            string password = "Sdt38751204";
            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromEmail, password);
                smtp.Timeout = 20000;

            }
            MailMessage message = new MailMessage(
               fromEmail,
               toEmail,
               title,
               body);
            message.IsBodyHtml = true;
            smtp.Send(message);

        }
        private string GetContentEmail()
        {
            StringBuilder sb = new StringBuilder();
            int Daysub = -1;
            if (!string.IsNullOrEmpty(txtFrom.Value) && !string.IsNullOrEmpty(txtTo.Text))
            {

                DateTime dtDateCome = DateTime.ParseExact(txtFrom.Value, "dd/MM/yyyy", null);
                DateTime dtDateEnd = DateTime.ParseExact(txtTo.Text, "dd/MM/yyyy", null);
                Daysub = dtDateEnd.Subtract(dtDateCome).Days;
            }
            if (Daysub < 0 && !string.IsNullOrEmpty(txtFrom.Value) && !string.IsNullOrEmpty(txtTo.Text))
            {
                if (Session["lang"] != null && Session["lang"].ToString().Equals("en"))
                    lblNote.Text = "<span style='color:red;'>&rsaquo;  End date of must be greater than start date</span>";
                else
                    lblNote.Text = "<span style='color:red;'>&rsaquo; Ngày đi không được nhỏ hơn ngày đến</span>";

                return string.Empty;

            }
            if (txtTo.Text.Trim() == "" || txtFrom.Value.Trim() == "" || ddlRoom.SelectedItem.Text.Trim() == "" || txtParent.Value.Trim() == "" || txtChildren.Value.Trim() == "" || txtFullName.Value.Trim() == "")
            {
                if (Session["lang"] != null && Session["lang"].ToString().Equals("en"))
                    lblNote.Text = "<span style='color:red;'>&rsaquo; Please enter the required fields *</span>";
                else
                    lblNote.Text = "<span style='color:red;'>&rsaquo; Hãy nhập đủ trường đánh dấu là *</span>";
               
            }
            else
            {
                sb.Append("<table><tr>");
                sb.Append("<th colspan='2' align='left'> Chi tiết yêu cầu</th></tr>");
                sb.Append("<tr><td><i>Ngày đến: </i></td><td>" + txtFrom.Value.ToString() + "</td></tr>");
                sb.Append("<tr><td><i>Ngày đi: </i></td><td>" + txtTo.Text.ToString() + "</td></tr>");
                sb.Append("<tr><td><i>Số điêm: </i></td><td>" + Daysub + "</td></tr>");
                sb.Append("<tr><td><i>Loại phòng: </i></td><td>" + ddlRoom.SelectedItem.Text + " - " + ddlRoomType.SelectedItem.Text + " </td></tr>");
                sb.Append("<tr><td><i>Số lượng khách: </i></td><td>Người lớn: " + txtParent.Value + ", Trẻ nhỏ: " + txtChildren.Value + " </td></tr>");
                sb.Append("<tr><td><i>Giường phụ: </i></td><td>" + txtBed.Value + "</td></tr>");
                sb.Append("<tr><td><i>Các yêu cầu khác: </i></td><td>" + txtRequest.Text + "</td></tr>");
                sb.Append("<tr><td></td><td></td></tr>");
                //
                sb.Append("<th colspan='2' align='left'> Thông tin khách hàng</th></tr>");
                sb.Append("<tr><td><i>Họ và tên: </i></td><td>" + txtFullName.Value.ToString() + "</td></tr>");
                sb.Append("<tr><td><i>Công ty: </i></td><td>" + txtCompany.Value.ToString() + "</td></tr>");
                sb.Append("<tr><td><i>Địa chỉ: </i></td><td>" + txtAddress.Value.ToString() + "</td></tr>");
                sb.Append("<tr><td><i>Quốc gia: </i></td><td>" + txtCountry.Value.ToString() + "</td></tr>");
                sb.Append("<tr><td><i>Điện thoại: </i></td><td>" + txtPhone.Value.ToString() + "</td></tr>");
                sb.Append("<tr><td><i>Fax: </i></td><td>" + txtFax.Value.ToString() + "</td></tr>");
                sb.Append("<tr><td><i>Địa chỉ Email: </i></td><td>" + txtEmail.Value.ToString() + "</td></tr>");

                sb.Append("</table>");
                if (Session["lang"] != null && Session["lang"].ToString().Equals("en"))
                    lblNote.Text = "<span style='color:red;'>&rsaquo; Booking success!</span>";
                else
                    lblNote.Text = "<span style='color:red;'>&rsaquo; Đặt phòng thành công!</span>";
               
            }
            return sb.ToString();
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string body = GetContentEmail();
            if (!string.IsNullOrEmpty(body))
                SendMail("maximumz160@gmail.com", "Khách đặt phòng " + DateTime.Now.ToShortDateString(), body);
                //SendMail("thehien233@gmail.com", "Khách đặt phòng " + DateTime.Now.ToShortDateString(), body);
        }

        private void LoadRooms()
        {
            var ParentRoom = db.Categories.FirstOrDefault(c => c.IsRoom.Equals(true));
            var RoomChilds = db.Categories.Where(c => c.CategoryParent.Equals(ParentRoom.CategoryId)).OrderBy(c => c.CategoryOrder);
            ddlRoom.DataSource = RoomChilds;
            if (Session["lang"] != null && Session["lang"].ToString().Equals("en"))
            {
                ddlRoom.DataTextField = "CategoryNameEng";
                ddlRoomType.Items.Insert(0, new ListItem("Double", "2"));
                ddlRoomType.Items.Insert(0, new ListItem("Single", "1"));
            }
            else
            {
                ddlRoom.DataTextField = "CategoryName";
                ddlRoomType.Items.Insert(0, new ListItem("Đôi", "2"));
                ddlRoomType.Items.Insert(0, new ListItem("Đơn", "1"));
            }
            ddlRoom.DataBind();
            ddlRoom.SelectedIndex = 0;
        }

        protected void txtRequest_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {

            txtFrom.Value = string.Empty;
            txtTo.Text = string.Empty;
            ddlRoom.SelectedIndex = 0;
            ddlRoomType.SelectedItem.Text = string.Empty;
            txtParent.Value = string.Empty;
            txtChildren.Value = string.Empty;
            txtBed.Value = string.Empty;
            txtRequest.Text = string.Empty;
            txtFullName.Value = string.Empty;
            txtCompany.Value = string.Empty;
            txtAddress.Value = string.Empty;
            txtCountry.Value = string.Empty;
            txtPhone.Value = string.Empty;
            txtFax.Value = string.Empty;
            txtEmail.Value = string.Empty;
        }

        protected void txtTo_TextChanged(object sender, EventArgs e)
        {
            int Daysub = -1;
            if (!string.IsNullOrEmpty(txtFrom.Value) && !string.IsNullOrEmpty(txtTo.Text))
            {

                DateTime dtDateCome = DateTime.ParseExact(txtFrom.Value, "dd/MM/yyyy", null);
                DateTime dtDateEnd = DateTime.ParseExact(txtTo.Text, "dd/MM/yyyy", null);
                Daysub = dtDateEnd.Subtract(dtDateCome).Days;
            }
            if (Daysub != -1)
            {
                if (Daysub == 0)
                    Daysub = 1;
                lblLightCount.Text = Daysub.ToString();
            }
        }
    }

}