<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="WebApplication2.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="Style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="content">

            <div class="loginPage-form">

                <div class="loginforms">
                    Enter Name <br/> <asp:TextBox ID="LoginName" TextMode="SingleLine" runat="server" CssClass="textbox"></asp:TextBox><br/>

                    Enter Password <br/> <asp:TextBox ID="LoginPass" TextMode="password" runat="server" CssClass="textbox"></asp:TextBox>            
               </div>

                <asp:Button ID="loginbtn" CssClass="btn" runat="server" Text="Login"  OnClick="loginBtn_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
