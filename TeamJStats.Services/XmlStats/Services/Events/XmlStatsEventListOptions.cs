using System;
using System.Text;
using System.Web;
using TeamJStats.Services.XmlStats.Models;

namespace TeamJStats.Services.XmlStats.Services.Events
{
    public class XmlStatsEventListOptions : IUrlEncoderInfo
    {
        public DateTime? Date { get; set; }
        public Sport? Sport { get; set; }

        public virtual void UrlEncode(StringBuilder sb)
        {
            if (Date.HasValue)
            {
                sb.AppendFormat("date={0}&", HttpUtility.UrlEncode(String.Format("{0:yyyyMMdd}", Date)));
            }

            if (Sport.HasValue)
            {
                sb.AppendFormat("sport={0}&", HttpUtility.UrlEncode(Sport.ToString()));
            }
        }  
    }
}