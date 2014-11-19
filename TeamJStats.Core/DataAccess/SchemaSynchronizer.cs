using System.Data.Entity;
using TeamJStats.DataAccess.Migrations;

namespace TeamJStats.DataAccess.DataAccess{
    public class SchemaSynchronizer{
        public void Execute(){
            var initializer = new MigrateDatabaseToLatestVersion<DataContext, Configuration>();
            Database.SetInitializer(initializer);
        }
    }
}   