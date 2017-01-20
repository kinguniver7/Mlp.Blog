using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mlp.Blog.Core.Data;
using Mlp.Blog.Core.Domain.Page;

namespace Mlp.Blog.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<PgTypeMenu, int> _repTypeMenus;

        public HomeController(IRepository<PgTypeMenu, int> repTypeMenus)
        {
            _repTypeMenus = repTypeMenus;
        }

        public IActionResult Index()
        {
            ViewBag.List = _repTypeMenus.GetAll();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
