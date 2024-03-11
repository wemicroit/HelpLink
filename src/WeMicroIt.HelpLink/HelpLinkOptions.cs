using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeMicroIt.HelpLink
{
    public class HelpLinkOptions
    {
        public HelpLinkOptions() {
            Items = new List<HelpItemOptions>();
            Localizations = new List<HelpLocalizationOptions>();
        }

        public List<HelpItemOptions> Items { get; set; }
        public List<HelpLocalizationOptions> Localizations { get; set; }
        public string DefaultCulture { get; set; } = "en-US";
        public bool PreserveCasing { get; set; } = false;
        public string HelpFilesFolder { get; set; } = "MyStaticFiles";
        public string HelpFilesPath { get; set; } = "Help";
    }
}
