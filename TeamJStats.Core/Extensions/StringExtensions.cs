using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using TeamJStats.DataAccess.Infrastructure.Common;

namespace TeamJStats.DataAccess.Extensions
{
    public static class StringExtensions
    {

        private static readonly Regex emailExpression =
            new Regex(
                @"^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$",
                RegexOptions.Singleline | RegexOptions.CultureInvariant | RegexOptions.Compiled);

        #region Public Methods and Operators

        public static string DecryptForUrl(this string instance)
        {
            Encoding encoding = Encoding.UTF8;
            string h = HttpUtility.UrlDecode(instance);
            byte[] b = Convert.FromBase64String(h);
            return encoding.GetString(b);
        }

        public static string EncryptForUrl(this string instance)
        {
            Encoding encoding = Encoding.UTF8;
            byte[] b = encoding.GetBytes(instance);
            string h = Convert.ToBase64String(b);
            return HttpUtility.UrlEncode(h);
        }

        public static string FormatWith(this string instance, params object[] args)
        {
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(instance));
            return string.Format(CultureInfo.CurrentUICulture, instance, args);
        }

        public static bool IsEmail(this string instance)
        {
            return !string.IsNullOrWhiteSpace(instance) && emailExpression.IsMatch(instance);
        }

        public static bool NotNullOrEmpty(this string instance)
        {
            return !string.IsNullOrEmpty(instance);
        }

        public static bool NullOrEmpty(this string instance)
        {
            return string.IsNullOrEmpty(instance);
        }

        //        public static string ToAbsoluteUrl(this string instance, bool secure = false)
        //        {
        //            string baseUrl = secure ? Invariants.Web.BaseUrlSecure : Invariants.Web.BaseUrl;
        //            instance = (instance.StartsWith("/")) ? instance.TrimStart('/') : instance;
        //            return string.Concat(baseUrl, instance);
        //        }

        public static int[] ToRgbArray(this string instance)
        {
            return instance.Split('.').Select(int.Parse).ToArray();
        }

        public static bool IsRgbString(this string instance)
        {
            return Regex.IsMatch(instance, @"(\d+)\.(\d+)\.(\d+)");
        }

        public static string ToTimerFrameEntry(this string instance)
        {
            char[] array = instance.ToCharArray();
            if (array.Length < 2)
            {
                return "0{0}".FormatWith(instance);
            }
            return instance;
        }

        public static bool ValidIpAddress(this string addr)
        {
            IPAddress address;
            return IPAddress.TryParse(addr, out address);
        }

        public static string ToTitleCase(this string str)
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(str);
        }

        /// <summary>
        /// Creates a "slug" from text that can be used as part of a valid URL.
        /// 
        /// Invalid characters are converted to hyphens. Punctuation that is perfect valid in
        /// a URL is also converted to hyphens to keep the result mostly text. Steps are taken
        /// to prevent leading, trailing, and consecutive hyphens.
        /// </summary>
        /// <param name="s">String to convert to a slug</param>
        /// <returns></returns>
        public static string ToSlug(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return String.Empty;
            }

            var sb = new StringBuilder();
            bool wasHyphen = true;

            foreach (char c in s)
            {
                if (char.IsLetterOrDigit(c))
                {
                    sb.Append(char.ToLower(c));
                    wasHyphen = false;
                }
                else if (c != '\'' && !wasHyphen)
                {
                    sb.Append('-');
                    wasHyphen = true;
                }
            }

            // Avoid trailing hyphens
            if (wasHyphen && sb.Length > 0)
                sb.Length--;

            return sb.ToString();
        }

        /// <summary>
        /// Inserts dashed between CamelCased words
        /// Eg: "CamelCased" => "Camel-Cased"
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToHyphenated(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return String.Empty;
            }

            var sb = new StringBuilder();

            for (var i = 0; i < s.Length; i++)
            {
                sb.Append(s[i]);
                if (!char.IsLower(s[i])) continue;
                if (i + 1 < s.Length && char.IsUpper(s[i + 1]))
                {
                    sb.Append('-');
                }
            }

            return sb.ToString();
        }

        #endregion
    }
}