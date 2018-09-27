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
                foreach (var item in news)
                {
                    CreateNews(item);
                }             
            }
        }


       protected void AdminBtn_Onclick(object sender, EventArgs e)
       {
            Response.Redirect("WebForm2.aspx"); // Go to AdminPage
       }

        private void CreateNews(News item)
        {
            HtmlGenericControl NewDiv = new HtmlGenericControl("DIV");
            NewDiv.ID = "scroll-slide";
            NewDiv.Attributes.Add("class", "slide-close");

            HtmlGenericControl TextSpan = new HtmlGenericControl("SPAN");
            TextSpan.Attributes.Add("class", "cell-text");
            TextSpan.Style.Add(HtmlTextWriterStyle.Padding, "0% 0% 5% 2%");

            HtmlGenericControl Title = new HtmlGenericControl("SPAN");
            Title.Attributes.Add("class", "title");
            Title.InnerText = item.Title;

            HtmlGenericControl Paragraph = new HtmlGenericControl("SPAN");
            Paragraph.Attributes.Add("class", "promoted-article-text");
            Paragraph.InnerText = item.Paragraph;

            HtmlGenericControl img = new HtmlGenericControl("IMG");
            img.Attributes.Add("src", item.src);
            img.Attributes.Add("class", "images");

            TextSpan.Controls.Add(Title);
            TextSpan.Controls.Add(Paragraph);
            NewDiv.Controls.Add(TextSpan);
            NewDiv.Controls.Add(img);
            slider.Controls.Add(NewDiv);
        }
    }
}