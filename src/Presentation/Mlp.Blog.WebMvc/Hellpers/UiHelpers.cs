using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mlp.Blog.WebMvc.Hellpers
{
    public static class CssHelpers
    {
        public static HtmlString TextDecoration_LineThrough(this IHtmlHelper helper, bool active)
        {
            return new HtmlString(string.Concat("text-decoration:", active ? "line-through" : "none"));
        }
    }
}
