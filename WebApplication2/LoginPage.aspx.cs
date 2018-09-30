using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class LoginPage : System.Web.UI.Page
    {
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

            if (Session["login"] != null)
            {
                if ((bool)Session["login"])
                {
                    logoutBtn.Style.Add(HtmlTextWriterStyle.Display, "block");
                    adminBtn.Text = "Admin";
                }
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            Session["login"] = true;
            Response.Redirect("Admin.aspx");
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