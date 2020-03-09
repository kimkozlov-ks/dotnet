using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using DataModel.Models;

namespace Services
{
    public class DataLoader
    {
        private List<User> users  = new List<User>();

        public List<User> GetData()
        {
            return users;
        }

        public List<User> LoadData()
        {
            using (var client = new HttpClient())
            {
                var responseTask = client.GetAsync(new Uri("https://randomuser.me/api/?inc=gender,name,location,email,phone,picture&seed=foobar&results=100&noinfo"));
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    IList<JToken> results = ReadResult(result);
                    users = ParseResults(results);
                }
                else
                {
                    throw new Exception(result.StatusCode.ToString());
                }
            }

            return users;
        }

        private List<User> ParseResults(IList<JToken> results)
        {
            List<User> users = new List<User>();

            foreach (var res in results)
            {
                var phone = res["phone"].ToString();
                var gender = res["gender"].ToString();
                var name = res["name"]["first"] + " " + res["name"]["last"];
                var city = res["location"]["city"].ToString();
                var street = res["location"]["street"]["number"] + " " + res["location"]["street"]["name"];
                var email = res["email"].ToString();
                var picture = res["picture"]["thumbnail"].ToString();

                users.Add(new User()
                {
                    Picture = picture,
                    Name = name,
                    Gender = gender,
                    Phone = phone,
                    City = city,
                    Street = street,
                    Email = email,
                });
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
    }
}
