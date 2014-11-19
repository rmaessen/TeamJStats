using System;
using System.Web.Mvc;
using TeamJStats.DataAccess.Extensions;
using TeamJStats.DataAccess.Infrastructure.Common;

namespace TeamJStats.Web.Common.Helpers
{
    public class FlashStorage
    {
        private readonly TempDataDictionary _tempDataDictionary;

        public FlashStorage(TempDataDictionary tempDataDictionary)
        {
            Contract.Requires<ArgumentNullException>(tempDataDictionary != null);
            _tempDataDictionary = tempDataDictionary;
        }

        public void FlashSuccess(string message, string title = null)
        {
            SetFlash(message, title, "success");
        }

        public void FlashWarn(string message, string title = null)
        {
            SetFlash(message, title, "warn");
        }

        public void FlashError(string message, string title = null)
        {
            SetFlash(message, title, "error");
        }

        public void FlashInfo(string message, string title = null)
        {
            SetFlash(message, title, "info");
        }

        private void SetFlash(string message, string title, string type)
        {
            //TODO: implement flash JS and update with call here
            title = string.IsNullOrEmpty(title) ? "" : ", '{0}'".FormatWith(title);
            //_tempDataDictionary["Flash"] += "<script>$(function () {ph.notify." + timeout + "()." + type + "('" + message + "'" + title + ");});</script>";
        }

        public enum FlashType
        {
            Info,
            Error,
            Success,
            Warn
        }
    }
}