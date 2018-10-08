using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string connectionString = "server=127.0.0.1;" +
            "user id=Bimane;" +
            "database=assignment3;" +
            "port=3306;" +
            "password=doggo21;" +
            "pooling=true;";

    
        protected void Page_Load(object sender, EventArgs e)
        {
            //Prevent "enter" from submitting form
            titleTextBox.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
           
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
                string keyword = getKeywords();
                string usrname = (string)Session["username"];
                uploader.SaveAs(Server.MapPath("~\\Images\\") + uploader.FileName);

                MySqlConnection connection = new MySqlConnection(connectionString);
                MySqlCommand command = new MySqlCommand("CALL ADDcontent("+"'"+titleTextBox.Text+"','"+ paragraphTextBox.Text + "','" + uploader.FileName + "','" + categorylist.Text + "','" + keyword + "','" + usrname + "'" +");", connection);

                command.Connection.Open();
                command.ExecuteNonQuery();                        
                command.Connection.Close();

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