using System;

namespace TeamJStats.Domain
{
    public class SeasonStats : Entity
    {
        public int GamesPlayed { get; set; }

        public Double AssistsPerGame { get; set; }

        public Double TurnOversPerGame { get; set; }

        public Double StealsPerGame { get; set; }

        public Double BlocksPerGame { get; set; }

        public Double PersonalFoulsPerGame { get; set; }

        public Double ReboundsPerGame { get; set; }

        public Double OffensiveReboundsPerGame { get; set; }

        public Double DefensiveReboundsPerGame { get; set; }

        public Double FieldGoalsAttemptedPerGame { get; set; }

        public Double FieldGoalsMadePerGame { get; set; }

        public Double FieldGoalPercentage { get; set; }

        public Double ThreePointFieldGoalsAttemptedPerGame { get; set; }

        public Double ThreePointFieldGoalsMadePerGame { get; set; }

        public Double ThreePointFieldGoalPercentage { get; set; }

        public Double FreeThrowsAttemptedPerGame { get; set; }

        public Double FreeThrowsMadePerGame { get; set; }

        public Double FreeThrowsPercentage { get; set; }   
    }
}
