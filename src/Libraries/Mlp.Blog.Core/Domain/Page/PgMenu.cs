using Mlp.Blog.Core.Enums.Page;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mlp.Blog.Core.Domain.Page
{
    /// <summary>
    /// Navigation for pages
    /// </summary>
    public class PgMenu : IKey<int>
    {
        public int Id { get; set; }
        
        public string Area { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public string FaIcon { get; set; }
        
        public string Name { get; set; }

        public string Anchor { get; set; }

        public string Tooltip { get; set; }

        public bool IsActive { get; set; }

        public int? PgMenuParentId { get; set; }

        [ForeignKey("PgMenuParentId")]
        public virtual PgMenu PgMenuParent { get; set; }

        public virtual IEnumerable<PgMenu> PgMenuChilds { get; set; }

        public int TypeMenuId { get; set; }
        
        [ForeignKey("TypeMenuId")]
        public virtual PgTypeMenu TypeMenu { get; set; }

        public PgMenu()
        {
            PgMenuChilds = new HashSet<PgMenu>();
        }

        public bool IsMainMenu()
        {
            if (PgMenuParentId == null || PgMenuParentId < 1)
                return true;
            return false;
        }

        

    }
}
