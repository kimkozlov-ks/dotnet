using Newtonsoft.Json;

namespace devtest.Models
{
    public class UserLocation
    {
        [JsonProperty("street")]
        public Street Street { get; set; }
    }
}