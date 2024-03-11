using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.IO;
using System.Resources;
using System.Text.RegularExpressions;
using WeMicroIt.HelpLink.Abstractions;

namespace WeMicroIt.HelpLink.AspNetCore
{
    public static class IEndpointRouteBuilderExtensions
    {
        private const string DefaultDisplayName = "Help Links";
        public static IEndpointConventionBuilder MapHelpLinks(this IEndpointRouteBuilder endpoints)
        {
            return endpoints.MapHelpLinks("HelpLinks");
        }

        public static IEndpointConventionBuilder MapHelpLinks(this IEndpointRouteBuilder endpoints, string pattern)
        {

            if (endpoints == null)
            {
                throw new ArgumentNullException(nameof(endpoints));
            }

            return MapHelpLinksCore(endpoints, pattern);
        }

        public static void UseHelpFiles(this WebApplication app)
        {
            app.UseHelpFiles("help", "MyStaticFiles");
        }

        public static void UseHelpFiles(this WebApplication app, string pattern)
        {
            app.UseHelpFiles(pattern, "MyStaticFiles");
        }

        public static void UseHelpFiles(this WebApplication app, string pattern, string folder)
        {
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(app.Environment.ContentRootPath, folder)),
                RequestPath = $"/{pattern}", // Choose an appropriate request path
            });
        }

        private static IEndpointConventionBuilder MapHelpLinksCore(IEndpointRouteBuilder endpoints, string pattern)
        {

            if (endpoints.ServiceProvider.GetService(typeof(IHelpLinkMapper)) == null)
            {
                throw new InvalidOperationException($"Unable to find {nameof(ConfigurationHelpLinkMapper)}, " +
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
