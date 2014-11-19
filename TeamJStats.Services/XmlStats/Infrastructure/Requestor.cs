using System;
using System.IO;
using System.Net;
using System.Text;

namespace TeamJStats.Services.XmlStats.Infrastructure
{
    internal static class Requestor
    {
        public static string GetString(string url, string apiKey = null)
        {
            var wr = GetWebRequest(url, "GET", apiKey);

            return ExecuteWebRequest(wr);
        }

        internal static WebRequest GetWebRequest(string url, string method, string apiKey = null, bool useBearer = true)
        {
            apiKey = apiKey ?? XmlStatsConfiguration.GetApiKey();

            var request = (HttpWebRequest) WebRequest.Create(url);

            if (!useBearer)
                request.Headers.Add("Authorization", GetAuthorizationHeaderValue(apiKey));
            else
                request.Headers.Add("Authorization", GetAuthorizationHeaderValueBearer(apiKey));

            request.Method = method;

            request.Headers.Add("Authorization", GetAuthorizationHeaderValue(apiKey));
       
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "TeamJStats rebecca_bb@hotmail.com";

            return request;
        }

        private static string ExecuteWebRequest(WebRequest webRequest)
        {

            try
            {
                using (var response = webRequest.GetResponse())
                {
                    return ReadStream(response.GetResponseStream());
                }
            }
            catch (WebException webException)
            {
                if (webException.Response != null)
                {
                    var statusCode = ((HttpWebResponse) webException.Response).StatusCode;

//                    var stripeError = new StripeError();
//
//                    if (webRequest.RequestUri.ToString().Contains("oauth"))
//                        stripeError =
//                            Mapper<StripeError>.MapFromJson(ReadStream(webException.Response.GetResponseStream()));
//                    else
//                        stripeError =
//                            Mapper<StripeError>.MapFromJson(ReadStream(webException.Response.GetResponseStream()),
//                                "error");
//
//                    throw new StripeException(statusCode, stripeError, stripeError.Message);
                }

                throw;
            }
        }

        private static string GetAuthorizationHeaderValueBearer(string apiKey)
        {
            return string.Format("Bearer {0}", apiKey);
        }

        private static string GetAuthorizationHeaderValue(string apiKey)
        {
            var token = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:", apiKey)));
            return string.Format("Basic {0}", token);
        }   

        private static string ReadStream(Stream stream)
        {
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }
}