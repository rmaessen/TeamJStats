using System.Data.Entity.ModelConfiguration;
using TeamJStats.Domain;

namespace TeamJStats.DataAccess.DataAccess.Mapping
{
    class PlayerMap : EntityTypeConfiguration<Player>
    {
        public PlayerMap()
        {
            HasMany(p => p.GameStats).WithRequired(gs => gs.Player);
        }
    }
}
