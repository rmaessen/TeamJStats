using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamJStats.Domain
{
    public class Player : Entity
    {
        public string FirstName { get; set; }
     
        public string LastName { get; set; }
        
        public Team Team { get; set; }
        
        public DateTime? Birthdate { get; set; }
        
        public String Position { get; set; }
        
        public int JerseyNumber { get; set; }
        
        public ICollection<GameStats> GameStats { get; set; }

        public SeasonStats SeasonStats { get; set; }
    }
}
