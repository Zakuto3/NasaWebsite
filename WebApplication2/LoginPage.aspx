<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="true" CodeBehind="LoginPage.aspx.cs" Inherits="WebApplication2.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="Style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="content">
            <div id='main-header'>
				
				<a href="Main.aspx"><img id="logo" src="Images/Logo.jpg"></a>
				<input id="search-text" type="text" placeholder="Search">
				<img src="./Images/search-btn-image.png" id="search-btn">
				<img src="./Images/share-btn-image.png" id="share-btn">
                <asp:Button ID="adminBtn" CausesValidation="false" CssClass="btn" runat="server" Text="Log in"  OnClick="adminBtn_Click"/>
                <asp:Button ID="logoutBtn" CausesValidation="false" CssClass="btn" runat="server" Text="Log out"  OnClick="logoutBtn_Click"/>
				
				<div class="big-header">
					<span class="big-header-text">Mission</span> |
					<span class="big-header-text">Galleries</span> |
					<span class="big-header-text">NASA TV</span> |
					<span class="big-header-text">Downloads</span> |
					<span class="big-header-text">About</span> |
					<span class="big-header-text">NASA Audiences</span>
				</div>

				<div class="small-header">
					<span class="small-header-text">International Space Station</span> |
					<span class="small-header-text">Journey to Mars</span> |
					<span class="small-header-text">Earth</span> |
					<span class="small-header-text">Technology</span> |
					<span class="small-header-text">Solar System and Beyond</span> |
					<span class="small-header-text">Education</span> |
					<span class="small-header-text">History</span> |
					<span class="small-header-text">Benefits to You</span>
				</div>
			</div>       
            <div class="loginPage-form">
                <asp:Panel runat="server" DefaultButton="loginbtn"> <%--Triggers loginbtn Onclick when "enter" is pressed--%>
                    <div class="loginforms">
                        
                        Enter Name <br/> <asp:TextBox ID="LoginName" TextMode="SingleLine" runat="server" CssClass="textbox"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="LoginName" ErrorMessage="Username required" CssClass="errormsg">
                        </asp:RequiredFieldValidator><br/>
                        
                        Enter Password <br/> <asp:TextBox ID="LoginPass" TextMode="password" runat="server" CssClass="textbox"></asp:TextBox> 
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="LoginPass" ErrorMessage="Password required" CssClass="errormsg">
                        </asp:RequiredFieldValidator>
                   </div>

                    <asp:Button ID="loginbtn" CssClass="btn" runat="server" Text="Login"  OnClick="loginBtn_Click"/>
                </asp:Panel>
            </div>
        </div>
    </form>
</body>
</html>
