using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Threading.Tasks;

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
        public async Task<object> Get(DataSourceLoadOptions loadOptions) 
        {
            var data = await _dataLoader.GetDataFromApiAsync();

            return Ok(DataSourceLoader.Load(data, loadOptions));
        }
    }
}