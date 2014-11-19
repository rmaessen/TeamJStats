using System.Web;
using System.Web.Mvc;

namespace TeamJStats.DataAccess.Infrastructure.CommandHandler
{
    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        #region Public Methods and Operators
        ICommandResult Execute(TCommand command, HttpRequestBase requestBase, UrlHelper urlHelper);

        #endregion
    }
}