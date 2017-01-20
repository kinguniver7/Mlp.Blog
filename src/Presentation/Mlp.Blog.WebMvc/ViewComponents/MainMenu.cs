using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mlp.Blog.Services.Menu.Abstract;

namespace Mlp.Blog.WebMvc.ViewComponents
{
    public class MainMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}