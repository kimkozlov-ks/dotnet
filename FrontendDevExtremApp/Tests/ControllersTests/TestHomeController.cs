using DataModel;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using FrontendDevExtremApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services;
using System.Collections.Generic;
using Xunit;

namespace Tests.ControllersTests
{
    public class TestHomeController
    {
        [Fact]
        public void IndexReturnsView()
        {
            var dataLoader = new Mock<IDataLoader>();
            dataLoader.Setup(d => d.AddSettings(It.IsAny<string>()));

            var homeController = new HomeController(dataLoader.Object, null);

            var result = homeController.Index() as ViewResult;

            Assert.NotNull(result);
            Assert.IsType<ComponentSettings>(result.ViewData.Model);
        }
    }
}
