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
            var cookie = Request.Cookies;
            var componentSettings = new List<ComponentSettings>();
            if (Request.Cookies["settings"] != null)
            { 
                var settings = Request.Cookies["settings"];

                componentSettings.Add(new ComponentSettings("Phone", Convert.ToBoolean(int.Parse(settings[0].ToString()))));
                componentSettings.Add(new ComponentSettings("Gender", Convert.ToBoolean(int.Parse(settings[1].ToString()))));
                componentSettings.Add(new ComponentSettings("City", Convert.ToBoolean(int.Parse(settings[2].ToString()))));
                componentSettings.Add(new ComponentSettings("Street", Convert.ToBoolean(int.Parse(settings[3].ToString()))));
                componentSettings.Add(new ComponentSettings("Email", Convert.ToBoolean(int.Parse(settings[4].ToString()))));  
            }
            else
            {
                componentSettings.Add(new ComponentSettings("Phone"));
                componentSettings.Add(new ComponentSettings("Gender"));
                componentSettings.Add(new ComponentSettings("City"));
                componentSettings.Add(new ComponentSettings("Street"));
                componentSettings.Add(new ComponentSettings("Email"));
            }

            _dataloader.AddSettings(componentSettings);

            return View(componentSettings);
        }

    }
}
