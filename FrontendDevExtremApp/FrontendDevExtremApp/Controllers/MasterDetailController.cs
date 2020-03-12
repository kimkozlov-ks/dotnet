using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Services;
using DataModel;
using System.Collections.Generic;
using System.Linq;

namespace FrontendDevExtremApp.Controllers
{
    [Route("api/[controller]")]
    public class MasterDetailController : Controller
    {
        private readonly IDataLoader _dataLoader;

        public MasterDetailController(IDataLoader dataLoader)
        {
            _dataLoader = dataLoader;
        }

        [HttpGet]
        public object GetDetails(string phone, DataSourceLoadOptions loadOptions)
        {
            List<User> masterDetails = _dataLoader.GetData().Where(e => e.Phone == phone).ToList();
            return DataSourceLoader.Load(masterDetails, loadOptions);
        }
    }
}