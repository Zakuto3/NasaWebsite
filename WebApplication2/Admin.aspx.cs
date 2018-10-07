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
            //Prevent "enter" from submitting form
            titleTextBox.Attributes.Add("onkeydown", "return (event.keyCode!=13);");

            if (Session["files"] != null)
            {
                news = (List<News>)Session["files"];
            }
            else
            {
                news = new List<News>();
            }

            if (Session["login"] != null)
            {
                if ((bool)Session["login"])
                {
                    logoutBtn.Style.Add(HtmlTextWriterStyle.Display, "block");
                    adminBtn.Text = "Admin";
                }
            }
        }

        protected void uploadbtn_Click(object sender, EventArgs e)
        {
            if (uploader.HasFile)
            {
                uploader.SaveAs(Server.MapPath("~\\Images\\") + uploader.FileName);

                news.Add(new News(titleTextBox.Text, paragraphTextBox.Text, "./Images/"+uploader.FileName, categorylist.Text, getKeywords()));

                Session["files"] = news;
                Response.Redirect("Main.aspx"); //Go to Main
            }
        }

        protected void adminBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx"); // Go to AdminPage
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session["login"] = false;
            logoutBtn.Style.Add(HtmlTextWriterStyle.Display, "none");
            adminBtn.Text = "Log in";
            Response.Redirect("Main.aspx");
        }

       protected string getKeywords()
        {
            string keywords = "";
            foreach (ListItem item in keywordslist.Items)
            {
                if (item.Selected) keywords += item+",";
            }
            if(keywords != "")
            {
                return keywords.Remove(keywords.LastIndexOf(","));
            }
            else
            {
                return "";
            }
        }
    }
}