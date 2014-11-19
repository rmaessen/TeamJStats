namespace TeamJStats.Services.XmlStats.Infrastructure
{
    internal static class Urls
    {
        public static string Event
        {
            get { return BaseUrl + "/event.json"; }
        }

        public static string BoxScore
        {
            get { return BaseUrl + "/boxscore"; }
        }

        public static string Team
        {
            get { return BaseUrl + "/nba/teams"; }
        }

        private static string BaseUrl
        {
            get { return "https://erikberg.com"; }
        }
    }
}