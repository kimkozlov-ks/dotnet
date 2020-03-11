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
        [HttpPost]
        public IActionResult SetState([FromBody]ComponentSettings[] componentSettings, DataLoader dataLoader)
        {
            dataLoader.ComponentSettings = componentSettings.ToList();

            return Ok("OK");
        }
    }
}