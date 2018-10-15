    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Web.Script.Serialization;

namespace WebApplication2
{
    public partial class AjaxReq : System.Web.UI.Page
    {
        string connectionString = "server=--------;" +
            "user id=Bimane;" +
            "database=assignment3;" +
            "port=3306;" +
            "password=-------;" +
            "pooling=true;";

        string search;
        string result;
        protected void Page_Load(object sender, EventArgs e)
        {   
            Response.Clear();
            search = Request.QueryString["search"];
            result = SearchDB(search);
            
            Response.Write(result);
            Response.End();
        }

        protected string SearchDB(string search)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<object> result = new List<object>();
            MySqlConnection conn = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("SearchTitle", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("search", search);

            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new { title = (string)reader[0], id = reader[1].ToString() });
            }
            reader.Close();
            conn.Close();

            return serializer.Serialize(result);
        }

        
    }
}