using Mlp.Blog.Core.Domain.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mlp.Blog.Services.Menu.Abstract
{
    public interface IContentMenuService
    {
        IEnumerable<PgMenu> GetMainPgMenu(bool includeSinglPage = false);

        bool IsSinglPageMenu(PgTypeMenu typeMenu);
    }
}
