<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Categorys.aspx.cs" Inherits="HaLongParadise.Categorys" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="Server">
    <%--selected menu--%>
    <script>
        $(document).ready(function () {
            //menu cha
            $('#Category').addClass('nav-top-item current');
            //menu con
            $('#CategoryLang').addClass('current');
        });
    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <%--Content--%>
    <h3 class="title">Quản lý Chuyên mục - Tin</h3>
    <div class="notification success png_bg" id="messSuccess" runat="server">
        <a href="#" class="close">
            <img src="images/icons/cross_grey_small.png" title="Close this notification" alt="close" /></a>
        <div id="messSuccessText" runat="server">
            Lưu thành công!
        </div>
    </div>

    <div class="notification error png_bg" id="messError" runat="server">
        <a href="#" class="close">
            <img src="images/icons/cross_grey_small.png" title="Close this notification" alt="close" /></a>
        <div>
            Dữ liệu chưa hợp lệ, hãy kiểm tra lại!
        </div>
    </div>

    <p>
        <label>Chọn chuyên mục cha</label>
        <asp:DropDownList runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" ID="ddlCategory" CssClass="small-input">
        </asp:DropDownList>
    </p>

    <%-- <p>
        <label>Chọn Album ảnh </label>
        <asp:DropDownList runat="server" ID="ddlAlBum" CssClass="small-input"
            AutoPostBack="True" OnSelectedIndexChanged="ddlAlBum_SelectedIndexChanged">
        </asp:DropDownList>
    </p>--%>
    <p>
        <label>Tên chuyên mục(Tiếng việt) <span style="color: red;">*</span><span id="errCategoryName" runat="server" visible="false" class="input-notification error png_bg">Chưa nhập</span></label>
        <asp:TextBox ID="txtCategoryName" runat="server" CssClass="text-input medium-input" MaxLength="200" Width="599px"></asp:TextBox>

    </p>
      <p>
        <label>Tên chuyên mục(Tiếng anh) <span style="color: red;">*</span><span id="errCategoryNameEng" runat="server" visible="false" class="input-notification error png_bg">Chưa nhập</span></label>
        <asp:TextBox ID="txtCategoryNameEng" runat="server" CssClass="text-input medium-input backgroundEnglish" MaxLength="200" Width="599px"></asp:TextBox>

    </p>
    <p>
        <label>Thứ tự</label>
        <asp:TextBox ID="txtNumber" runat="server" CssClass="text-input small-input" onkeypress="CheckNumeric(event);" MaxLength="9"></asp:TextBox>
        &nbsp;&nbsp;<small>Là kiểu số, Mặc định: Max +1</small>
    </p>
    <p>
        <label>Tiêu đề(Tiếng việt) <span style="color: red;">*</span> <span id="errTitle" runat="server" visible="false" class="input-notification error png_bg">Chưa nhập</span></label>
        <asp:TextBox ID="txtTitle" runat="server" CssClass="text-input medium-input" TextMode="MultiLine" Height="30px" MaxLength="300" Width="600px"></asp:TextBox>
    </p>
     <p>
        <label>Tiêu đề(Tiếng anh) <span style="color: red;">*</span> <span id="errTitleEng" runat="server" visible="false" class="input-notification error png_bg">Chưa nhập</span></label>
        <asp:TextBox ID="txtTitleEng" runat="server" CssClass="text-input medium-input backgroundEnglish" TextMode="MultiLine" Height="30px" MaxLength="300" Width="600px"></asp:TextBox>
    </p>
    <p>
        <label>Lời dẫn(Tiếng việt)</label>
        <asp:TextBox ID="txtSubTitle" runat="server" CssClass="text-input medium-input" TextMode="MultiLine" Height="60px" MaxLength="500" Width="600px"></asp:TextBox>
    </p>
    <p>
        <label>Lời dẫn(Tiếng anh)</label>
        <asp:TextBox ID="txtSubTitleEng" runat="server" CssClass="text-input medium-input backgroundEnglish" TextMode="MultiLine" Height="60px" MaxLength="500" Width="600px"></asp:TextBox>
    </p>
    <p>
        <label>Chi tiết (Max ngang 900) - Tiếng việt</label>
        <CKEditor:CKEditorControl ID="fckDetail" runat="server" Width="970" Height="400">
        </CKEditor:CKEditorControl>

    </p>
     <p>
        <label>Chi tiết (Max ngang 900) - Tiếng anh</label>
        <CKEditor:CKEditorControl ID="fckDetailEng"  CssClass="backgroundEnglish" runat="server" Width="970" Height="400">
        </CKEditor:CKEditorControl>

    </p>
    <p>
        <label>
            Chọn ảnh đại diện (285 x 200) &nbsp;&nbsp;&nbsp;<asp:FileUpload ID="fulImage" runat="server" ToolTip="Bạn hãy chọn ảnh ở đây" onchange="javascript:ImageURL();" />
        </label>

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
        <label>Chọn hiện thị trên trang chủ (Ẩn bỏ check)</label>
        <asp:CheckBox ID="chkSelectView" runat="server"></asp:CheckBox>

    </p>
    <p>
        <label>Chọn hiện thị (Ẩn bỏ check)</label>
        <asp:CheckBox ID="chkIshow" runat="server" Checked="true"></asp:CheckBox>

    </p>
    <p>

        <asp:Button runat="server" ID="btnAdd" CssClass="button" Text="Thêm" OnClick="btnAdd_Click" />
        <asp:Button runat="server" ID="btnEdit" CssClass="button" Text="Sửa" OnClick="btnEdit_Click" />
        <asp:Button runat="server" ID="btnCancel" CssClass="button" Text="Hủy bỏ" OnClick="btnCancel_Click" />
    </p>

    <br />
    <br />
    <%--list--%>
    <div class="content-box">
        <!-- Start Content Box -->

        <div class="content-box-header">

            <h3>Danh sách (<asp:Label ID="lblTotalItem" runat="server"></asp:Label>)</h3>

        </div>
        <!-- End .content-box-header -->

        <div class="content-box-content">




            <asp:GridView ID="gvList" runat="server"
                AutoGenerateColumns="False" CellPadding="3" OnRowCommand="gvList_RowCommand" OnRowDeleting="gvList_RowDeleting" OnRowCreated="gvList_RowCreated" OnRowDataBound="gvList_RowDataBound" ViewStateMode="Enabled">
                <AlternatingRowStyle BackColor="White" />

                <Columns>

                    <asp:TemplateField HeaderText="STT">
                        <ItemTemplate>
                            <%# Container.DataItemIndex+1%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tên chuyên mục">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Thứ tự">
                        <ItemTemplate>
                            <asp:Label ID="lblNumber" runat="server" Text='<%# Eval("CategoryOrder") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Hiển thị trang chủ">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtDisplayMain" runat="server" CommandArgument='<%#Eval("CategoryId")%>' CommandName="ShowMain" ToolTip="Hiển thị trang chủ?" OnClientClick="return confirm('Bạn có muốn chuyển trạng thái hay không?')">
                                <asp:Image ID="imgShowMain" Width="18" runat="server" />
                            </asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Hiển thị">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtDisplay" runat="server" CommandArgument='<%#Eval("CategoryId")%>' CommandName="Show" ToolTip="Hiển thị?" OnClientClick="return confirm('Bạn có muốn chuyển trạng thái hay không?')">
                                <asp:Image ID="imgShow" Width="18" runat="server" />
                            </asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Sửa">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtUpdate" runat="server" CommandArgument='<%# Eval("CategoryId") %>' CommandName="Edit" ToolTip="Sửa dữ liệu"><img width="16" src="images/icons/edit.png"/></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Xóa">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtDelete" runat="server" CommandArgument='<%# Eval("CategoryId") %>' CommandName="Delete" ToolTip="Xóa bản ghi này" OnClientClick="return confirm('Bạn có thực sự muốn xóa hay không?')"><img width="16" src="images/icons/cross.png"/></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px"></ItemStyle>
                    </asp:TemplateField>

                </Columns>

                <HeaderStyle BackColor="White" Font-Bold="True" BorderStyle="Solid" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" CssClass="main-content table thead th" Font-Size="11pt" />
                <PagerSettings FirstPageText="Trang đầu" LastPageText="Trang cuối" NextPageText="Tiếp" PageButtonCount="5" PreviousPageText="Lùi" Mode="NumericFirstLast" />
                <PagerStyle BackColor="White" ForeColor="#4A3C8C" HorizontalAlign="Right" CssClass="number" />
                <RowStyle BackColor="#F3F3F3" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />

                <SortedAscendingCellStyle BackColor="#F4F4FD" />
                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                <SortedDescendingHeaderStyle BackColor="#3E3277" />

            </asp:GridView>
        </div>
        <!-- End .content-box-content -->

    </div>
    <!-- End .content-box -->


</asp:Content>
