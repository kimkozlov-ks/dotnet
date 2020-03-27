using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using DataModel;

namespace Services
{
    public class DataLoader : IDataLoader
    {
        private List<User> _users  = new List<User>();
        private string _componentSettings;
        private string _url = string.Empty;

        public List<User> GetData()
        {
            return _users;
        }

        public List<User> LoadData()
        {
            var url = makeUrl();

            if(url.Equals(_url))
            {
                return GetData();
            }

            _url = url.ToString();

            using (var client = new HttpClient())
            {
                var responseTask = client.GetAsync(url);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    IList<JToken> results = ReadResult(result);
                    _users = ParseResults(results);
                }
                else
                {
                    throw new Exception(result.StatusCode.ToString());
                }
            }

            return _users;
        }

        private List<User> ParseResults(IList<JToken> results)
        {
            List<User> users = new List<User>();

            foreach (var res in results)
            {
                var user = new User();

                if(res["phone"] != null)
                {
                    user.Phone = Convert.ToString(res["phone"]);
                }

                if (res["gender"] != null)
                {
                    user.Gender = Convert.ToString(res["gender"]);
                }

                user.Name = res["name"]["first"] + " " + res["name"]["last"];

                if (res["location"] != null)
                {
                    user.City = res["location"]["city"].ToString();
                    user.Street = res["location"]["street"]["number"] + " " + res["location"]["street"]["name"];
                }

                if (res["email"] != null)
                {
                    user.Email = res["email"].ToString();
                }

                if (res["picture"] != null)
                {
                    user.Picture = res["picture"]["thumbnail"].ToString();
                }

                users.Add(user);
            }

            if(_componentSettings.Contains("female"))
            {
                users.RemoveAll(u => u.Gender == "male");
            }
            else if (_componentSettings.Contains("male"))
            {
                users.RemoveAll(u => u.Gender == "female");
            }

            return users;
        }

        private IList<JToken> ReadResult(HttpResponseMessage result)
        {
            var readTask = result.Content.ReadAsStringAsync();
            readTask.Wait();

            JObject dataFromApi = JObject.Parse(readTask.Result);

            IList<JToken> results = dataFromApi["results"].Children().ToList();

            return results;
        }

        private Uri makeUrl()
        {
            string url = "https://randomuser.me/api/?inc=name,picture";

            if(_componentSettings != null)
            {
                var editedComopentSettingsString = _componentSettings.ToLower().Replace('_', ',');

                if(editedComopentSettingsString.Contains("city,street"))
                {
                    editedComopentSettingsString = editedComopentSettingsString.Replace("city,street", "location");
                }
                else if (editedComopentSettingsString.Contains("city"))
                {
                    editedComopentSettingsString = editedComopentSettingsString.Replace("city", "location");
                }
                else if (editedComopentSettingsString.Contains("street"))
                {
                    editedComopentSettingsString = editedComopentSettingsString.Replace("street", "location");
                }

                url += ',' + editedComopentSettingsString;
            }

            url += "&seed=foobar&results=100&noinfo";

            if(url.Contains("&gender=male"))
            {
                url.Replace("&gender=male", "");
            }
            else if (url.Contains("&gender=female"))
            {
                url.Replace("&gender=female", "");
            }

            return new Uri(url);
        }

        public void AddSettings(string componentSettings)
        {
            _componentSettings = componentSettings;
        }
    }
}
