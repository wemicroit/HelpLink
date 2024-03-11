using Microsoft.Extensions.Options;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using WeMicroIt.HelpLink.Abstractions;
using WeMicroIt.HelpLink.Helpers;

namespace WeMicroIt.HelpLink
{
    public class ConfigurationHelpLinkMapper : IHelpLinkMapper
    {
        private readonly HelpLinkOptions _helpLinkOptions;
        public ConfigurationHelpLinkMapper(IOptions<HelpLinkOptions> helpLinkOptions)
        {
            if (helpLinkOptions == null)
            {
                throw new ArgumentNullException(nameof(helpLinkOptions));
            }
            _helpLinkOptions = helpLinkOptions.Value;
        }
        public async Task<string> GetHelpIdAsync(string key, CultureInfo cultureInfo, CancellationToken cancellationToken = default)
        {
            string url = _helpLinkOptions.Items?.Find(x => x.Key == key)?.HelpId;
            if (url != null)
            {
                url = UrlPrcessor.ProcessUrl(url, _helpLinkOptions, cultureInfo);
            }
            return url;
        }
    }
}
