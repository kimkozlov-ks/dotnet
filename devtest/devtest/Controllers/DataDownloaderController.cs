using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using devtest.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace devtest.Controllers
{
    public class DataDownloaderController : Controller
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            //DownloadedUsers users = null;

            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://randomuser.me/api/?inc=gender,seed=foobar,results=100");

                var responseTask = client.GetAsync(new Uri("https://randomuser.me/api/?inc=gender,name,location,email,phone,picture&seed=foobar&results=100&noinfo"));
                responseTask.Wait();

                var result = responseTask.Result;


                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    //users = JsonConvert.DeserializeObject<DownloadedUsers>(readTask.Result);
                }
                else
                {
                    //Error response received   
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }

            return View(/*users.Users*/);
        }
    }
}