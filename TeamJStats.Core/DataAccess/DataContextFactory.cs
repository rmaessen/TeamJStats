using System.Data.Entity.Infrastructure;

namespace TeamJStats.DataAccess.DataAccess
{
    public class DataContextFactory : IDbContextFactory<DataContext>, IDataContextFactory
    {
        private DataContext _dataContext;

        public string ConnectionName { get; set; }

        public DataContextFactory()
        {
            ConnectionName = "TeamJStats";
        }

        public DataContextFactory(DataContext dataContext) : this()
        {
            _dataContext = dataContext;
        }

        public DataContext Create()
        {
            return _dataContext ?? (_dataContext = new DataContext(ConnectionName)); 
        }

        public DataContext GetContext()
        {
            return Create();
        }
    }
}
