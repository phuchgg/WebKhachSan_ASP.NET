<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="HaLongParadise.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
         $(document).ready(function () {       //Error happens here, $ is not defined.
             $('.menu_home').removeClass('menu_home').addClass('menu_home_select');
         });
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
  

    <%--content--%>
    <div class="main">
        <div class="content">
            <div class="title"><asp:Label ID="Label1" Text='<%$ Resources:Resource, GioiThieu%>' runat="server" ></asp:Label></div>
            <div class="about_box">
                <img src="images/tmp.jpg" runat="server" id="imgHotel" class="about_img" width="250" height="185" />
                <div class="about_text">
                    <asp:Literal ID="txtInfo" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="title"><asp:Label ID="Label2" Text='<%$ Resources:Resource, ThongTin%>' runat="server" ></asp:Label></div>
            <div style="width:970px;overflow:visible;">

                <asp:Repeater ID="rptTopHome" runat="server">
                    <ItemTemplate>
                        <div class="top_item">
                            <a href="Detail.aspx?ID=<%#Eval("CategoryId") %>">
                                <img src="/<%#Eval("ImageUrl") %>" class="top_img" width="285" height="200" />
                                <div class="top_title">
                                      <% if (Session["lang"] != null && Session["lang"].ToString() == "en")
                                                                    { %> <%# Eval("TitleEng") %><%}
                                                                    else
                                                                    { %><%# Eval("Title") %><% }%>
                                </div>
                            </a>
                            <div class="top_text">
                                  <% if (Session["lang"] != null && Session["lang"].ToString() == "en")
                                                                    { %> <%# Eval("SummaryEng") %><%}
                                                                    else
                                                                    { %><%# Eval("Summary") %><% }%>
                            </div>
                            <a href="Detail.aspx?ID=<%#Eval("CategoryId") %>" class="button_gray"><asp:Label ID="Label2" Text='<%$ Resources:Resource, ChiTiet%>' runat="server" ></asp:Label></a>
                        </div>
                    </ItemTemplate>

                </asp:Repeater>


                <%--<div class="top_item">
                    <a href="#">
                    <img src="images/tmp.jpg" class="top_img" width="285" height="200" />
                    <div class="top_title">Hình ảnh</div>
                        </a>
                    <div class="top_text">Khách sạn là sự kết hợp giữa những  kiến trúc, không gian đẹp, thoáng mát, cung cấp đầy đủ tiện nghi, mời bạn cùng tham quan những hình ảnh về chúng tôi.</div>
                    <a href="#" class="button_gray">Chi tiết</a>
                </div>
                 <div class="top_item2">
                    <a href="#">
                    <img src="images/tmp.jpg" class="top_img" width="285" height="200" />
                    <div class="top_title">Hình ảnh</div>
                        </a>
                    <div class="top_text">Khách sạn là sự kết hợp giữa những  kiến trúc, không gian đẹp, thoáng mát, cung cấp đầy đủ tiện nghi, mời bạn cùng tham quan những hình ảnh về chúng tôi.</div>
                    <a href="#" class="button_gray">Chi tiết</a>
                </div>--%>
            </div>
        </div>
    </div>

   
</asp:Content>
