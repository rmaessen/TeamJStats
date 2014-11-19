using Newtonsoft.Json;

namespace TeamJStats.Services.XmlStats.Models
{
    public class XmlStatsTeam 
    {
        [JsonProperty(PropertyName = "team_id")]
        public string Key { get; set; }

        [JsonProperty(PropertyName = "full_name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }
        
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "conference")]
        public string Conference { get; set; }

        [JsonProperty(PropertyName = "division")]
        public string Division { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }
    }
}