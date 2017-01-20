using Mlp.Blog.Core.Data;
using Mlp.Blog.Core.Domain.Page;
using Mlp.Blog.Core.Enums.Page;
using Mlp.Blog.Services.Menu.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mlp.Blog.Services.Menu
{
    public class ContentMenuService : IContentMenuService
    {
        #region Repositories
        private readonly IRepository<PgMenu, int> _repPgMenu;

        #endregion

        public ContentMenuService(IRepository<PgMenu,int> repPgMenu)
        {
            _repPgMenu = repPgMenu;
        }

        public IEnumerable<PgMenu> GetMainPgMenu(bool includeSinglPage = false)
        {
            var items = _repPgMenu.GetAll(x1=> x1.PgMenuChilds,x => x.TypeMenu ).Where(c => c.IsMainMenu()
           || (includeSinglPage && IsSinglPageMenu(c.TypeMenu))
            ).AsEnumerable();
            return items;
        }

        public bool IsSinglPageMenu(PgTypeMenu typeMenu)
        {
            if (typeMenu != null && typeMenu.Alias == Enum.GetName(typeof(PgTypeEnum), PgTypeEnum.SinglPage))
                return true;
            return false;
        }
    }
}
