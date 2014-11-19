using System;
using System.Web.Mvc;
using TeamJStats.DataAccess.Infrastructure.Common;
using TeamJStats.Web.Common.Helpers;

namespace TeamJStats.Web.Common.ActionResults
{
    public class WrappedActionResultWithFlash<TActionResult> : ActionResult
        where TActionResult : ActionResult
    {
        #region Constructors and Destructors

        public WrappedActionResultWithFlash(
            TActionResult wrappingResult,
            string flashMessage,
            FlashStorage.FlashType flashType,
            string flashTitle = null,
            bool autoClose = true)
        {
            Contract.Requires<ArgumentNullException>(wrappingResult != null);
            Contract.Requires<ArgumentNullException>(flashMessage != null);
            WrappingResult = wrappingResult;
            FlashMessage = flashMessage;
            FlashTitle = flashTitle;
            AutoClose = autoClose;
            FlashType = flashType;
        }

        #endregion

        #region Public Properties

        public bool AutoClose { get; private set; }

        public string FlashMessage { get; private set; }

        public string FlashTitle { get; private set; }

        public FlashStorage.FlashType FlashType { get; private set; }
        public TActionResult WrappingResult { get; private set; }

        #endregion

        #region Public Methods and Operators

        public override void ExecuteResult(ControllerContext context)
        {
            Contract.Requires<ArgumentNullException>(context != null);
            var storage = new FlashStorage(context.Controller.TempData);

            switch (FlashType)
            {
                case FlashStorage.FlashType.Success:
                    storage.FlashSuccess(FlashMessage, FlashTitle);
                    break;
                case FlashStorage.FlashType.Error:
                    storage.FlashError(FlashMessage, FlashTitle);
                    break;
                case FlashStorage.FlashType.Warn:
                    storage.FlashWarn(FlashMessage, FlashTitle);
                    break;
                case FlashStorage.FlashType.Info:
                    storage.FlashInfo(FlashMessage, FlashTitle);
                    break;
            }
            WrappingResult.ExecuteResult(context);
        }

        #endregion
    }
}