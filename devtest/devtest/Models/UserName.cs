using Newtonsoft.Json;

namespace devtest.Models
{
    public class UserName
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("first")]
        public string FirstName { get; set; }
        [JsonProperty("last")]
        public string LastName { get; set; }
    }
}