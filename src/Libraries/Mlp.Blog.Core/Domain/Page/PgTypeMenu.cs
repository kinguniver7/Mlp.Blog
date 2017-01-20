using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mlp.Blog.Core.Domain.Page
{
    /// <summary>
    /// Type of menu
    /// </summary>
    public class PgTypeMenu : IKey<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Unique Alias
        /// </summary>
        public string Alias { get; set; }

    }
}
