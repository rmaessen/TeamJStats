using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TeamJStats.Services.XmlStats.Infrastructure;
using TeamJStats.Services.XmlStats.Models;

namespace TeamJStats.Services.XmlStats.Services.Events
{
    public class XmlStatsEventsService : XmlStatsService
    {
        public IList<XmlStatsEvent> List(XmlStatsEventListOptions options)
        {
            var url = String.Format("{0}{1}", Urls.Event, UrlEncode(options));
            return JsonConvert.DeserializeObject<IList<XmlStatsEvent>>(Requestor.GetString(url));
        } 
    }
}