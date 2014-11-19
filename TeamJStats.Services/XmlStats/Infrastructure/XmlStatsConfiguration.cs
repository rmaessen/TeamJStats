using System.Web.Configuration;

namespace TeamJStats.Services.XmlStats.Infrastructure
{
    public static class XmlStatsConfiguration
    {
        private static string _accessToken;

        internal static string GetApiKey()
        {
            if (string.IsNullOrEmpty(_accessToken))
            {
                _accessToken = WebConfigurationManager.AppSettings["XmlStatsAccessToken"];
            }

            return _accessToken;
        }
    }
}