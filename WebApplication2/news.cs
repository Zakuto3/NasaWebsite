using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Web.UI.HtmlControls;

namespace WebApplication2
{

    public class News
    {
        public News(string title, string paragraph, string source)
        {
            Title = title;
            Paragraph = paragraph;
            src = source;
        }
        public string Title;
        public string Paragraph;
        public string src;
    }

}