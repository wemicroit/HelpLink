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
            services.AddHelpLink<ConfigurationHelpLinkMapper, DefaultHelpLocalizationService>(configuration);
        }
        public static void AddHelpLink<T1>(this IServiceCollection services, IConfiguration configuration) where T1 : IHelpLinkMapper
        {
            services.AddHelpLink<T1, DefaultHelpLocalizationService>(configuration);
        }
        public static void AddHelpLink<T1, T2>(this IServiceCollection services, IConfiguration configuration) where T1 : IHelpLinkMapper where T2 : IHelpLocalizationService
        {
            services.AddSingleton(typeof(IHelpLinkMapper), typeof(T1));
            services.AddSingleton(typeof(IHelpLocalizationService), typeof(T2));
            services.Configure<HelpLinkOptions>(configuration.GetSection("WeMicroIt:HelpLinks"));

        }


    }
}
