using System.Data.Entity.ModelConfiguration;
using TeamJStats.Domain;

namespace TeamJStats.DataAccess.DataAccess.Mapping
{
    class TeamMap : EntityTypeConfiguration<Team>
    {
        public TeamMap()
        {
            HasMany(p => p.GameStats).WithRequired(gs => gs.Team);
        }
    }
}
