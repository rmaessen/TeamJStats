using System.Collections.Generic;
using System.Web.Mvc;
using TeamJStats.DataAccess.Infrastructure.CommandHandler;

namespace TeamJStats.DataAccess.Infrastructure.EventEmitter
{
    public static class EventEmitter<TCommand>
        where TCommand : class, ICommand
    {
        #region Public Methods and Operators

        public static void Emit<TData>(TData eventData) where TData : class, IEventData
        {
            IEnumerable<IEventHandler<TCommand>> eventHandlers =
                DependencyResolver.Current.GetServices<IEventHandler<TCommand>>();
            foreach (var eventHandler in eventHandlers)
            {
                eventHandler.HandleEvent(eventData);
            }
        }

        #endregion
    }
}