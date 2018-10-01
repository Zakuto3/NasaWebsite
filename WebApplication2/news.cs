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
        public News(string title, string paragraph, string source, string category, string keywords)
        {
            Title = title;
            Paragraph = paragraph;
            src = source;
            Category = category;
            Keywords = keywords;
        }
        public string Title;
        public string Paragraph;
        public string src;
        public string Category;
        public string Keywords;
    }

    public class GetFileInfo
    {
        public static List<string> GetAllPhotosExtensions()
        {
            var list = new List<string>();
            list.Add(".jpg");
            list.Add(".png");
            list.Add(".bmp");
            list.Add(".gif");
            list.Add(".jpeg");
            list.Add(".tiff");
            return list;
        }

        public static bool IsPhoto(string fileName)
        {
            var list = GetFileInfo.GetAllPhotosExtensions();
            var filename = fileName.ToLower();
            bool isThere = false;
            foreach (var item in list)
            {
                if (filename.EndsWith(item))
                {
                    isThere = true;
                    break;
                }
            }
            return isThere;
        }

      
    }
}