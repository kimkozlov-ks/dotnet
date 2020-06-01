using Moq;
using Services;
using Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tests.DataLoaderTests
{
    // Integral Tests (They needs internet connection)

    public class TestDataLoader
    {
        private const int _expectedCount = 100;

        private IUrlBuilder _urlBuilder = new RandomUserUrlBuilder();
        private IParser _parser = new JsonParser();
        private IDataLoader _dataLoader;


        public TestDataLoader()
        {
           _dataLoader = new DataLoader(_urlBuilder, _parser);
        }

        [Fact]
        public async Task GetDatFromApiReturnsListOfUsersIfComponentSettingsisEmpty()
        {
            _dataLoader.AddSettings("");
            
            var result = await _dataLoader.GetDataFromApiAsync();

            Assert.NotNull(result);
            Assert.IsType<List<User>>(result);

            Assert.Equal(_expectedCount, result.Count);
            Assert.Null(result.First().Phone);
            Assert.Null(result.First().City);
            Assert.Null(result.First().Street);
            Assert.Null(result.First().Email);
            Assert.Null(result.First().Gender);
        }

        [Fact]
        public async Task GetDatFromApiReturnsListOfUsersIfComponentSettingsContainsGender()
        {
            _dataLoader.AddSettings("gender");

            var result = await _dataLoader.GetDataFromApiAsync();

            Assert.NotNull(result.First().Gender);
            Assert.Null(result.First().Phone);
            Assert.Null(result.First().City);
            Assert.Null(result.First().Street);
            Assert.Null(result.First().Email);
        }

        [Fact]
        public async Task GetDatFromApiReturnsListOfUsersIfComponentSettingsContainsLocation()
        {
            _dataLoader.AddSettings("location");

            var result = await _dataLoader.GetDataFromApiAsync();

            Assert.NotNull(result.First().City);
            Assert.NotNull(result.First().Street);
            Assert.Null(result.First().Phone);
            Assert.Null(result.First().Gender);
            Assert.Null(result.First().Email);
        }

        [Fact]
        public async Task GetDatFromApiReturnsListOfUsersIfComponentSettingsContainsEmail()
        {
            _dataLoader.AddSettings("email");

            var result = await _dataLoader.GetDataFromApiAsync();

            Assert.NotNull(result.First().Email);
            Assert.Null(result.First().Phone);
            Assert.Null(result.First().City);
            Assert.Null(result.First().Street);
            Assert.Null(result.First().Gender);
        }

        [Fact]
        public async Task GetDatFromApiReturnsListOfUsersIfComponentSettingsContainsPhone()
        {
            _dataLoader.AddSettings("phone");

            var result = await _dataLoader.GetDataFromApiAsync();

            Assert.NotNull(result.First().Phone);
            Assert.Null(result.First().Gender);
            Assert.Null(result.First().City);
            Assert.Null(result.First().Street);
            Assert.Null(result.First().Email);
        }

        [Fact]
        public async Task GetDatFromApiReturnsListOfUsersIfComponentSettingsContainsGenderType()
        {
            _dataLoader.AddSettings("gender&gender=male");

            var result = await _dataLoader.GetDataFromApiAsync();

            Assert.True(_expectedCount > result.Count);

            _dataLoader.AddSettings("gender&gender=female");

            result = await _dataLoader.GetDataFromApiAsync();

            Assert.NotNull(result);
            Assert.IsType<List<User>>(result);
            Assert.True(_expectedCount > result.Count);
        }
    }
}