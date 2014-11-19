using System;
using Newtonsoft.Json;

namespace TeamJStats.Services.XmlStats.Models
{
    public class XmlStatsEvent
    {
        [JsonProperty(PropertyName = "event_id")]
        public string Key { get; set; }

        [JsonProperty(PropertyName = "description")]
        public Sport Sport { get; set; }

        [JsonProperty(PropertyName = "event_status")]
        public EventStatus EventStatus { get; set; }

        [JsonProperty(PropertyName = "home_team")]
        public XmlStatsTeam HomeTeam { get; set; }

        [JsonProperty(PropertyName = "away_team")]
        public XmlStatsTeam AwayTeam { get; set; }
       
        [JsonProperty(PropertyName = "start_date_time")]
        public DateTime GameDateTime { get; set; }

        [JsonProperty(PropertyName = "season_type")]
        public SeasonType SeasonType { get; set; }

    }

    public enum EventStatus
    {
        scheduled,
        completed,
        postponed,
        suspended,
        cancelled
    }

    public enum Sport
    {
        nba,
        mba
    }

    public enum SeasonType
    {
        pre,
        regular,
        post
    }
}