﻿using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
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
            Debug.WriteLine("Start of connection");
            //Dont forget to change to right IP
            string connectionString = "server=---------;" +
            "user id=Bimane;" +
            "database=assignment3;" +
            "port=3306;" +
            "password=--------;" +
            "pooling=true;";
             
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM assignment3.content;", connection);
                MySqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    CreateNews(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            connection.Close();

            if (Session["login"] != null)
            {
                if ((bool)Session["login"])
                {
                    logoutBtn.Style.Add(HtmlTextWriterStyle.Display, "block");
                    adminBtn.Text = "Admin";
                }
            }
        }

       protected void adminBtn_Click(object sender, EventArgs e)
       {
            Response.Redirect("LoginPage.aspx"); // Go to AdminPage
       }

        private void CreateNews(MySqlDataReader item)
        {
            HtmlGenericControl NewDiv = new HtmlGenericControl("DIV");
            NewDiv.ID = "scroll-slide";
            NewDiv.Attributes.Add("class", "slide-close");

            HtmlGenericControl Link = new HtmlGenericControl("A");
            Link.Attributes.Add("Href", "ContentPage.aspx?index=" + item["id"].ToString());

            HtmlGenericControl TextSpan = new HtmlGenericControl("SPAN");
            TextSpan.Attributes.Add("class", "cell-text");
            TextSpan.Style.Add(HtmlTextWriterStyle.Padding, "0% 0% 5% 2%");

            HtmlGenericControl Title = new HtmlGenericControl("SPAN");
            Title.Attributes.Add("class", "title");
            Title.InnerText = item["title"].ToString(); 

            HtmlGenericControl Keywords = new HtmlGenericControl("SPAN");
            Keywords.Attributes.Add("class", "keywords");
            Keywords.InnerText = item["keywords"].ToString();

            HtmlGenericControl Category = new HtmlGenericControl("SPAN");
            Category.Attributes.Add("class", "category");
            Category.InnerText = item["category"].ToString();

            HtmlGenericControl Paragraph = new HtmlGenericControl("SPAN");
            Paragraph.Attributes.Add("class", "promoted-article-text");
            Paragraph.InnerText = (item["text"].ToString().Length <= 40) ? item["text"].ToString() : item["text"].ToString().Substring(0,40)+"...";

            HtmlGenericControl img = new HtmlGenericControl("IMG");
            string image = GetFileInfo.IsPhoto(item["imgurl"].ToString()) ? "./Images/"+item["imgurl"].ToString() : "./Images/defaultplay.png";
            img.Attributes.Add("src", image);
            img.Attributes.Add("class", "images");
            Debug.WriteLine(item["text"].ToString());
            TextSpan.Controls.Add(Title);
            TextSpan.Controls.Add(Paragraph);
            Link.Controls.Add(Keywords);
            Link.Controls.Add(Category);
            Link.Controls.Add(TextSpan);
            Link.Controls.Add(img);
            NewDiv.Controls.Add(Link);
            slider.Controls.Add(NewDiv);
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session["login"] = false;
            logoutBtn.Style.Add(HtmlTextWriterStyle.Display, "none");
            adminBtn.Text = "Log in";
        }

        
    }
}