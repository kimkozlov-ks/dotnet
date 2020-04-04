using DataModel;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using FrontendDevExtremApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Tests.ControllersTests
{
    public class TestDataGridController
    {
        [Fact]
        public async Task TestGetReturnsOkObkectResult()
        {
            var dataLoader = new Mock<IDataLoader>();
            dataLoader.Setup(d => d.GetDataFromApiAsync())
                .ReturnsAsync(new List<User> { new User(), new User() });

            var dataGridController = new DataGridController(dataLoader.Object);

            var response = await dataGridController.Get(new DataSourceLoadOptions());

            var result = response as OkObjectResult;

            Assert.NotNull(result);
            Assert.IsType<LoadResult>(result.Value);
        }

        

    }
}
