using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Faculty.Helpers
{
    public static class CoursesList
    {
        public static MvcHtmlString CreateText(this HtmlHelper html, string[] content)
        {
            TagBuilder mainSpan = new TagBuilder("span");
            // TagBuilder center = new TagBuilder("center");
            for (int i = 0; i < content.Length; i++)
            {
                mainSpan.InnerHtml += content[i];
            }
            return MvcHtmlString.Create(mainSpan.ToString());
        }
    }
}