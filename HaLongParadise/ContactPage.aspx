<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMasterPage.Master" AutoEventWireup="true" CodeBehind="ContactPage.aspx.cs" Inherits="HaLongParadise.ContactPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
      

    <%--content--%>
    <div class="main">
        <div class="content">
            <div class="title"><asp:Label ID="Label4" Text='<%$ Resources:Resource, LienHe%>' runat="server" ></asp:Label></div>
            <div class="detail_box">
                  <asp:Literal ID="ltrContact" runat="server"></asp:Literal>
            </div>
            
        </div>
    </div>
</asp:Content>
