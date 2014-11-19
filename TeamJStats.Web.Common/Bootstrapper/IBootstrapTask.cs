namespace TeamJStats.Web.Common.Bootstrapper
{
    public interface IBootstrapTask
    {
        #region Public Properties

        int Priority { get; }

        #endregion

        #region Public Methods and Operators

        void Execute();

        #endregion
    }
}