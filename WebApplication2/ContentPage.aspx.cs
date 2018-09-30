using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class ContentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {       
            if (Request.QueryString["index"] != null && Session["files"] != null)
            {             
                int index;
                if (Int32.TryParse(Request.QueryString["index"], out index))
                {
                    List<News> news = (List<News>)Session["files"];
                    ContentTitle.InnerHtml = news[index].Title;
                    ContentParagraph.InnerHtml = news[index].Paragraph;
                    if (GetFileInfo.IsPhoto(news[index].src))
                    {
                        ContentImg.Src = news[index].src;
                        ContentImg.Style.Add("display", "block");
                    }
                    else
                    {
                        ContentVid.Src = news[index].src;
                        ContentVid.Style.Add("display", "block");
                    }                   
                }
            }            
        }

        protected void adminBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx"); // Go to AdminPage
        }
    }
}