using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;

namespace devtest.Models
{
    public class User
    {
        [JsonProperty("name")]
        public UserName Name { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("location")]
        public UserLocation Location { get; set; }
        [JsonProperty("picture")]
        public Picture Picture { get; set; }
    }
}
