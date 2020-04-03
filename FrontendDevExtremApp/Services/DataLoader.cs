using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using DataModel;
using System.Threading.Tasks;

namespace Services
{
    public class DataLoader : IDataLoader
    {
        private List<User> _users  = new List<User>();
        private string _componentSettings = string.Empty;
        private string _url = string.Empty;

        public List<User> GetData()
        {
            return _users;
        }

        public async Task<List<User>> GetDataFromApiAsync()
        {
            var url = makeUrl();

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
                    _users = ParseResults(results);
                }
                else
                {
                    throw new Exception(response.StatusCode.ToString());
                }
            }
        }

        private List<User> ParseResults(IList<JToken> results)
        {
            List<User> users = new List<User>();

            foreach (var res in results)
            {
                var user = createNewUser(res);

                users.Add(user);
            }

            filterListOfUsersByGender(users);

            return users;
        }

        private User createNewUser(JToken res)
        {
            var user = new User();

            if (res["phone"] != null)
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

            return user;
        }

        private void filterListOfUsersByGender(List<User> users)
        {
            if (_componentSettings.Contains("female"))
            {
                users.RemoveAll(u => u.Gender == "male");
            }
            else if (_componentSettings.Contains("male"))
            {
                users.RemoveAll(u => u.Gender == "female");
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
            if(componentSettings != null)
            { 
                _componentSettings = componentSettings;
            }
        }
    }
}
