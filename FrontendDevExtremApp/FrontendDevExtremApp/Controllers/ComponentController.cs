using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontendDevExtremApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontendDevExtremApp.Controllers
{   
    public class ComponentController : Controller
    {   
        [HttpPost]
        public IActionResult SetState([FromBody]ComponentSettings[] settings)
        {

            return Ok("OK");
        }
    }
}