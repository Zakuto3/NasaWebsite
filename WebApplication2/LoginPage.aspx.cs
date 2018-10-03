using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace WebApplication2
{
    public partial class LoginPage : System.Web.UI.Page
    {
        string connectionString = "server=83.255.27.47;" +
            "user id=Bimane;" +
            "database=assignment3;" +
            "port=3306;" +
            "password=doggo21;" +
            "pooling=true;";
        

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["login"] != null)
            {
                if ((bool)Session["login"])
                {
                    Response.Redirect("Admin.aspx");
                }
                Session["login"] = false;
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            if (checkLogin(LoginName.Text, LoginPass.Text))
            {
                Session["login"] = true;
                Response.Redirect("Admin.aspx");
            }
            else
            {
                Debug.WriteLine("Invalid password");
                Session["login"] = false;
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

        protected bool checkLogin(string user, string pass)
        {
            string success;
            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand command = new MySqlCommand("CheckLogin", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("usr", user);
            command.Parameters.AddWithValue("pwd", pass);

            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            success = reader[0].ToString();
            reader.Close();
            connection.Close();
            if (success == "0")
            {
                return true;
            }
            return false;
        }

    }
}