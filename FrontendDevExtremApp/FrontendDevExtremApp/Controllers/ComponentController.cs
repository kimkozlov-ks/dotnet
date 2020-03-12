using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace FrontendDevExtremApp.Controllers
{   
    public class ComponentController : Controller
    {
        private readonly IDataLoader _dataLoader;

        public ComponentController(IDataLoader dataLoader)
        {
            _dataLoader = dataLoader;
        }

        [HttpPost]
        public IActionResult SetState([FromBody]ComponentSettings[] componentSettings)
        {
            _dataLoader.AddSettings(componentSettings.ToList());

            return Ok("OK");
        }
    }
}