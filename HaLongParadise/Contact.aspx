<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="HaLongParadise.Contact" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="Server">
    <%--selected menu--%>
    <script>
        $(document).ready(function () {
            //menu cha
            $('#Contact').addClass('nav-top-item current');
            //menu con
            $('#PageContact').addClass('current');
        });
    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--Content--%>
    <h3 class="title">Trang - Liên hệ</h3>
    <div class="notification success png_bg" id="messSuccess" runat="server">
        <a href="#" class="close">
            <img src="../images/icons/cross_grey_small.png" title="Close this notification" alt="close" /></a>
        <div id="messSuccessText" runat="server">
            Lưu thành công!
        </div>
    </div>

    <div class="notification error png_bg" id="messError" runat="server">
        <a href="#" class="close">
            <img src="../images/icons/cross_grey_small.png" title="Close this notification" alt="close" /></a>
        <div>
            Chưa nhập nội dung!
        </div>
    </div>
    <p>
        <label>Địa chỉ (Tiếng việt)</label>
        <asp:TextBox ID="txtAddress" runat="server" CssClass="text-input medium-input" MaxLength="1000" Width="600px"></asp:TextBox>
    </p>
     <p>
        <label>Địa chỉ (Tiếng anh)</label>
        <asp:TextBox ID="txtAddressEng" runat="server" CssClass="text-input medium-input backgroundEnglish" MaxLength="1000" Width="600px"></asp:TextBox>
    </p>
    <p>
        <label>Số điện thoại</label>
        <asp:TextBox ID="txtPhone" runat="server" CssClass="text-input medium-input" MaxLength="50" Width="200px"></asp:TextBox>
    </p>
    <p>
        <label>Fax</label>
        <asp:TextBox ID="txtFax" runat="server" CssClass="text-input medium-input" MaxLength="50" Width="200px"></asp:TextBox>
    </p>
    <p>
        <label>Email</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="text-input medium-input" MaxLength="50" Width="200px"></asp:TextBox>
    </p>
    <p>
        <label>Mô tả ngắn (Tiếng việt)</label>
        <asp:TextBox ID="txtDescriptionSort" runat="server" TextMode="MultiLine" CssClass="text-input medium-input" MaxLength="200" Width="600px"></asp:TextBox>
    </p>
     <p>
        <label>Mô tả ngắn (Tiếng anh)</label>
        <asp:TextBox ID="txtDescriptionSortEng" runat="server" TextMode="MultiLine" CssClass="text-input medium-input backgroundEnglish" MaxLength="200" Width="600px"></asp:TextBox>
    </p>
    <p>
        <label>
            Chi tiết liên hệ (Max ngang 900) - Tiếng việt
        </label>
        &nbsp;
   <CKEditor:CKEditorControl ID="ckContactDetail" runat="server" Width="970" Height="400">
   </CKEditor:CKEditorControl>
    </p>
    <p>
        <label>
            Chi tiết liên hệ (Max ngang 900) - Tiếng anh
        </label>
        &nbsp;
   <CKEditor:CKEditorControl ID="ckContactDetailEng" CssClass="backgroundEnglish" runat="server" Width="970" Height="400">
   </CKEditor:CKEditorControl>
    </p>
    <br />
    <br />
    <p>
        <label>Giới thiệu trang chủ (Max ngang 625) - Tiếng việt</label>
        &nbsp;
   <CKEditor:CKEditorControl ID="ckDescription" runat="server" Width="700" Height="400">
   </CKEditor:CKEditorControl>
    </p>
     <p>
        <label>Giới thiệu trang chủ (Max ngang 625) - Tiếng anh</label>
        &nbsp;
   <CKEditor:CKEditorControl ID="ckDescriptionEng" CssClass="backgroundEnglish" runat="server" Width="700" Height="400">
   </CKEditor:CKEditorControl>
    </p>
      <p>
        <label>Ảnh giới thiệu (285x200)
            <span id="spanImage" runat="server"></span><%--<span style="color: red;">*</span>--%>&nbsp;&nbsp;&nbsp;<asp:FileUpload ID="fulImage" runat="server" ToolTip="Bạn hãy chọn ảnh ở đây" onchange="javascript:ImageURL();" />
<%--            <span id="errImage" runat="server" class="input-notification error png_bg">Chưa chọn ảnh</span>--%></label>

        <asp:Image Visible="false" ID="imgImage" CssClass="image_view" ImageUrl="~/img/news_default.jpg" runat="server" Width="600px" Height="170px" />
        <%--Chỉ chọn file ảnh và hiển thị luôn file ảnh dc chọn--%>
        <script type="text/javascript">
            function ImageURL() {
                var url = this.document.getElementById('<%=fulImage.ClientID%>').value;
                if ((url.lastIndexOf('.jpg') == -1) && (url.lastIndexOf('.JPG') == -1) && (url.lastIndexOf('.png') == -1) && (url.lastIndexOf('.PNG') == -1) && (url.lastIndexOf('.gif') == -1) && (url.lastIndexOf('.GIF') == -1)) {
                    alert('Chỉ được chọn file ảnh');
                    this.document.getElementById('<%=fulImage.ClientID%>').value = "";
                    return false;
                }

            }
        </script>


    </p>
    <br />
    <br />
    <asp:Button runat="server" ID="btnSave" CssClass="button" Text="Cập nhật" OnClick="btnSave_Click" />
    <asp:Button runat="server" ID="btnCancel" CssClass="button" Text="Hủy bỏ" OnClick="btnCancel_Click" />
</asp:Content>

