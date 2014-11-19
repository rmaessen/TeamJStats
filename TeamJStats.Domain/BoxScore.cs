using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamJStats.Domain
{
    public class BoxScore : Entity
    {
        public string Key { get; set; }

        public IEnumerable<GameStats> HomeTeamStats {get; set;}
        
        public IEnumerable<GameStats> AwayTeamStats {get; set;}
        
        public Team HomeTeam { get; set; }
        
        public Team AwayTeam { get; set; }

        public DateTime GameDateTime { get; set; }
    }
}
