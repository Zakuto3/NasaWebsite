using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        List<News> news;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["files"] != null)
            {
                news = (List<News>)Session["files"];
            }
            else
            {
                news = new List<News>();
            }
        }

        protected void uploadbtn_Click(object sender, EventArgs e)
        {
            if (uploader.HasFile)
            {
                uploader.SaveAs(Server.MapPath("~\\Images\\") + uploader.FileName);
                news.Add(new News(titleTextBox.Text, paragraphTextBox.Text, "./Images/"+uploader.FileName));
                Session["files"] = news;
                Response.Redirect("Main.aspx"); //Go to Main
            }
        }
    }
}