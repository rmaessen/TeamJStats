using System;
using System.Web;
using System.Web.Mvc;
using TeamJStats.DataAccess.Extensions;

namespace TeamJStats.DataAccess.Infrastructure.CommandHandler
{
    public interface ICommandBus
    {
        #region Public Methods and Operators

        ICommandResult Submit<TCommand>(TCommand command, HttpRequestBase requestBase, UrlHelper urlHelper) where TCommand : ICommand;

        #endregion
    }

    public class CommandBus : ICommandBus
    {
        #region Public Methods and Operators

        public ICommandResult Submit<TCommand>(TCommand command, HttpRequestBase requestBase, UrlHelper urlHelper) where TCommand : ICommand
        {
            var commandHandler = DependencyResolver.Current.GetService<ICommandHandler<TCommand>>();

            if (commandHandler == null)
            {
                throw new InvalidOperationException(
                    "No command handler found for type {0}".FormatWith(typeof(TCommand).Name));
            }

            return commandHandler.Execute(command, requestBase, urlHelper);
        }

        #endregion
    }
}