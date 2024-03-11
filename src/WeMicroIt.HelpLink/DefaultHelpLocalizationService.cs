using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeMicroIt.HelpLink.Abstractions;

namespace WeMicroIt.HelpLink
{
    public class DefaultHelpLocalizationService : IHelpLocalizationService
    {
        public async Task<CultureInfo> GetHelpCultureAsync(CancellationToken cancellationToken = default)
        {
            return CultureInfo.CurrentUICulture;
        }
    }
}
