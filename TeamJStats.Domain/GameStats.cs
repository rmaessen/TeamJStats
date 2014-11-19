using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamJStats.Domain
{
    public class GameStats : Entity
    {        
        public bool Starter { get; set; }
        
        public int Minutes { get; set; }
        
        public int Points { get; set; }
        
        public int Assists { get; set; }
        
        public int Turnovers { get; set; }
        
        public int Steals { get; set; }
        
        public int Blocks { get; set; }
        
        public int FieldGoalsAttempted { get; set; }
        
        public int FieldGoalsMade { get; set; }

        public double FieldGoalPercentage { get; set; }
        
        public int ThreePointFieldGoalsAttempted { get; set; }
        
        public int ThreePointFieldGoalsMade { get; set; }

        public double ThreePointFieldGoalsPercentage { get; set; }
        
        public int FreeThrowsAttempted { get; set; }
        
        public int FreeThrowsMade { get; set; }

        public double FreeThrowPercentage { get; set; }
        
        public int Rebounds { get; set; }
        
        public int OffensiveRebounds { get; set; }
        
        public int DefensiveRebounds { get; set; }
        
        public int PersonalFouls { get; set; }

        public Player Player { get; set; }

        public Team Team { get; set; }

        public BoxScore BoxScore { get; set; }

    }
}
