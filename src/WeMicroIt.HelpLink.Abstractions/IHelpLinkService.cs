using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeMicroIt.HelpLink.Abstractions
{
    public interface IHelpLinkService
    {
        Task<string?> GetHelpIdAsync(string key, CultureInfo cultureInfo, CancellationToken cancellationToken = default);
    }
}
