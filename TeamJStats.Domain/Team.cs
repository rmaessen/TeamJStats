using System;
using System.Collections.Generic;

namespace TeamJStats.Domain
{
    public class Team : Entity
    {
        public string Key { get; set; }

        public string Name { get; set; }
        
        public string City { get; set; }
        
        public string State { get; set; }

        public string Conference { get; set; }

        public IEnumerable<Player> Roster { get; set; }

        public SeasonStats SeasonStats { get; set; }

        public ICollection<GameStats> GameStats { get; set; }

    }
}
