namespace TeamJStats.DataAccess.DataAccess
{
    public interface IDataContextFactory
    {
        DataContext GetContext();
        string ConnectionName { get; set; }
    }
}
