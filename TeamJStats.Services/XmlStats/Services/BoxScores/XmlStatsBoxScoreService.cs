using System;
using System.Web;
using Newtonsoft.Json;
using TeamJStats.Services.XmlStats.Infrastructure;
using TeamJStats.Services.XmlStats.Models;

namespace TeamJStats.Services.XmlStats.Services.BoxScores
{
    public class XmlStatsBoxScoreService
    {
    
        public XmlStatsNbaBoxScore Get(string eventId)
        {
            var url = String.Format("{0}{1}.{2}", Urls.BoxScore, HttpUtility.UrlEncode(eventId), "json");
            return JsonConvert.DeserializeObject<XmlStatsNbaBoxScore>(Requestor.GetString(url));
        }


    }
}