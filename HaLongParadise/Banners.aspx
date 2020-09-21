<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Banners.aspx.cs" Inherits="HaLongParadise.Banners" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="Server">
    <%--selected menu--%>
    <script>
        $(document).ready(function () {
            //menu cha
            $('#parenbanner').addClass('nav-top-item current');
            //menu con
            $('#banner').addClass('current');
        });
    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upNewsWait" runat="server">
        <ContentTemplate>
            <%--Content--%>
            <h3 class="title">Quản lý banner</h3>
            <ul class="shortcut-buttons-set">

                <li><a class="shortcut-button new-page" href="AddBanner.aspx"><span class="png_bg">Thêm banner
                </span></a></li>

            </ul>
            <!-- End .shortcut-buttons-set -->
            <div class="clear"></div>
            <!-- End .clear -->

            <div class="content-box">
                <!-- Start Content Box -->

                <div class="content-box-header">

                    <h3>Danh sách (<asp:Label ID="lblTotalItem" runat="server"></asp:Label>)</h3>

                </div>
                <!-- End .content-box-header -->

                <div class="content-box-content">

                    <div class="notification success png_bg" id="messSuccess" runat="server">
                        <a href="#" class="close">
                            <img src="../images/icons/cross_grey_small.png" title="Close this notification" alt="close" /></a>
                        <div id="messSuccessText" runat="server">
                            Xóa thành công!
                        </div>
                    </div>


                    <p>
                        <b>Chuyên mục</b>
                        <asp:DropDownList runat="server" ID="ddlCategory" CssClass="small-input"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                          
                        </asp:DropDownList>
                    </p>
                    <br />
                    <asp:GridView ID="gvList" runat="server"
                        AutoGenerateColumns="False" CellPadding="3" OnPageIndexChanging="gvList_PageIndexChanging" OnRowCommand="gvList_RowCommand" OnRowDeleting="gvList_RowDeleting" ViewStateMode="Enabled"
                        OnRowCreated="gvList_RowCreated" OnRowDataBound="gvList_RowDataBound" OnRowEditing="gvList_RowEditing"
                        PageSize="20" AllowPaging="True">
                        <AlternatingRowStyle BackColor="White" />

                        <Columns>
                            <asp:TemplateField HeaderText="STT">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="40px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Chọn">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkHeadSelect" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="40px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Ảnh">
                                <ItemTemplate>
                                    <image src='/<%# Eval("ImageAlbumUrl") %>' height="80"></image>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mô tả ảnh">
                                <ItemTemplate>
                                    <asp:Label ID="lbNote" runat="server" Text='<%#Eval("ImageAlbumText") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Thứ tự">
                                <ItemTemplate>
                                    <asp:Label ID="lbAdvisoryOrder" runat="server" Text='<%#Eval("ImageOrder") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Hiển thị">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtDisplay" runat="server" CommandArgument='<%#Eval("ImageAlbumId")%>' CommandName="Show" ToolTip="Hiển thị?" OnClientClick="return confirm('Bạn có muốn chuyển trạng thái hay không?')">
                                        <asp:Image ID="imgShow" Width="18" runat="server" />
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sửa">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtUpdate" runat="server" CommandArgument='<%# Eval("ImageAlbumId") %>' CommandName="Edit" ToolTip="Sửa dữ liệu"><img width="16" src="../images/icons/edit.png"/></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Xóa">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtDelete" runat="server" CommandArgument='<%# Eval("ImageAlbumId") %>' CommandName="Delete" ToolTip="Xóa bản ghi này" OnClientClick="return confirm('Bạn có thực sự muốn xóa hay không?')"><img width="16" src="../images/icons/cross.png"/></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px"></ItemStyle>
                            </asp:TemplateField>

                        </Columns>

                        <HeaderStyle BackColor="White" Font-Bold="True" BorderStyle="Solid" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" CssClass="main-content table thead th" Font-Size="11pt" />
                        <PagerSettings FirstPageText="Đầu" LastPageText="Cuối" NextPageText="Tiếp" PageButtonCount="10" PreviousPageText="Lùi" Mode="NumericFirstLast" />
                        <PagerStyle CssClass="paging" Font-Bold="True" />
                        <RowStyle BackColor="#F3F3F3" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />

                        <SortedAscendingCellStyle BackColor="#F4F4FD" />
                        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                        <SortedDescendingCellStyle BackColor="#D8D8F0" />
                        <SortedDescendingHeaderStyle BackColor="#3E3277" />

                    </asp:GridView>
                    <br />
                    <br />
                    <p>

                        <asp:Button runat="server" ID="btnDelete" CssClass="button" Text="Xóa nhiều" OnClick="btnDelete_Click" />
                    </p>

                </div>
                <!-- End .content-box-content -->

            </div>
            <!-- End .content-box -->
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
