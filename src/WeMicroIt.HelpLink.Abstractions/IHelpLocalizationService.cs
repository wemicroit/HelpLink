﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeMicroIt.HelpLink.Abstractions
{
    public interface IHelpLocalizationService
    {
        Task<CultureInfo> GetHelpCultureAsync(CancellationToken cancellationToken = default);
    }
}
