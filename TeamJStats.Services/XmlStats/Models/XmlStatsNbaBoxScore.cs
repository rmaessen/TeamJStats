using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamJStats.Services.XmlStats.Models
{
    public class XmlStatsNbaBoxScore
    {
        [JsonProperty(PropertyName = "home_team")]
        public XmlStatsTeam HomeTeam { get; set; }

        [JsonProperty(PropertyName = "away_team")]
        public XmlStatsTeam AwayTeam { get; set; }

        [JsonProperty(PropertyName = "home_stats")]
        public IList<XmlStatsBasketballStats> HomeTeamPlayerStats { get; set; }

        [JsonProperty(PropertyName = "away_stats")]
        public IList<XmlStatsBasketballStats> AwayTeamPlayerStats { get; set; }

        [JsonProperty(PropertyName = "home_totals")]
        public XmlStatsBasketballStats HomeTeamStats { get; set; }

        [JsonProperty(PropertyName = "away_totals")]
        public XmlStatsBasketballStats AwayTeamStats { get; set; }
    }
}