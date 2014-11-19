using TeamJStats.DataAccess.Infrastructure.CommandHandler;

namespace TeamJStats.DataAccess.Infrastructure.EventEmitter
{
    public interface IEventHandler<TCommand>
        where TCommand : class, ICommand
    {
        #region Public Methods and Operators

        void HandleEvent<TEventData>(TEventData eventData) where TEventData : class, IEventData;

        #endregion
    }
}