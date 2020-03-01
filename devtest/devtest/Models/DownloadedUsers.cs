using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace devtest.Models
{
    public class DownloadedUsers
    {
        [JsonProperty("results")]
        public List<User> Users { get; set; }
    }
}
