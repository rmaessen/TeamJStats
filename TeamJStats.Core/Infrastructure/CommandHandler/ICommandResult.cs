using System.Collections.Generic;
using System.Web.Mvc;
using TeamJStats.DataAccess.Infrastructure.EventEmitter;

namespace TeamJStats.DataAccess.Infrastructure.CommandHandler
{
    public interface ICommandResult
    {
        #region Public Properties

        IDictionary<string, string> Errors { get; }

        IEventData EventData { get; set; }

        string FlashMessage { get; set; }

        dynamic Model { get; set; }

        bool Success { get; }

        ActionResult SuccessAction { get; set; }

        #endregion

        #region Public Methods and Operators

        CommandResult AddError(string key, string message);

        CommandResult SetFlashMessage(string message);

        CommandResult SetSuccess(bool success);

        #endregion
    }

    public class CommandResult : ICommandResult
    {
        #region Constructors and Destructors

        public CommandResult(bool success)
        {
            Success = success;
            Errors = new Dictionary<string, string>();
        }

        #endregion

        #region Public Properties

        public IDictionary<string, string> Errors { get; private set; }

        public IEventData EventData { get; set; }

        public string FlashMessage { get; set; }

        public dynamic Model { get; set; }

        public bool Success { get; private set; }

        #endregion

        #region Properties

        public ActionResult SuccessAction { get; set; }

        #endregion

        #region Public Methods and Operators

        public CommandResult AddError(string key, string message)
        {
            Errors.Add(key, message);
            return this;
        }

        public CommandResult SetEventData(IEventData eventData)
        {
            EventData = eventData;
            return this;
        }

        public CommandResult SetFlashMessage(string message)
        {
            FlashMessage = message;
            return this;
        }

        public CommandResult SetModel(dynamic model)
        {
            Model = model;
            return this;
        }

        public CommandResult SetSuccess(bool success)
        {
            Success = success;
            return this;
        }

        #endregion
    }
}