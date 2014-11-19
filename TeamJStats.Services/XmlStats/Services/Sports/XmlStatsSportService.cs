using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TeamJStats.Services.XmlStats.Infrastructure;
using TeamJStats.Services.XmlStats.Models;

namespace TeamJStats.Services.XmlStats.Services.Sports
{
    public class XmlStatsSportService
    {
        public IEnumerable<XmlStatsTeam> GetTeams()
        {
            var url = String.Format("{0}{1}", Urls.Team, ".json");
            return JsonConvert.DeserializeObject<IEnumerable<XmlStatsTeam>>(Requestor.GetString(url));
        }
    }
}   