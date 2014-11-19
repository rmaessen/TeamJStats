using System;
using System.Web;
using System.Web.Mvc;
using TeamJStats.DataAccess.Infrastructure.CommandHandler;
using TeamJStats.Domain;
using TeamJStats.Web.Common.ActionResults;

namespace TeamJStats.Web.Controllers
{
    public class ControllerBase : Controller
    {
        #region Methods

        protected ActionResult CommandResult<TCommand>(TCommand command, ActionResult success, bool hardFail = false)
            where TCommand : class, ICommand
        {
            ActionResult failure = (hardFail) ? PageNotFound() : View(command);
            return new CommandProcessResult<TCommand>(command, success, failure, Request);
        }

        protected ActionResult CommandResult<TCommand>(TCommand command, bool hardFail = false)
            where TCommand : class, ICommand
        {
            ActionResult failure = (hardFail) ? PageNotFound() : View(command);
            RedirectToRouteResult success = RedirectToAction("Index");
            return new CommandProcessResult<TCommand>(command, success, failure, Request);
        }

        protected ActionResult CommandResult<TCommand>(
            TCommand command,
            ActionResult success,
            ActionResult failure,
            bool hardFail = false) where TCommand : class, ICommand
        {
            failure = failure ?? ((hardFail) ? PageNotFound() : View(command));
            return new CommandProcessResult<TCommand>(command, success, failure, Request);
        }

        protected TEntity EntityNotFound<TEntity>(Func<TEntity> func) where TEntity : class, IEntity
        {
            TEntity entity = func.Invoke();
            if (entity == null)
            {
                PageNotFound();
            }

            return entity;
        }

        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonDotNetResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }

        protected ActionResult PageNotFound()
        {
            throw new ResourceNotFoundException();
        }

        #endregion
    }
    [Serializable]
    public class ResourceNotFoundException : Exception
    {
        #region Constructors and Destructors

        public ResourceNotFoundException()
        {
            HttpContext.Current.Response.StatusCode = 404;
        }

        #endregion
    }
}