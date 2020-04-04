using DataModel;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.DataLoaderTests
{
    public class TestDataLoader
    {
        [Fact]
        public async Task GetDatFromApiReturnsListOfUsers()
        {
            var dataLoader = new DataLoader();
            dataLoader.AddSettings("");
            
            var result = await dataLoader.GetDataFromApiAsync();

            Assert.NotNull(result);
            Assert.IsType<List<User>>(result);
            var expectedCount = 100;
            Assert.Equal(expectedCount, result.Count);
            Assert.Null(result.First().Phone);
            Assert.Null(result.First().City);
            Assert.Null(result.First().Street);
            Assert.Null(result.First().Email);
            Assert.Null(result.First().Gender);

            dataLoader.AddSettings("gender");

            result = await dataLoader.GetDataFromApiAsync();

            Assert.NotNull(result);
            Assert.IsType<List<User>>(result);
            Assert.Equal(expectedCount, result.Count);
            Assert.Null(result.First().Phone);
            Assert.Null(result.First().City);
            Assert.Null(result.First().Street);
            Assert.Null(result.First().Email);
            Assert.NotNull(result.First().Gender);

            dataLoader.AddSettings("gender, location");

            result = await dataLoader.GetDataFromApiAsync();

            Assert.NotNull(result);
            Assert.IsType<List<User>>(result);
            Assert.Equal(expectedCount, result.Count);
            Assert.Null(result.First().Phone);
            Assert.NotNull(result.First().City);
            Assert.NotNull(result.First().Street);
            Assert.Null(result.First().Email);
            Assert.NotNull(result.First().Gender);

            dataLoader.AddSettings("gender, location, email, phone");

            result = await dataLoader.GetDataFromApiAsync();

            Assert.NotNull(result);
            Assert.IsType<List<User>>(result);
            Assert.Equal(expectedCount, result.Count);
            Assert.NotNull(result.First().Phone);
            Assert.NotNull(result.First().City);
            Assert.NotNull(result.First().Street);
            Assert.NotNull(result.First().Email);
            Assert.NotNull(result.First().Gender);

            dataLoader.AddSettings("gender,location,email,phone&gender=male");

            result = await dataLoader.GetDataFromApiAsync();

            Assert.True(expectedCount > result.Count);

            dataLoader.AddSettings("gender,location,email,phone&gender=female");

            result = await dataLoader.GetDataFromApiAsync();

            Assert.NotNull(result);
            Assert.IsType<List<User>>(result);
            Assert.True(expectedCount > result.Count);
        }
    }
}