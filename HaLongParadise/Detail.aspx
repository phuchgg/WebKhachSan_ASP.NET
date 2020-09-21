<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMasterPage.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="HaLongParadise.Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
  

    <%--content--%>
    <div class="main" runat="server" id="ListRoom">
        <asp:Repeater ID="rptRoomList" runat="server">
            <ItemTemplate>
                <a href="Detail.aspx?ID=<%#Eval("CategoryId") %>" class="button_room"><%#Eval("Title") %></a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="main">

        <div class="content">
            <div class="title">
                <asp:Literal ID="ltrTitle" runat="server"></asp:Literal></div>
            <div class="detail_box">
                <asp:Literal ID="ltrDetail" runat="server"></asp:Literal>
            </div>

        </div>
    </div>
</asp:Content>
