using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TeamJStats.Services.XmlStats.Models
{
    public class XmlStatsBasketballStats
    {
         [JsonProperty(PropertyName = "last_name")]
         public string LastName { get; set; }

         [JsonProperty(PropertyName = "first_name")]
         public string FirstName { get; set; }

         [JsonProperty(PropertyName = "display_name")]
         public string DisplayName { get; set; }

         [JsonProperty(PropertyName = "position")]
         public string Position { get; set; }

         [JsonProperty(PropertyName = "minutes")]
         public int Minutes { get; set; }

         [JsonProperty(PropertyName = "points")]
         public int Points { get; set; }

         [JsonProperty(PropertyName = "assists")]
         public int Assists { get; set; }

         [JsonProperty(PropertyName = "turnovers")]
         public int Turnovers { get; set; }

         [JsonProperty(PropertyName = "steals")]
         public int Steals { get; set; }

         [JsonProperty(PropertyName = "blocks")]
         public int Blocks { get; set; }

         [JsonProperty(PropertyName = "field_goals_attempted")]
         public int FieldGoalsAttempted { get; set; }

         [JsonProperty(PropertyName = "field_goals_made")]
         public int FieldGoalsMade { get; set; }

         [JsonProperty(PropertyName = "three_point_field_goals_attempted")]
         public int ThreePointFieldGoalsAttempted { get; set; }

         [JsonProperty(PropertyName = "three_point_field_goals_made")]
         public int ThreePointFieldGoalsMade { get; set; }

         [JsonProperty(PropertyName = "free_throws_attempted")]
         public int FreeThrowsAttempted { get; set; }

         [JsonProperty(PropertyName = "free_throws_made")]
         public int FreeThrowsMade { get; set; }

         [JsonProperty(PropertyName = "defensive_rebounds")]
         public int DefensiveRebounds { get; set; }

         [JsonProperty(PropertyName = "rebounds")]
         public int Rebounds { get; set; }

         [JsonProperty(PropertyName = "offensive_rebounds")]
         public int OffensiveRebounds { get; set; }

         [JsonProperty(PropertyName = "personal_fouls")]
         public int PersonalFouls { get; set; }

         [JsonProperty(PropertyName = "team_abbreviation")]
         public string TeamAbbreviation { get; set; }

         [JsonProperty(PropertyName = "is_starter")]
         public bool Starter { get; set; }

         [JsonProperty(PropertyName = "field_goal_percentage")]
         public double FieldGoalPercentage { get; set; }

        [JsonProperty(PropertyName = "three_point_percentage")]
         public double ThreePointFieldGoalPercentage { get; set; }

        [JsonProperty(PropertyName = "free_throw_percentage ")]
        public double FreeThrowPercentage { get; set; }
    }
}
