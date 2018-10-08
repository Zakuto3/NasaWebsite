using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace WebApplication2
{
    public partial class ContentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {       
            if (Request.QueryString["index"] != null)
            {             
                int index;
                if (Int32.TryParse(Request.QueryString["index"], out index))
                {   //Dont forget to change to 83.255.27.47   
                    string connectionString = "server=127.0.0.1;" +
                    "user id=Bimane;" +
                    "database=assignment3;" +
                    "port=3306;" +
                    "password=doggo21;" +
                    "pooling=true;";

                    MySqlConnection connection = new MySqlConnection(connectionString);
                    try
                    {
                        connection.Open();
                        MySqlCommand command = new MySqlCommand("SELECT * FROM assignment3.content;", connection);
                        MySqlDataReader reader = command.ExecuteReader();

                        int count = 0;
                        while (reader.Read())
                        {
                            if (count == index)
                            {
                                loadContent(reader);
                            }
                            count++;
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                    connection.Close();              
                }
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

        private void loadContent(MySqlDataReader reader)
        { 
            ContentTitle.InnerHtml = reader["title"].ToString();
            keywords.InnerHtml = reader["keywords"].ToString();
            category.InnerHtml = reader["category"].ToString();
            ContentParagraph.InnerHtml = reader["text"].ToString().Replace("\n", "<br>"); //Newlines did not show
            ContentuserID.InnerHtml = "created by : " + reader["username"].ToString();
            if (GetFileInfo.IsPhoto(reader["imgurl"].ToString()))
            {
                ContentImg.Src = "./Images/" + reader["imgurl"].ToString();
                ContentImg.Style.Add("display", "block");
            }
            else
            {
                ContentVid.Src = "./Images/" + reader["imgurl"].ToString();
                ContentVid.Style.Add("display", "block");
            }
        }

        protected void adminBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx"); // Go to AdminPage
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session["login"] = false;
            logoutBtn.Style.Add(HtmlTextWriterStyle.Display, "none");
            adminBtn.Text = "Log in";
        }
    }
}