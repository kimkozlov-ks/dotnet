using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using FrontendDevExtremApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services;
using Services.Models;
using System.Collections.Generic;
using Xunit;

namespace Tests.ControllersTests
{
    public class TestMasterDetail
    {
        [Fact]
        public void GetDetailsReturnsOkResultWithListOfUsers()
        {
            var dataLoader = new Mock<IDataLoader>();
            dataLoader.Setup(d => d.GetData())
                .Returns(new List<User> { new User(), new User() });

            var masterDetailController = new MasterDetailController(dataLoader.Object);

            var response = masterDetailController.GetDetails("TestName", new DataSourceLoadOptions());

            var result = response as OkObjectResult;

            Assert.NotNull(result);
            Assert.IsType<LoadResult>(result.Value);
        }
    }
}
