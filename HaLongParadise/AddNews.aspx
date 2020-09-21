<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs" Inherits="HaLongParadise.AddNews" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="Server">
    <%--selected menu--%>
    <script>
        $(document).ready(function () {
            //menu cha
            $('#News').addClass('nav-top-item current');
            //menu con
            $('#NewsList').addClass('current');
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--Content--%>
    <h3 class="title">Thêm mới tin tức</h3>
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
        <label>Chọn chuyên mục </label>
        <asp:DropDownList runat="server" ID="ddlCategory" CssClass="small-input"
            AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
        </asp:DropDownList>
    </p>
     <p>
        <label>Thứ tự <span style="color: red;">*</span> <span id="Span1" runat="server" class="input-notification error png_bg">Chưa nhập</span></label>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="text-input medium-input" TextMode="MultiLine" Height="30" MaxLength="300"></asp:TextBox>
    </p>
    <p>
        <label>Tiêu đề <span style="color: red;">*</span> <span id="errTitle" runat="server" class="input-notification error png_bg">Chưa nhập</span></label>
        <asp:TextBox ID="txtTitle" runat="server" CssClass="text-input medium-input" TextMode="MultiLine" Height="30" MaxLength="300"></asp:TextBox>
    </p>
    <p>
        <label>Lời dẫn <span style="color: red;">*</span> <span id="errSubTitle" runat="server" class="input-notification error png_bg">Chưa nhập</span></label>
        <asp:TextBox ID="txtSubTitle" runat="server" CssClass="text-input medium-input" TextMode="MultiLine" Height="60" MaxLength="500"></asp:TextBox>
    </p>

    <p>
        <label>Chi tiết (Max ngang 630)<span style="color: red;">*</span> <span id="errDetail" runat="server" class="input-notification error png_bg">Chưa nhập</span></label>
        <CKEditor:CKEditorControl ID="fckDetail" runat="server" Width="695" Height="400">
        </CKEditor:CKEditorControl>

    </p>
    <p>
        <label>
            Chọn ảnh (240 x 180) <span style="color: red;">*</span>&nbsp;&nbsp;&nbsp;<asp:FileUpload ID="fulImage" runat="server" ToolTip="Bạn hãy chọn ảnh ở đây" onchange="javascript:ImageURL();" />
            <span id="errImage" runat="server" class="input-notification error png_bg">Chưa chọn ảnh</span></label>

        <asp:Image Visible="false" ID="imgImage" CssClass="image_view" ImageUrl="~/img/news_default.jpg" runat="server" Width="240" Height="180" />
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
        <label>Chọn hiển thị mặc định (Ẩn bỏ check)</label>
        <asp:CheckBox ID="chkShow" runat="server" Checked="true" />
    </p>
    <p>

        <asp:Button runat="server" ID="btnAdd" CssClass="button" Text="Thêm" OnClick="btnAdd_Click" />
        <asp:Button runat="server" ID="btnCancel" CssClass="button" Text="Hủy bỏ" OnClick="btnCancel_Click" />
        <a href="NewsList.aspx">Trở về Danh sách tin tức</a>
    </p>
</asp:Content>
