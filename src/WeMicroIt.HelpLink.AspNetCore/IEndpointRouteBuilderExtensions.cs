using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.Resources;
using System.Text.RegularExpressions;
using WeMicroIt.HelpLink.Abstractions;

namespace WeMicroIt.HelpLink.AspNetCore
{
    public static class IEndpointRouteBuilderExtensions
    {
        private const string DefaultDisplayName = "Help Links";
        public static IEndpointConventionBuilder MapHelpLinks(this IEndpointRouteBuilder endpoints, string helpLocation)
        {
            return endpoints.MapHelpLinks(helpLocation, "/HelpLinks");
        }

        public static IEndpointConventionBuilder MapHelpLinks(this IEndpointRouteBuilder endpoints, string helpLocation, string pattern)
        {

            if (endpoints == null)
            {
                throw new ArgumentNullException(nameof(endpoints));
            }

            return MapHelpLinksCore(endpoints, helpLocation, pattern);
        }

        private static IEndpointConventionBuilder MapHelpLinksCore(IEndpointRouteBuilder endpoints, string helpLocation, string pattern)
        {

            if (endpoints.ServiceProvider.GetService(typeof(IHelpLinkService)) == null)
            {
                throw new InvalidOperationException($"Unable to find {nameof(ConfigurationHelpLinkService)}, " +
                    $"so call {nameof(HelpLinkSericeCollectionExtensions.AddHelpLink)} " +
                    $"within ConfigureServices()");
            }

            var args = Array.Empty<object>();

            var pipeline = endpoints.CreateApplicationBuilder()
               .UseMiddleware<HelpLinkMiddleware>(args)
               .Build();

            return endpoints.Map(pattern, pipeline).WithDisplayName(DefaultDisplayName);

        }
    }
}
