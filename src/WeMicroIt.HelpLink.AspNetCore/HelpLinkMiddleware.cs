using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Globalization;
using WeMicroIt.HelpLink.Abstractions;

namespace WeMicroIt.HelpLink.AspNetCore
{
    public class HelpLinkMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHelpLinkService _helpLinkService;
        private readonly IHelpLocalizationService _helpLocalizationService;
        public HelpLinkMiddleware(
            RequestDelegate next,
            IHelpLinkService helpLinkService,
            IHelpLocalizationService helpLocalizationService)
        {
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }

            if (helpLinkService == null)
            {
                throw new ArgumentNullException(nameof(helpLinkService));
            }

            _next = next;
            _helpLinkService = helpLinkService;
            _helpLocalizationService = helpLocalizationService;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            var key = httpContext.Request.Query.FirstOrDefault(x => x.Key.ToLower() == "id").Value.ToString();
            CultureInfo culture = await _helpLocalizationService.GetHelpCultureAsync();
            var help = await _helpLinkService.GetHelpIdAsync(key, culture);
            Console.WriteLine($"The help for '{key}' is {help}");
            httpContext.Response.Redirect($"/Help/{help}");
        }
    }
}
