using Quartz;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Checker : IJob
    {
        private bool _isServiceOnlyne = false;
        private readonly string _url = "https://randomuser.me/";

        public async Task Execute(IJobExecutionContext context)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(_url);

                if (response.IsSuccessStatusCode)
                {
                    _isServiceOnlyne = true;
                }
                else
                {
                    _isServiceOnlyne = false;
                }
            }
        }
    }
}
