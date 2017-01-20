using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mlp.Blog.Core.Data;
using Mlp.Blog.Core.Domain.Page;
using Mlp.Blog.WebMvc.Areas.Admin.Models;

namespace Mlp.Blog.WebMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PageSettingController : Controller
    {
        private readonly IRepository<PgMenu, int> _repPgMenu;
        public PageSettingController(IRepository<PgMenu, int> repPgMenu)
        {
            _repPgMenu = repPgMenu;
        }
        [HttpGet]
        
        public IActionResult Index(int id)
        {
            var pgMenu = _repPgMenu.GetById(id);

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

        [HttpPost]
        public IActionResult UpdateMenuInfo(PgMenuViewModel model)
        {
            if (model.Id < 1)
                return NotFound();
            var entity = _repPgMenu.GetById(model.Id);
            entity.Name = model.Name;
            entity.IsActive = model.IsActive;
            entity.Action = model.Action;
            entity.Anchor = model.Anchor;
            entity.Area = model.Area;
            entity.Controller = model.Controller;
            entity.FaIcon = model.FaIcon;
            entity.Tooltip = model.Tooltip;
            _repPgMenu.Update(entity);

            return RedirectToAction("Index", new { id = model.Id });
        }
    }
}