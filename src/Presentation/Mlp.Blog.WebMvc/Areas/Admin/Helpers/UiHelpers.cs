using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mlp.Blog.WebMvc.Areas.Admin.Helpers
{
    public static partial class UiHelpers
    {
        public static IHtmlContent PageTitle(this IHtmlHelper helper, string title)
        {
            var html = $@"<div class='page-title'>
        <div class='title_left'>
            <h3>{title}</h3>
        </div>
    </div>
    <div class='clearfix'></div>";
            return new HtmlString(html); 
        }
    }
}
