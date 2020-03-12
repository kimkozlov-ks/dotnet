using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace FrontendDevExtremApp.Controllers {

    [Route("api/[controller]")]
    public class DataGridController : Controller 
    {
        private readonly IDataLoader _dataLoader;
        public DataGridController(IDataLoader dataLoader)
        {
            _dataLoader = dataLoader;
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions) 
        {
            return DataSourceLoader.Load(_dataLoader.LoadData(), loadOptions);
        }
    }
}