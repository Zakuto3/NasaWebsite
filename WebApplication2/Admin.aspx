<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication2.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WebLab</title>
    <link rel="stylesheet" href="Style.css">
</head>
<body>
    <form id="form1" runat="server">
        <div id="adminPage-content">
            <div class="adminPage-form">
                <h3>Fill in the form</h3>
                <div>
                    <div id="title-box">
                        Enter Title <br /> <asp:TextBox TextMode="SingleLine" runat="server" ID="titleTextBox" CssClass="textbox"></asp:TextBox>
                    </div>
                    <div id="paragraph-box">
                        Enter paragraph <br /> <asp:TextBox TextMode="MultiLine" runat="server" ID="paragraphTextBox" CssClass="textbox"></asp:TextBox>
                    </div>
                    <div id="upload-box">
                        Upload image or video <br /><asp:FileUpload ID="uploader" CssClass="textbox" runat="server" /><br />
                    </div>
                    <asp:Button ID="uploadbtn" CssClass="btn" runat="server" Text="Submit"  OnClick="uploadbtn_Click"/>
                

                </div>
            </div>
            
         </div>
    </form>
</body>
</html>
