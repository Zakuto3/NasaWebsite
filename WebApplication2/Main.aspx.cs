using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Web.UI.HtmlControls;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {

       protected void Page_Load(object sender, EventArgs e)
       {
            
            if(Session["files"] != null)
            {
                List<News> news = (List<News>)Session["files"];
                int index = 0;
                foreach (var item in news)
                {
                    CreateNews(item, index);
                    index++;
                }             
            }
        }


       protected void AdminBtn_Onclick(object sender, EventArgs e)
       {
            Response.Redirect("LoginPage.aspx"); // Go to AdminPage
       }

        private void CreateNews(News item, int index)
        {
            HtmlGenericControl NewDiv = new HtmlGenericControl("DIV");
            NewDiv.ID = "scroll-slide";
            NewDiv.Attributes.Add("class", "slide-close");

            HtmlGenericControl Link = new HtmlGenericControl("A");
            Link.Attributes.Add("Href", "ContentPage.aspx?index="+index+"");

            HtmlGenericControl TextSpan = new HtmlGenericControl("SPAN");
            TextSpan.Attributes.Add("class", "cell-text");
            TextSpan.Style.Add(HtmlTextWriterStyle.Padding, "0% 0% 5% 2%");

            HtmlGenericControl Title = new HtmlGenericControl("SPAN");
            Title.Attributes.Add("class", "title");
            Title.InnerText = item.Title;

            HtmlGenericControl Paragraph = new HtmlGenericControl("SPAN");
            Paragraph.Attributes.Add("class", "promoted-article-text");
            Paragraph.InnerText = (item.Paragraph.Length <= 40) ? item.Paragraph : item.Paragraph.Substring(0,40)+"...";

            HtmlGenericControl img = new HtmlGenericControl("IMG");
            string image = GetFileInfo.IsPhoto(item.src) ? item.src : "./Images/defaultplay.png";
            img.Attributes.Add("src", image);
            img.Attributes.Add("class", "images");

            TextSpan.Controls.Add(Title);
            TextSpan.Controls.Add(Paragraph);
            Link.Controls.Add(TextSpan);
            Link.Controls.Add(img);
            NewDiv.Controls.Add(Link);
            slider.Controls.Add(NewDiv);
        }
    }
}