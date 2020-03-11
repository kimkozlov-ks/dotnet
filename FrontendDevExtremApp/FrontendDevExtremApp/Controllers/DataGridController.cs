using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace FrontendDevExtremApp.Controllers {

    [Route("api/[controller]")]
    public class DataGridController : Controller {

  
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions, DataLoader dataLoader) 
        {
            return DataSourceLoader.Load(dataLoader.LoadData(), loadOptions);
        }
    }
}