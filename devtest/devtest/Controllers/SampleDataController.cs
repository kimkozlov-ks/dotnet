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

namespace devtest.Controllers {

    [Route("api/[controller]")]
    public class SampleDataController : Controller {

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions) 
        {
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

                    var downloadedUsers = JsonConvert.DeserializeObject<DownloadedUsers>(readTask.Result);

                    SampleData.users = downloadedUsers.Users;
                }
                else
                {
                    //Error response received   
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }

            List<TestData> testData = new List<TestData>();

            foreach (var user in SampleData.users)
            {
                var testUser = new TestData()
                {
                    Name = user.Name.FirstName + " " + user.Name.LastName,
                    Gender = user.Gender,
                    Phone = user.Phone,
                    Email = user.Email,
                    Location = user.Location.Street.Name + " " + user.Location.Street.Number,
                    Picture =  user.Picture.Thumbnail
                };


                testData.Add(testUser);
            }

            return DataSourceLoader.Load(testData, loadOptions);
        }

    }
}