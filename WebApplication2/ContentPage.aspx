<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContentPage.aspx.cs" Inherits="WebApplication2.ContentPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>WebLab</title>
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
                <asp:Button ID="adminBtn" CssClass="btn" runat="server" Text="Log in"  OnClick="adminBtn_Click"/>
                <asp:Button ID="logoutBtn" CssClass="btn" runat="server" Text="Log out"  OnClick="logoutBtn_Click"/>
				
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
              <div class="contentPage-form"> 
            <h3 runat="server" id="ContentTitle"></h3>
            <img runat="server" id="ContentImg" src="#" class="contentPage-image" style="display:none"/>
            <video runat="server" id="ContentVid" controls="controls" class="contentPage-image" style="display:none">
                <source src="/Images/cameradoggo.mp4" type="video/mp4" />
                <source src="/Images/cameradoggo.mp4.webm" type="video/webm" />
                <source src="/Images/cameradoggo.mp4.ogv" type="video/ogg" />
            </video>
            <h1 runat="server" id="ContentParagraph"></h1>         
            </div>
         </div>
        
    </form>
</body>
</html>
