using BulkCrapUninstaller.Properties;
using Klocman.Extensions;
using Klocman.Tools;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;

namespace BulkCrapUninstaller
{
    public static class CultureConfigurator
    {
        public static IEnumerable<CultureInfo> SupportedLanguages => new[] { CultureInfo.GetCultureInfo("en-US") };

        public static void SetupCulture()
        {
            var currentCulture = CultureInfo.GetCultureInfo("en-US");
            ProcessTools.SetDefaultCulture(currentCulture);
            var thread = Thread.CurrentThread;
            thread.CurrentCulture = currentCulture;
            thread.CurrentUICulture = currentCulture;
        }
    }
}
