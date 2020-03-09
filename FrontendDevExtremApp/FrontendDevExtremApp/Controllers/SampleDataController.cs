using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Services;
using DataModel.Models;

namespace FrontendDevExtremApp.Controllers {

    [Route("api/[controller]")]
    public class SampleDataController : Controller {

  
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions) 
        {
            var dataLoader = new DataLoader();

            return DataSourceLoader.Load(dataLoader.GetData(), loadOptions);
        }
        /*
        [HttpGet]
        public object TaskDetails(string phone, DataSourceLoadOptions loadOptions)
        {
            var dataLoader = new DataLoader();

            List<User> masterDetails = dataLoader.GetData().Where(e => e.Phone == phone).ToList();
            return DataSourceLoader.Load(masterDetails, loadOptions);
        }*/
    }
}