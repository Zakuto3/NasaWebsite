<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication2.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WebLab</title>
    <link rel="stylesheet" href="Style.css">
</head>
<body>
    <form id="form1" runat="server">
        <div id="content">
            <div id='main-header'>
				
				<a href="Main.aspx"><img id="logo" src="Images/Logo.jpg"></a>
				<input id="search-text" type="text" placeholder="Search">
				<img src="./Images/search-btn-image.png" id="search-btn">
				<img src="./Images/share-btn-image.png" id="share-btn">
                <asp:Button ID="adminBtn"  CausesValidation="false" CssClass="btn" runat="server" Text="Log in"  OnClick="adminBtn_Click"/>
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
            <div class="adminPage-form">
                <h3>Fill in the form</h3>
                <div>
                    <div id="title-box">
                        Enter Title 
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="titleTextBox" ErrorMessage="Title required" CssClass="errormsg">
                        </asp:RequiredFieldValidator><br /> 
                        <asp:TextBox TextMode="SingleLine" runat="server" ID="titleTextBox" CssClass="textbox"></asp:TextBox>
                    </div>
                    <div id="paragraph-box">
                        Enter paragraph 
                        <asp:CustomValidator runat="server" ClientValidationFunction="validatePara" ErrorMessage="At least 10 characters required" CssClass="errormsg">
                        </asp:CustomValidator><br /> 
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="paragraphTextBox" CssClass="textbox"></asp:TextBox>
                    </div>
                    <div id="category-box">
                        Select a category<br />
                        <asp:DropDownList ID="categorylist" CssClass="textbox" runat="server">
                            <asp:listitem>Just space news!</asp:listitem>
                            <asp:ListItem>Astrophysics</asp:ListItem>
                            <asp:listitem>Doggos</asp:listitem>
                            <asp:listitem>Climate</asp:listitem>
                            <asp:listitem>Space Travel</asp:listitem>
                        </asp:DropDownList>
                    </div>
                    <div id="keywords-box">
                        Select keywords<br />
                        <asp:CheckBoxList ID="keywordslist"  CssClass="textbox" runat="server">
                            <asp:ListItem>Doggos</asp:ListItem>
                            <asp:ListItem>Space</asp:ListItem>
                            <asp:ListItem>Star</asp:ListItem>
                            <asp:ListItem>Earth</asp:ListItem>
                        </asp:CheckBoxList>
                    </div>
                    <div id="upload-box">
                        Upload image or video
                        <br /><asp:FileUpload ID="uploader" CssClass="textbox" runat="server" /><br />
                    </div>
                    <asp:Button ID="uploadbtn" CssClass="btn" runat="server" Text="Submit"  OnClick="uploadbtn_Click"/>
                

                </div>
            </div>
            
         </div>
    </form>
    <script>
        function validatePara(oSrc, args) {
            let textbox = document.getElementById("paragraphTextBox");
            if (textbox.value == "" || textbox.value.length < 10) {
                args.IsValid = false;
            }
        }
    </script>
</body>
</html>
