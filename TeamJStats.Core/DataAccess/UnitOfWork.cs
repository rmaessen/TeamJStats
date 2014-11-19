namespace TeamJStats.DataAccess.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDataContextFactory _dataContextFactory;

        public UnitOfWork(IDataContextFactory dataContextFactory)
        {
            _dataContextFactory = dataContextFactory;
        }

        public void Commit()
        {
            _dataContextFactory.GetContext().SaveChanges();
        }
    }
}