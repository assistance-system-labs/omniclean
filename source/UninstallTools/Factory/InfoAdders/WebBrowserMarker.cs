using System.Linq;
using Klocman.Tools;

namespace UninstallTools.Factory.InfoAdders
{
    public class WebBrowserMarker : IMissingInfoAdder
    {
        private static readonly string[] BrowserExecutables = WindowsTools.GetInstalledWebBrowsers();

        public void AddMissingInformation(ApplicationUninstallerEntry target)
        {
            if (target == null || target.SortedExecutables.Length == 0) return;

            target.IsWebBrowser = target.SortedExecutables.Any(
                x => BrowserExecutables.Any(
                    y => PathTools.PathsEqual(x, y)));
        }

        public string[] RequiredValueNames { get; } = {
            nameof(ApplicationUninstallerEntry.SortedExecutables)
        };
        public string[] CanProduceValueNames { get; } = {
            nameof(ApplicationUninstallerEntry.IsWebBrowser)
        };

        public bool RequiresAllValues { get; } = true;
        public bool AlwaysRun { get; } = false;
        public InfoAdderPriority Priority { get; } = InfoAdderPriority.RunLast;
    }
}
