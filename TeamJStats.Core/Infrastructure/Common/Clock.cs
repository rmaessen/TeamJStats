using System;
using System.Diagnostics;
using TeamJStats.DataAccess.Extensions;

namespace TeamJStats.DataAccess.Infrastructure.Common
{
    public static class Clock
    {
        private static Func<DateTimeOffset> _now = () => DateTimeOffset.UtcNow;

        public static Func<DateTimeOffset> Now
        {
            [DebuggerStepThrough]
            get
            {
                return _now;
            }

            [DebuggerStepThrough]
            set
            {
                System.Diagnostics.Contracts.Contract.Requires<ArgumentNullException>(value != null);
                _now = value;
            }
        }

        #region Public Methods and Operators

        public static DateTime ConvertDateTime(TimeZoneInfo timeZoneInfo, DateTime? dateTime = null)
        {
            DateTime date = (dateTime ?? Now().DateTime);
            var stamp = new DateTime(
                date.Year,
                date.Month,
                date.Day,
                date.Hour,
                date.Minute,
                date.Second,
                DateTimeKind.Utc);

            return TimeZoneInfo.ConvertTime(stamp, timeZoneInfo);
        }

        public static DateTime ConvertDateTime(string timeZoneInfo, DateTime? dateTime = null)
        {
            return ConvertDateTime(TimeZoneInfo.FromSerializedString(timeZoneInfo), dateTime);
        }

        public static DateTime ConvertDateToUtc(DateTime date, string timeZoneInfoString)
        {
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FromSerializedString(timeZoneInfoString);
            return ConvertDateToUtc(date, timeZoneInfo);
        }

        public static DateTime ConvertDateToUtc(DateTime date, TimeZoneInfo timeZoneInfo)
        {
            return TimeZoneInfo.ConvertTimeToUtc(date, timeZoneInfo);
        }

        public static string FormatDate(DateTime datetime)
        {
            return datetime.ToString("MM/dd/yyyy");
        }

        public static string FormatDateLong(DateTime datetime)
        {
            return datetime.ToString("ddd, dd MMM yyyy");
        }

        public static string FormatDateTime(DateTime datetime, string uniteWith = "")
        {
            uniteWith = uniteWith.NullOrEmpty() ? " " : " {0} ".FormatWith(uniteWith);
            return "{0}{1}{2}".FormatWith(FormatDate(datetime), uniteWith, FormatTime(datetime));
        }

        public static string FormatDateTimeLong(DateTime datetime, string uniteWith = "")
        {
            uniteWith = uniteWith.NullOrEmpty() ? " " : " {0} ".FormatWith(uniteWith);
            return "{0}{1}{2}".FormatWith(FormatDateLong(datetime), uniteWith, FormatTime(datetime));
        }

        public static string FormatTimezone(string timezoneInfo)
        {
            return TimeZoneInfo.FromSerializedString(timezoneInfo).Id;
        }
        public static string FormatTime(DateTime datetime)
        {
            return datetime.ToString("h:mm tt");
        }

        public static void Reset()
        {
            _now = () => DateTimeOffset.UtcNow;
        }

        #endregion
    }
}