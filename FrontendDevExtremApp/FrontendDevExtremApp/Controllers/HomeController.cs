using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Repository;

namespace FrontendDevExtremApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataLoader _dataloader;
        private readonly IRepository _repository;

        public HomeController(IDataLoader dataLoader, IRepository repository)
        {
            _dataloader = dataLoader;
            _repository = repository;
        }

        public IActionResult Index()
        {
            string cookie = string.Empty;
            if (Request != null)
            {
                cookie = Request.Cookies["settings"];
            }

            _dataloader.AddSettings(cookie);

            var res = _repository.AddRequestCookie(cookie).Result;

            var reqs = _repository.GetRequestCookies().Result.ToList();

            return View(new ComponentSettings(cookie));
        }
    }
}
