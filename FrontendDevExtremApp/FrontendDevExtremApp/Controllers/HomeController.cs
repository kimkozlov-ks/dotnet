using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace FrontendDevExtremApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataLoader _dataloader;

        public HomeController(IDataLoader dataLoader)
        {
            _dataloader = dataLoader;
        }

        public IActionResult Index()
        {
            var cookie = Request.Cookies["settings"];

            _dataloader.AddSettings(cookie);

            return View(new ComponentSettings(cookie));
        }
    }
}
