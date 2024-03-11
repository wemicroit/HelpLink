using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeMicroIt.HelpLink.Helpers
{
    public static class UrlPrcessor
    {
        public static string ProcessUrl(string url, HelpLinkOptions helpLinkOptions, CultureInfo cultureInfo)
        {
            if (helpLinkOptions.Localizations?.Exists(x => x.Language == cultureInfo.Name) != true)
            {
                cultureInfo = new CultureInfo(helpLinkOptions.DefaultCulture);
            }
            if (url.Contains("{{cultureInfoName}}"))
            {
                url = url.Replace("{{cultureInfoName}}", cultureInfo.Name);
            }
            if (url.Contains("{{regionName}}"))
            {
                var regionInfo = new RegionInfo(cultureInfo.LCID);
                url = url.Replace("{{regionName}}", regionInfo.Name );
            }
            if (!helpLinkOptions.PreserveCasing)
            {
                url = url.ToLower();
            }
            return url;
        }
    }
}
