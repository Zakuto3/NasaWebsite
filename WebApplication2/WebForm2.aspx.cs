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
        protected void Page_Load(object sender, EventArgs e)
        {
            paragraphBox.Text = "lol";
            
        }

        protected void uploadbtn_Click(object sender, EventArgs e)
        {
            if (uploader.HasFile)
            {
                Debug.WriteLine("HOUSTON, WE ARE IN!");
                
                uploader.SaveAs("C:\\Users\\Simon\\Desktop\\School\\DVA231\\WebLabs\\WebApplication2\\Images\\" + uploader.FileName);
                Session["file1"] = uploader.FileName;
            }
        }
    }
}