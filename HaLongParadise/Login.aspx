<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HaLongParadise.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

    <title>Đăng nhập </title>
    <link href="../img/icon.png" rel="shortcut icon" type="image/x-icon" />

    <link rel="stylesheet" href="css/reset_admin.css" type="text/css" media="screen" />

    <!-- Main Stylesheet -->
    <link rel="stylesheet" href="css/style_admin.css" type="text/css" media="screen" />

    <!-- Invalid Stylesheet. This makes stuff look pretty. Remove it if you want the CSS completely valid -->
    <link rel="stylesheet" href="css/invalid_admin.css" type="text/css" media="screen" />

   <%-- <link rel="stylesheet" href="../css/blue_admin.css" type="text/css" media="screen" />--%>

    <script type="text/javascript" src="scripts/jquery-1.3.2.min.js"></script>

    <!-- jQuery Configuration -->
    <script type="text/javascript" src="scripts/simpla.jquery.configuration.js"></script>

    <!-- Facebox jQuery Plugin -->
    <script type="text/javascript" src="scripts/facebox.js"></script>

    <!-- jQuery WYSIWYG Plugin -->
    <script type="text/javascript" src="scripts/jquery.wysiwyg.js"></script>
</head>
<body id="login">
    <%-- <div id="footer_login">
                    <small> Design by <a href="http://itone.com.vn">itOne.com.vn</a>
                    </small>
                </div>--%>
     <div id="login-top" style="text-align:center; background-color:#f4f0e2; height:90px;padding-top:70px;">

            <img id="logo" src="images/logo.png" alt="Simpla Admin logo" width="250" />
        </div>
    <div class="line_orn"></div>
    <div id="login-wrapper" class="png_bg">
       
        <!-- End #logn-top -->
        <form id="Form1" runat="server">
        <div id="login-content" >


            <div class="notification information png_bg">
                <div id="messAccount" runat="server">
                    Chưa nhập tài khoản và mật khẩu.
					
                </div>
            </div>

            <p>
                <label>Tài khoản</label>
                <asp:TextBox ID="txtAccount" runat="server" CssClass="text-input" ></asp:TextBox>             
            </p>
            <div class="clear"></div>
            <p>
                <label>Mật khẩu</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="text-input" TextMode="Password">123</asp:TextBox>
            </p>
            <%--<div class="clear"></div>
            <p id="remember-password">
                <asp:CheckBox ID="chkRemember" runat="server"/>Ghi nhớ
				
            </p>--%>
            <div class="clear"></div>
            <p>
                <asp:Button runat="server" ID="btnLogin" CssClass="button" Text="Đăng nhập" OnClick="btnLogin_Click" />
            </p>

        </div>
        <!-- End #login-content -->
            </form>
    </div>
    <!-- End #login-wrapper -->

</body>
</html>
