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
        [HttpGet]
        public object GetDetails(string phone, DataSourceLoadOptions loadOptions, DataLoader dataLoader)
        {
            List<User> masterDetails = dataLoader.LoadData().Where(e => e.Phone == phone).ToList();
            return DataSourceLoader.Load(masterDetails, loadOptions);
        }
    }
}