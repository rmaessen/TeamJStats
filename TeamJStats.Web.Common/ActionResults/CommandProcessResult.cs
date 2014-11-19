using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamJStats.DataAccess.Infrastructure.CommandHandler;
using TeamJStats.DataAccess.Infrastructure.Common;
using TeamJStats.DataAccess.Infrastructure.EventEmitter;
using TeamJStats.Web.Common.Extensions;

namespace TeamJStats.Web.Common.ActionResults
{
    public class CommandProcessResult<TCommand> : ActionResult
        where TCommand : class, ICommand
    {
        #region Constants and Fields

        private readonly TCommand _command;

        private readonly ICommandBus _commandBus;

        private readonly Action<IEventData> _eventEmitter;

        private readonly ActionResult _fail;

        private readonly Action<ControllerContext, ICommandResult> _handelFail;

        private readonly HttpRequestBase _httpRequestBase;

        private readonly Func<object, JsonResult> _jsonResult;

        private ActionResult _success;

        #endregion

        #region Constructors and Destructors

        public CommandProcessResult(
            TCommand command,
            ActionResult success,
            ActionResult fail,
            HttpRequestBase httpRequestBase,
            Func<object, JsonResult> jsonResult = null,
            ICommandBus commandProcessor = null,
            Action<ControllerContext, ICommandResult> handelFail = null,
            Action<IEventData> eventEmitter = null)
        {
            Contract.Requires<ArgumentNullException>(command != null);
            Contract.Requires<ArgumentNullException>(success != null);
            Contract.Requires<ArgumentNullException>(fail != null);
            Contract.Requires<ArgumentNullException>(httpRequestBase != null);
            _command = command;
            _commandBus = commandProcessor ?? DependencyResolver.Current.GetService<ICommandBus>();
            _success = success;
            _fail = fail;
            _httpRequestBase = httpRequestBase;
            _jsonResult = jsonResult ?? DefaultJsonResult;
            _handelFail = handelFail ?? HandleFail;
            _eventEmitter = eventEmitter ?? EventEmitter<TCommand>.Emit;
        }

        #endregion

        #region Properties

        private Func<object, JsonResult> DefaultJsonResult
        {
            get
            {
                return o =>
                {
                    var jsonResult = new JsonDotNetResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = o };
                    return jsonResult;
                };
            }
        }

        #endregion

        #region Public Methods and Operators

        public override void ExecuteResult(ControllerContext context)
        {
            //ModelState invalid - Do not send for processing
            if (!context.Controller.ViewData.ModelState.IsValid)
            {
                _handelFail(context, null);
                return;
            }

            //Initial validation pass - send for processing
            ICommandResult commandResult = _commandBus.Submit(
                _command,
                _httpRequestBase,
                new UrlHelper(_httpRequestBase.RequestContext));

            //If errors
            if (!commandResult.Success || (commandResult.Errors != null && commandResult.Errors.Any()))
            {
                foreach (var error in commandResult.Errors)
                {
                    context.Controller.ViewData.ModelState.AddModelError(error.Key, error.Value);
                }
                _handelFail(context, commandResult);
                return;
            }

            //Success - let all subscribers know
            _eventEmitter(commandResult.EventData);
            commandResult.EventData = null;

            //Success - Ajax
            if (context.HttpContext.Request.IsAjaxRequest())
            {
                HandelAjaxRequest(context, result: commandResult);
                return;
            }

            string successType = _success.GetType().Name;
            context.Controller.TempData["CommandMessage"] = commandResult.FlashMessage ?? "";

            _success = commandResult.SuccessAction ?? _success;

            //Success - No flash message on commandResult
            if (string.IsNullOrEmpty(commandResult.FlashMessage) || successType.Contains("WrappedActionResultWithFlash"))
            {
                _success.ExecuteResult(context);
                return;
            }

            //Success - With flash message
            if (successType == "RedirectResult")
            {
                var redirectResult = (RedirectResult)_success;
                redirectResult.FlashSuccess(commandResult.FlashMessage).ExecuteResult(context);
                return;
            }

            _success.ExecuteResult(context);
        }

        #endregion

        #region Methods

        private string GetErrorStringFromModelState(ControllerContext context)
        {
            return string.Join(
                ",",
                context.Controller.ViewData.ModelState.SelectMany(x => x.Value.Errors.Select(e => e.ErrorMessage))
                    .ToList());
        }

        private void HandelAjaxRequest(ControllerContext context, string errors = null, ICommandResult result = null)
        {
            result = result ?? new CommandResult(false) { FlashMessage = errors };
            context.HttpContext.Response.StatusCode = 200;
            _jsonResult.Invoke(result).ExecuteResult(context);
        }

        private void HandleFail(ControllerContext context, ICommandResult result = null)
        {
            string errors = GetErrorStringFromModelState(context);
            context.Controller.TempData["CommandMessage"] = errors;
            if (context.HttpContext.Request.IsAjaxRequest())
            {
                HandelAjaxRequest(context, errors, result);
                return;
            }
            _fail.ExecuteResult(context);
        }

        #endregion
    }
}