using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeMicroIt.HelpLink.Abstractions;

namespace WeMicroIt.HelpLink
{
    public static class HelpLinkSericeCollectionExtensions
    {
        public static void AddHelpLink(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHelpLinkService, ConfigurationHelpLinkService>();
            services.AddSingleton<IHelpLocalizationService, DefaultHelpLocalizationService>();
            services.Configure<HelpLinkOptions>(configuration.GetSection("WeMicroIt:HelpLinks"));

        }

    }
}
