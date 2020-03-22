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
        private readonly IParsable<ComponentSettings> _cookiesParser;

        public HomeController(IDataLoader dataLoader, IParsable<ComponentSettings> parser)
        {
            _dataloader = dataLoader;
            _cookiesParser = parser;
        }

        public IActionResult Index()
        {
            var cookie = Request.Cookies["settings"];

            var componentSettings = _cookiesParser.parse(cookie).ToList();

            _dataloader.AddSettings(componentSettings);

            return View(componentSettings);
        }

    }
}
