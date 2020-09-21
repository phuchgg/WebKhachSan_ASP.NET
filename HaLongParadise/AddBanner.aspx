<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddBanner.aspx.cs" Inherits="HaLongParadise.AddBanner" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="Server">
    <%--selected menu--%>
    <script>
        $(document).ready(function () {
            //menu cha
            $('#parenbanner').addClass(' current');
            //menu con
            $('#addbaner').addClass('current');
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--Content--%>
    <h3 class="title">Thêm banner mới</h3>
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
            Dữ liệu chưa hợp lệ, hãy kiểm tra lại!
        </div>
    </div>
    <p>
        <label>Chọn Chuyên mục </label>
        <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlCategory" CssClass="small-input" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
        </asp:DropDownList>
    </p>
 
       <%-- <p id="pnAlbumName" runat="server">
            <label>Tên Album ảnh</label>
            <asp:TextBox ID="txtAlbumName" runat="server" CssClass="text-input small-input" MaxLength="300" Width="600px"></asp:TextBox>
        </p>--%>

   
    <p>
        <label>Thứ tự</label>
        <asp:TextBox ID="txtNumber" runat="server" CssClass="text-input small-input" onkeypress="CheckNumeric(event);" MaxLength="9"></asp:TextBox>
        &nbsp;&nbsp;<small>Là kiểu số, Mặc định: Max +1</small>
    </p>
    <p>
        <label>Mô tả ảnh</label>
        <asp:TextBox ID="txtNote" runat="server" CssClass="text-input medium-input" TextMode="MultiLine" Height="30px" MaxLength="500" Width="600px"></asp:TextBox>
    </p>

    <p>
        <label>
            <span id="spanImage" runat="server"></span><span style="color: red;">*</span>&nbsp;&nbsp;&nbsp;<asp:FileUpload ID="fulImage" runat="server" ToolTip="Bạn hãy chọn ảnh ở đây" onchange="javascript:ImageURL();" />
            <span id="errImage" runat="server" class="input-notification error png_bg">Chưa chọn ảnh</span></label>

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
    <p>
        <label>Từ khóa ảnh (Tag) <span style="color: red;">*</span> <span id="errImageTag" runat="server" class="input-notification error png_bg">Chưa nhập</span></label>
        <asp:TextBox ID="txtImageTag" runat="server" CssClass="text-input medium-input" TextMode="MultiLine" Height="60px" MaxLength="200" Width="600px"></asp:TextBox>
    </p>
    <br />
    <p>

        <asp:Button runat="server" ID="btnAdd" CssClass="button" Text="Thêm" OnClick="btnAdd_Click" />
        <asp:Button runat="server" ID="btnCancel" CssClass="button" Text="Hủy bỏ" OnClick="btnCancel_Click" />
        <a href="Banners.aspx">Trở về Danh sách banner</a>
    </p>
</asp:Content>
