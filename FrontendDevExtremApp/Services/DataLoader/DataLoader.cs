using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Services.Models;

namespace Services
{
    public class DataLoader : IDataLoader
    {
        private List<User> _users  = new List<User>();
        private string _componentSettings = string.Empty;
        private string _url = string.Empty;
        private readonly IUrlBuilder _randomUserUrlBuilder = new RandomUserUrlBuilder();
        private readonly IParser _jsonParser = new JsonParser();

        public DataLoader(IUrlBuilder urlBuilder, IParser parser)
        {
            _randomUserUrlBuilder = urlBuilder;
            _jsonParser = parser;
        }

        public void AddSettings(string componentSettings)
        {
            if (componentSettings != null)
            {
                _componentSettings = componentSettings;
            }
        }

        public List<User> GetData()
        {
            return _users;
        }

        public async Task<List<User>> GetDataFromApiAsync()
        {
            var url = _randomUserUrlBuilder.makeUrl(_componentSettings);

            if (url.Equals(_url))
            {
                return GetData();
            }

            _url = url.ToString();

            await downloadData();

            return _users;
        }

        private async Task downloadData()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(_url);

                if (response.IsSuccessStatusCode)
                {
                    IList<JToken> results = ReadResult(response);

                    _users = _jsonParser.parseJTokens(results);

                    filterListOfUsersByGender();
                }
                else
                {
                    throw new Exception(response.StatusCode.ToString());
                }
            }
        }

        private IList<JToken> ReadResult(HttpResponseMessage result)
        {
            var readTask = result.Content.ReadAsStringAsync();
            readTask.Wait();

            JObject dataFromApi = JObject.Parse(readTask.Result);

            IList<JToken> results = dataFromApi["results"].Children().ToList();

            return results;
        }

        private void filterListOfUsersByGender()
        {
            if (_componentSettings.Contains("female"))
            {
                _users.RemoveAll(u => u.Gender == "male");
            }
            else if (_componentSettings.Contains("male"))
            {
                _users.RemoveAll(u => u.Gender == "female");
            }
        }
    }
}
