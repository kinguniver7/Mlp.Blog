using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mlp.Blog.WebMvc.Areas.Admin.Models
{
    public class PageSettingViewModel
    {
        public PgMenuViewModel MenuInfo { get; set; }


    }

    public class PgMenuViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Area { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public string FaIcon { get; set; }
        
        public string Anchor { get; set; }

        public string Tooltip { get; set; }

        public bool IsActive { get; set; }

    }
}
