using System.Web.Mvc;
using TeamJStats.Web.Common.ActionResults;
using TeamJStats.Web.Common.Helpers;

namespace TeamJStats.Web.Common.Extensions
{
    public static class ActionResultExtensions
    {
        #region Public Methods and Operators

        public static WrappedActionResultWithFlash<RedirectResult> FlashError(
            this RedirectResult instance,
            string message,
            string title = null)
        {
            return new WrappedActionResultWithFlash<RedirectResult>(
                instance,
                message,
                FlashStorage.FlashType.Error,
                title);
        }

        public static WrappedActionResultWithFlash<RedirectToRouteResult> FlashError(
            this RedirectToRouteResult instance,
            string message,
            string title = null)
        {
            return new WrappedActionResultWithFlash<RedirectToRouteResult>(
                instance,
                message,
                FlashStorage.FlashType.Error,
                title);
        }

        public static WrappedActionResultWithFlash<RedirectResult> FlashInfo(
            this RedirectResult instance,
            string message,
            string title = null)
        {
            return new WrappedActionResultWithFlash<RedirectResult>(
                instance,
                message,
                FlashStorage.FlashType.Info,
                title);
        }

        public static WrappedActionResultWithFlash<RedirectToRouteResult> FlashInfo(
            this RedirectToRouteResult instance,
            string message,
            string title = null)
        {
            return new WrappedActionResultWithFlash<RedirectToRouteResult>(
                instance,
                message,
                FlashStorage.FlashType.Info,
                title);
        }

        public static WrappedActionResultWithFlash<RedirectResult> FlashSuccess(
            this RedirectResult instance,
            string message,
            string title = null)
        {
            return new WrappedActionResultWithFlash<RedirectResult>(
                instance,
                message,
                FlashStorage.FlashType.Success,
                title);
        }

        //RedirectToRouteResult
        public static WrappedActionResultWithFlash<RedirectToRouteResult> FlashSuccess(
            this RedirectToRouteResult instance,
            string message,
            string title = null)
        {
            return new WrappedActionResultWithFlash<RedirectToRouteResult>(
                instance,
                message,
                FlashStorage.FlashType.Success,
                title);
        }

        public static WrappedActionResultWithFlash<RedirectResult> FlashWarn(
            this RedirectResult instance,
            string message,
            string title = null)
        {
            return new WrappedActionResultWithFlash<RedirectResult>(
                instance,
                message,
                FlashStorage.FlashType.Warn,
                title);
        }

        public static WrappedActionResultWithFlash<RedirectToRouteResult> FlashWarn(
            this RedirectToRouteResult instance,
            string message,
            string title = null)
        {
            return new WrappedActionResultWithFlash<RedirectToRouteResult>(
                instance,
                message,
                FlashStorage.FlashType.Warn,
                title);
        }

        #endregion
    }
}