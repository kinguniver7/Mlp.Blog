using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mlp.Blog.Core.Data;
using Mlp.Blog.Core.Domain.Page;
using Mlp.Blog.WebMvc.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mlp.Blog.WebMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PageSettingController : Controller
    {
        private readonly IRepository<PgMenu, int> _repPgMenus;
        private readonly IRepository<PgTypeMenu, int> _repPgTypesOfMenu;

        public PageSettingController(IRepository<PgMenu, int> repPgMenus, IRepository<PgTypeMenu, int> repPgTypesOfMenu)
        {
            _repPgMenus = repPgMenus;
            _repPgTypesOfMenu = repPgTypesOfMenu;
        }
        [HttpGet]
        
        public IActionResult Index(int id)
        {
            var pgMenu = _repPgMenus.GetById(id);

            var model = new PageSettingViewModel();
            model.MenuInfo = new PgMenuViewModel
            {
                Id = pgMenu.Id,
                Name = pgMenu.Name,
                Action = pgMenu.Name,
                Anchor = pgMenu.Anchor,
                Area = pgMenu.Area,
                Controller = pgMenu.Controller,
                IsActive = pgMenu.IsActive
            };

            return View(model);
        }

        /// <summary>
        /// Update info for menu
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateMenuInfo(PgMenuViewModel model)
        {
            if (model.Id < 1)
                return NotFound();
            var entity = _repPgMenus.GetById(model.Id);
            entity.Name = model.Name;
            entity.IsActive = model.IsActive;
            entity.Action = model.Action;
            entity.Anchor = model.Anchor;
            entity.Area = model.Area;
            entity.Controller = model.Controller;
            entity.FaIcon = model.FaIcon;
            entity.Tooltip = model.Tooltip;
            _repPgMenus.Update(entity);

            return RedirectToAction("Index", new { id = model.Id });
        }

        /// <summary>
        /// Create new page
        /// </summary>
        /// <returns></returns>
        public IActionResult CreatePage()
        {
            var types = _repPgTypesOfMenu.GetAll().Select(x => new { Id = x.Id, Value = x.Name });
            var model = new CreatePageViewModel();
            model.TypePageList = new SelectList(types, "Id", "Value");
            return View(model);
        }
    }
}