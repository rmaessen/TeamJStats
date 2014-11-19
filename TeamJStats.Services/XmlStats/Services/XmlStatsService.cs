using System.Text;

namespace TeamJStats.Services.XmlStats.Services
{
    public abstract class XmlStatsService
    {
        protected virtual StringBuilder UrlEncode(IUrlEncoderInfo infoInstance)
          {
            StringBuilder str = new StringBuilder ();
            infoInstance.UrlEncode (str);
            if (str.Length > 0)
                str.Length--;
            return str;
        }
    }
}