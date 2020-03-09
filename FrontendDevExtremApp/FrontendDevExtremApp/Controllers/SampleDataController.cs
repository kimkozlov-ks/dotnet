using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace FrontendDevExtremApp.Controllers {

    [Route("api/[controller]")]
    public class SampleDataController : Controller {

  
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions) 
        {
            var dataLoader = new DataLoader();

            return DataSourceLoader.Load(dataLoader.LoadData(), loadOptions);
        }
        

    }
}