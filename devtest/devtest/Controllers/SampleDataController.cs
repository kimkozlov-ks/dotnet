using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using devtest.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace devtest.Controllers {

    [Route("api/[controller]")]
    public class SampleDataController : Controller {

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions) 
        {
            List<User> users = new List<User>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://randomuser.me/api/?inc=gender,seed=foobar,results=100");

                var responseTask = client.GetAsync(new Uri("https://randomuser.me/api/?inc=gender,name,location,email,phone,picture&seed=foobar&results=100&noinfo"));
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    JObject dataFromApi = JObject.Parse(readTask.Result);

                    IList<JToken> results = dataFromApi["results"].Children().ToList();

                    foreach(var res in results)
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
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }

            List<TestData> testData = new List<TestData>();

            return DataSourceLoader.Load(users, loadOptions);
        }
    }
}